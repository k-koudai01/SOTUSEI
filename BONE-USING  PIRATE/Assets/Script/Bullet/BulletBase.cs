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
        /// <param name="speed">弾の移動速度</param>
        public virtual void Initialize(Vector2 direction, float speed)
        {
            if(direction.sqrMagnitude <= 0.0001) return;

            // 速度を初期化
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0.0f;

            rb.linearVelocity = direction.normalized * speed;
        }

    }
}
