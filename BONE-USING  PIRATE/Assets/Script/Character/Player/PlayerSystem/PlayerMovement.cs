/*********************************************************************/
// * \file   PlayerMovement.cs
// * \brief  プレイヤーの動きを管理するクラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Character.Player.PlayerSystem
{
    /// <summary>
    /// プレイヤーの動きを管理するクラス
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class PlayerMovement : MonoBehaviour
    {
        //=====================================================================
        // 変数
        //=====================================================================
        [Header("移動設定")]
        [SerializeField]
        private float moveSpeed = 5.0f;

        [Header("ジャンプ設定")]
        [SerializeField]
        private float jumpForce = 10.0f;

        [SerializeField]
        private LayerMask groundLayer;

        [Header("操作設定")]
        [SerializeField]
        private bool canControl = true;

        [Header("接地判定")]
        [SerializeField]
        private float groundCheckDistance = 0.05f;

        private Rigidbody2D rb;
        private CapsuleCollider2D capsuleCollider;

        private Vector2 moveDirection;

        private bool isGrounded;

        private PlayerAnimation playerAnimation;
        //=====================================================================
        // プロパティ
        //=====================================================================

        public bool CanControl => canControl;
        public Vector2 MoveDirection => moveDirection;
        public float VerticalVelocity => rb.linearVelocity.y;
        public bool IsGrounded => isGrounded;
        //=====================================================================
        // 関数
        //=====================================================================

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            capsuleCollider = GetComponent<CapsuleCollider2D>();
            playerAnimation = GetComponent<PlayerAnimation>();
            if(rb == null)
            {
                Debug.LogError("Rigidbody2Dコンポーネントが見つかりません。", this);
            }

            if(capsuleCollider == null)
            {
                Debug.LogError("CapsuleCollider2Dコンポーネントが見つかりません。", this);
            }

            if(moveSpeed <= 0)
            {
                Debug.LogError("移動速度が正しく設定されていません。", this);
            }

        }

        private void Update()
        {
            CheckGround();

            if(moveDirection != Vector2.zero)
            {
                GetComponent<PlayerAnimation>()?.SetDirection(moveDirection);
            }

        }

        private void FixedUpdate()
        {
            if(!canControl)
            {
                // 操作が無効な場合、移動を停止する
                rb.linearVelocity = new Vector2(0.0f, rb.linearVelocity.y);
                return;
            }

            float horizontalInput = moveDirection.x * moveSpeed;

            // 速度の設定
            rb.linearVelocity = new Vector2(horizontalInput, rb.linearVelocity.y);
        }

        /// <summary>
        /// 移動方向を設定するメソッド
        /// </summary>
        /// <param name="direction">移動方向</param>
        public void SetMoveDirection(Vector2 direction)
        {
            if(!canControl)
            {
                moveDirection = Vector2.zero;
                return;
            }

            // 移動方向を正規化して、その大きさを1に制限する
            moveDirection = Vector2.ClampMagnitude(direction, 1.0f);
        }

        /// <summary>
        /// ジャンプ処理
        /// </summary>
        public void Jump()
        {
            if(!canControl || !isGrounded)
            {
                return;
            }

            rb.linearVelocity = new Vector2
            (
                rb.linearVelocity.x,
                jumpForce
            );

            isGrounded = false;
        }

        /// <summary>
        /// 操作可能状態を変更するメソッド
        /// </summary>
        public void SetControlEnabled(bool enabled)
        {
            canControl = enabled;
            if(!canControl) { moveDirection = Vector2.zero; }
        }

        /// <summary>
        /// 移動方向を強制的にリセットするメソッド
        /// </summary>
        public void ResetMoveDirection()
        {
            moveDirection = Vector2.zero;
        }

        /// <summary>
        /// 地面か判定するメソッド
        /// </summary>
        private void CheckGround()
        {
            if(capsuleCollider == null)
            {
                isGrounded = false;
                return;
            }

            Bounds bounds = capsuleCollider.bounds;

            // 接地判定用の矩形を計算する
            Vector2 checkPosition = new Vector2(
                bounds.center.x,
                bounds.min.y - groundCheckDistance * 0.5f
            );

            // 接地判定用の矩形のサイズを計算する
            Vector2 checkSize = new Vector2(
                bounds.size.x * 0.8f,
                groundCheckDistance
            );

            // 接地判定を行う
            isGrounded = Physics2D.OverlapBox(
                checkPosition,
                checkSize,
                0.0f,
                groundLayer
            ) != null;
        }

        private void OnDrawGizmosSelected()
        {
            if(capsuleCollider == null) { return; }
           
            Bounds bounds = capsuleCollider.bounds;

            Vector2 checkPosition = new Vector2
            (
                bounds.center.x,
                bounds.min.y - groundCheckDistance * 0.5f
            );

            Vector2 checkSize = new Vector2
            (
                bounds.size.x * 0.8f,
                groundCheckDistance
            );

            Gizmos.color = Color.green;

            Gizmos.DrawWireCube(checkPosition, checkSize);
        }
    }

}