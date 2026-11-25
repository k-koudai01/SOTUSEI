/*********************************************************************/
// * \file   ObjectPoolBase.cs
// * \brief  オブジェクトプールの基底クラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Script.System.Pool
{

    /// <summary>
    /// オブジェクトプールの基底クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObjectPoolBase<T> : MonoBehaviour
        where T : Component
    {
        //============================================================
        // 変数
        //============================================================
        [SerializeField]
        private T prefab;
        [SerializeField]
        private int initialPoolSize = 30;
        [SerializeField]
        private int maxPoolSize = 100;

        private ObjectPool<T> objectPool;


        //============================================================
        // 関数
        //============================================================
        protected void Awake()
        {
            InitializePool();
            PreloadObjects();
        }

        /// <summary>
        /// オブジェクトプールの初期化。
        /// </summary>
        private void InitializePool()
        {
            maxPoolSize = Mathf.Max(1, maxPoolSize);                        // 最大プールサイズは1以上にする
            initialPoolSize = Mathf.Clamp(initialPoolSize, 0, maxPoolSize); // 初期プールサイズは0以上、最大プールサイズ以下にする

            objectPool = new ObjectPool<T>
            (
                createFunc: CreateObject,
                actionOnGet: OnGetObject,
                actionOnRelease: OnReleaseObject,
                actionOnDestroy: OnDestroyObject,
                collectionCheck: true,　           // 同じオブジェクトを二重返却していないかチェックする。
                defaultCapacity: initialPoolSize,　// 初期プールサイズ
                maxSize: maxPoolSize               // 最大プールサイズ
            );
        }

        /// <summary>
        /// オブジェクトプールに初期オブジェクトを事前に読み込む。
        /// </summary>
        private void PreloadObjects()
        {
            T[] objects = new T[initialPoolSize];
            

            for(int i = 0; i < initialPoolSize; i++)
            {
                objects[i] = objectPool.Get();
            }

            // 取得したオブジェクトをプールに戻す
            for(int i = 0; i < initialPoolSize; i++)
            {
                objectPool.Release(objects[i]);
            }

        }

        /// <summary>
        /// オブジェクトプールからオブジェクトを取得
        /// </summary>
        /// <returns></returns>
        private T CreateObject()
        {
            T obj = Instantiate(prefab, transform);

            // プールから取得したオブジェクトは非アクティブにする
            obj.gameObject.SetActive(false);

            //Debug.Log($"[Pool] オブジェクト作成 : {obj.name}");
            return obj;
        }

        /// <summary>
        /// オブジェクトプールからオブジェクトを取得したときに呼び出す。
        /// </summary>
        /// <param name="obj">関連付けられたゲームオブジェクトをアクティブ化するオブジェクト。</param>
        protected virtual void OnGetObject(T obj)
        {
            
        }

        /// <summary>
        /// オブジェクトを非アクティブ化します。
        /// </summary>
        /// <param name="obj">非アクティブ化するオブジェクト。</param>
        private void OnReleaseObject(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        /// <summary>
        /// 指定されたオブジェクトに関連付けられたゲームオブジェクトを破棄します。
        /// </summary>
        /// <param name="obj">破棄するオブジェクト。</param>
        private void OnDestroyObject(T obj)
        {
            if(obj == null) return;
            Destroy(obj.gameObject);
        }

        /// <summary>
        /// オブジェクトプールからオブジェクトを取得し、指定された位置と回転で配置します。
        /// </summary>
        /// <param name="position">オブジェクトを配置する位置。</param>
        /// <param name="rotation">オブジェクトの回転。</param>
        public T GetObject(Vector2 position, Quaternion rotation)
        {
            T obj = objectPool.Get();

            // 取得したオブジェクトの位置と回転を設定し、アクティブ化する
            obj.transform.SetPositionAndRotation(position, rotation);
            obj.gameObject.SetActive(true);

            //Debug.Log($"[Pool] オブジェクト取得：{obj.name}");

            return obj;
        }

        /// <summary>
        /// オブジェクトをオブジェクトプールに返却します。
        /// </summary>
        /// <param name="obj">返却するオブジェクト。</param>
        public void ReleaseObject(T obj)
        {
            if(obj == null) return;

            Debug.Log($"[Pool] オブジェクト返却：{obj.name}");

            objectPool.Release(obj);
        }
    }
}