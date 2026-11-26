/*********************************************************************/
// * \file   PlayerBoneThrow.cs
// * \brief  骨を投げる処理
// *
// * \author 石森虹大
/*********************************************************************/

using Assets.Script.Bullet;
using Assets.Script.System.Pool;
using UnityEngine;

namespace Assets.Script.Character.Player.PlayerSystem
{
    /// <summary>
    /// 骨を投げる処理
    /// </summary>
    public class PlayerBoneThrow : MonoBehaviour
    {
        //====================================================================================
        // 変数
        //====================================================================================

        [Header("骨の設定")]
        [SerializeField]
        private Transform throwPoint;

        [SerializeField]
        private float throwSpeed = 10.0f;

        [Header("参照")]
        [SerializeField]
        private BonePool bonePool;

        private PlayerAim playerAim;
        private PlayerInput playerInput;
        private PlayerMovement playerMovement;

        //====================================================================================
        // 関数
        //====================================================================================

        private void Awake()
        {
            playerAim = GetComponent<PlayerAim>();
            playerInput = GetComponent<PlayerInput>();
            playerMovement = GetComponent<PlayerMovement>();

            if(playerAim == null)
            {
                Debug.LogError("PlayerAimが見つかりません。");
            }

            if(playerInput == null)
            {
                Debug.LogError("PlayerInputが見つかりません。");
            }

            if(playerMovement == null)
            {
                Debug.LogError("PlayerMovementが見つかりません。");
            }

            if(bonePool == null)
            {
                Debug.LogError("BonePoolが設定されていません。");
            }

            if(throwPoint == null)
            {
                Debug.LogError("ThrowPointが設定されていません。");
            }
        }

        private void Update()
        {
            // 骨を投げる入力を確認
            if(playerInput != null &&
                playerInput.GetBoneThrowInput())
            {
                ThrowBone();
            }
        }

        /// <summary>
        /// 骨を投げる処理 
        /// </summary>
        public void ThrowBone()
        {
            if(bonePool == null || throwPoint == null || playerAim == null)
            {
                Debug.LogError("骨を投げるための設定が不十分です。");
                return;
            }

            Vector2 direction = playerAim.GetAimDirection();

            if(direction.sqrMagnitude <= 0.0001f) return;

            BoneBullet bone = bonePool.GetObject
            (
                throwPoint.position,
                Quaternion.identity
            );

            if(bone == null) return;

            bone.SetRotationDirection(playerMovement.FacingDirection);

            // 骨弾を発射
            bone.Initialize(direction, throwSpeed);
        }
    }
}