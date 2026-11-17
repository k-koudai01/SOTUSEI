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
        //============================================================
        // 変数
        //============================================================
        //[Header("待機画像")]
        //[SerializeField]
        //private Sprite idleRightSprite;
        //[SerializeField]
        //private Sprite idleLeftSprite;

        //[Header("移動画像")]
        //[SerializeField]
        //private Sprite runRightSprite;
        //[SerializeField]
        //private Sprite runLeftSprite;

        [Header("アニメーションID")]
        [SerializeField] private AnimationData idIdleRight;
        [SerializeField] private AnimationData idIdleLeft;
        [SerializeField] private AnimationData idMoveRight;
        [SerializeField] private AnimationData idMoveLeft;

        private Animator animator;

        // private SpriteRenderer spriteRenderer;

        // 最後の方向を記録する
        private bool isFacingRight = true;

        private int currentAnimationHash = -1;

        //============================================================
        // 関数
        //============================================================
        void Awake()
        {
            animator = GetComponent<Animator>();

            idIdleRight.Initialize();
            idIdleLeft.Initialize();
            idMoveRight.Initialize();
            idMoveLeft.Initialize();
        }

        //===============================================================
        //アニメーション処理
        //===============================================================

        /// <summary>
        /// アニメーション再生
        /// </summary>
        private void PlayAnimation(AnimationData animation)
        {
            // 同じアニメーションなら再生し直さない
            if (currentAnimationHash == animation.StateHash)
                return;

            currentAnimationHash = animation.StateHash;

            animator.speed = animation.Speed;
            animator.Play(animation.StateHash);
        }

        /// <summary>
        /// 移動方向の設定
        /// </summary>
        public void SetDirection(Vector2 direction)
        {
            if (direction.x > 0)
            {
                isFacingRight = true;
                PlayAnimation(idMoveRight);
            }
            else if (direction.x < 0)
            {
                isFacingRight = false;
                PlayAnimation(idMoveLeft);
            }
        }

        /// <summary>
        /// 待機アニメーション
        /// </summary>
        public void SetIdle()
        {
            if(isFacingRight)
            {
                PlayAnimation(idIdleRight);
            }
            else
            {
                PlayAnimation(idIdleLeft);
            }
        }
    }
}