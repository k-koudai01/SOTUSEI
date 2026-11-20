/*********************************************************************/
// * \file   PlayerAim.cs
// * \brief  プレイヤーの照準方向を管理するクラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;

namespace Assets.Character.Player.PlayerSystem
{
    /// <summary>
    /// プレイヤーの照準方向を管理するクラス
    /// </summary>
    public class PlayerAim : MonoBehaviour
    {
        //====================================================================================
        // 変数
        //====================================================================================

        private PlayerInput playerInput;
        private PlayerAnimation playerAnimation;

        //====================================================================================
        // 関数
        //====================================================================================

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            playerAnimation = GetComponent<PlayerAnimation>();

            if(playerInput == null)
            {
                Debug.LogError("PlayerInputコンポーネントが見つかりません。");
            }
            if (playerAnimation == null)
            {
                Debug.LogError("PlayerAnimationコンポーネントが見つかりません。");
            }
        }

        private void Update()
        {
            Vector2 aimDirection = GetAimDirection();

            // 照準方向を表示する
            if (aimDirection.sqrMagnitude > 0.01)
            {
                Debug.Log($"Aim Direction: {aimDirection}");
            }
        }

        /// <summary>
        /// 骨を投げる方向を取得する
        /// </summary>
        public Vector2 GetAimDirection()
        {
            Vector2 input = playerInput.GetAimInput();

            if(input.sqrMagnitude > 0.01)
            {
                return input.normalized;
            }

            // 入力がない場合は、プレイヤーの向きに基づいて方向を決定する
            return playerAnimation.IsFacingRight ? Vector2.right : Vector2.left;
        }

        ///// <summary>
        ///// この関数は、Unityエディタ上でGizmosを描画するために使用されます。プレイヤーの照準方向を視覚的に確認するために、赤い線を描画します。
        ///// </summary>
        //private void OnDrawGizmos()
        //{
        //    Vector2 aimDirection = GetAimDirection();
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawLine(transform.position, (Vector2)transform.position + aimDirection);
        //}

    }
}
