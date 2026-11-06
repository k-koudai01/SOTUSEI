/*********************************************************************/
// * \file   PlayerMovement.cs
// * \brief  プレイヤーの移動処理クラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Character.Player.PlayerSystem
{
    /// <summary>
    /// プレイヤーの移動処理クラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        //=====================================================================
        // 変数
        //=====================================================================
        [Header("移動設定")]

        [SerializeField]
        private float moveSpeed = 5.0f;

        [Header("操作設定")]

        [SerializeField]
        private bool canControl = true;

        private Rigidbody2D rb;

        private Vector2 moveDirection;

        private PlayerAnimation playerAnimation;

        //=====================================================================
        // プロパティ
        //=====================================================================
        public bool CanControl => canControl;
        public Vector2 MoveDirection => moveDirection;

        //=====================================================================
        // 関数
        //=====================================================================

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2Dコンポーネントが見つかりません。", this);
            }

            if (moveSpeed <= 0)
            {
                Debug.LogError("移動速度が正しく設定されていません。", this);
            }

            playerAnimation = GetComponent<PlayerAnimation>();
            if(playerAnimation == null)
            {
                Debug.LogError($"{name}: PlayerMovementまたはNoahAnimationがアタッチされていません。", this);
            }

        }

        private void Update()
        {
            if (playerAnimation == null) { return; }

            if (this.MoveDirection != Vector2.zero)
            {
                playerAnimation.SetDirection(this.MoveDirection);
            }
        }

        private void FixedUpdate()
        {
            if (!canControl || moveDirection == Vector2.zero) { return; }

            Vector2 nextPosition =
                rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime;

            rb.position = nextPosition;

        }

        /// <summary>
        /// 移動方向を設定するメソッド
        /// </summary>
        /// <param name="direction">移動方向</param>
        public void SetMoveDirection(Vector2 direction)
        {
            if (!canControl)
            {
                moveDirection = Vector2.zero;
                return;
            }

            // 移動方向を正規化して、その大きさを1に制限する
            moveDirection = Vector2.ClampMagnitude(direction, 1.0f);
        }

        /// <summary>
        /// 操作可能状態を変更するメソッド
        /// </summary>
        public void SetControlEnabled(bool enabled)
        {
            canControl = enabled;
            if (!canControl) { moveDirection = Vector2.zero; }
        }

        /// <summary>
        /// 移動方向を強制的にリセットするメソッド
        /// </summary>
        public void ResetMoveDirection()
        {
            moveDirection = Vector2.zero;
        }
    }

}