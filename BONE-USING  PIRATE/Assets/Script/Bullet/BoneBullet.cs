/*********************************************************************/
// * \file   BoneBullet.cs
// * \brief  骨弾クラス
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;

namespace Assets.Script.Bullet
{
    /// <summary>
    /// 骨弾クラス
    /// </summary>
    public class BoneBullet : BulletBase
    {
        //====================================================================================
        // 変数
        //====================================================================================

        [Header("重力の設定")]
        [SerializeField]
        private float gravityDelay = 0.2f;

        [SerializeField]
        private float gravityScale = 1.0f;

        private float gravityTimer;

        private bool isGravityEnabled; // 重力が有効かどうか

        //====================================================================================
        // 関数
        //====================================================================================

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            UpdateGravity();
        }

        /// <summary>
        /// 重力の更新処理
        /// </summary>>

        private void UpdateGravity()
        {
            if(isGravityEnabled) return;

            gravityTimer += Time.deltaTime;

            // 重力が有効になるまでの時間が経過していない場合は処理を終了
            if(gravityTimer < gravityDelay) return;

            rb.gravityScale  = gravityScale;
            isGravityEnabled = true;
        }

        //====================================================================================
        // 発射関数
        //====================================================================================

        /// <summary>
        /// 骨弾の発射処理
        /// </summary>
        /// <param name="direction">弾の移動方向</param>
        /// <param name="speed">弾の移動速度</param>
        public override void Initialize(Vector2 direction, float speed)
        {
            if(direction.sqrMagnitude <= 0.0001f) return;

            // 重力の状態を初期化
            gravityTimer = 0.0f;

            if(gravityDelay <= 0.0f)
            {
                isGravityEnabled = true;
                rb.gravityScale = gravityScale;
            }
            else
            {
                // 一定時間たったら重力を無効化
                isGravityEnabled = false;
                rb.gravityScale = 0.0f;
            }

            // 基底クラスの発射処理を利用
            base.Initialize(direction, speed);
        }
    }
}