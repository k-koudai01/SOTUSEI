/*********************************************************************/
// * \file   PlayerAnimation.cs
// * \brief  プレイヤーのアニメーションクラス
// *
// * \author 石森虹大
/*********************************************************************/

using UnityEngine;

namespace Assets.Script.Character.Player.PlayerSystem
{
    /// <summary>
    /// アニメーションクラス
    /// </summary>
    public class PlayerAnimation : MonoBehaviour
    {

        [Header("待機画像")]
        [SerializeField]
        private Sprite idleRightSprite;
        [SerializeField]
        private Sprite idleLeftSprite;

        [Header("移動画像")]
        [SerializeField]
        private Sprite runRightSprite;
        [SerializeField]
        private Sprite runLeftSprite;

        private SpriteRenderer spriteRenderer;


        // 最後の方向を記録する
        private bool isFacingRight = true;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
      
        public void SetDirection(Vector2 direction)
        {
            if (direction.x > 0)
            {
                isFacingRight = true;
                spriteRenderer.sprite = runRightSprite;
            }
            else if (direction.x < 0)
            {
                isFacingRight = false;
                spriteRenderer.sprite = runLeftSprite;
            }
        }

        public void SetIdle()
        {
            if(isFacingRight)
            {
                spriteRenderer.sprite = idleRightSprite;
            }
            else
            {
                spriteRenderer.sprite = idleLeftSprite;
            }
        }
    }
}