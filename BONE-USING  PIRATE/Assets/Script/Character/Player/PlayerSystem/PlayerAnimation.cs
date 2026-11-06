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
        [SerializeField]
        private Sprite rightSprite;
        [SerializeField]
        private Sprite leftSprite;

        private SpriteRenderer spriteRenderer;

        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetDirection(Vector2 direction)
        {
           if(direction.x > 0)
           {
                spriteRenderer.sprite = rightSprite;
           }
           else if(direction.x < 0)
           {
                spriteRenderer.sprite = leftSprite;
           }
        }

    }
}