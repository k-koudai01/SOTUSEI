/*********************************************************************/
// * \file   BulletBase.cs
// * \brief  弾の基本クラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;

namespace Assets.Script.Bullet
{
    /// <summary>
    /// 弾の基本クラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BulletBase : MonoBehaviour
    {
        //============================================================
        // 変数
        //============================================================
        protected Rigidbody2D rb;

        [SerializeField]
        protected float moveSpeed = 10.0f;

        //============================================================
        // 関数
        //============================================================
        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        /// <summary>
        /// 弾の発射処理
        /// </summary>
        /// <param name="direction">弾の移動方向</param>
        public virtual void Initialize(Vector2 direction)
        {
            if(direction.sqrMagnitude <= 0.0001) return;

            rb.linearVelocity = direction.normalized * moveSpeed;
        }

    }
}
