using UnityEngine;

namespace Assets.Script.Character.Player.PlayerSystem
{
    public class PlayerBoneThrow : MonoBehaviour
    {
        //====================================================================================
        // 変数
        //====================================================================================

        [Header("骨の設定")]
        [SerializeField]
        private GameObject bonePrefab;

        [SerializeField]
        private Transform throwPoint;

        [SerializeField]
        private float throwSpeed = 10.0f;

        private PlayerAim playerAim;

        //====================================================================================
        // 関数
        //====================================================================================

        private void Awake()
        {
            playerAim = GetComponent<PlayerAim>();

            if(playerAim == null)
            {
                Debug.LogError("PlayerAimコンポーネントが見つかりません。");
            }
        }

        /// <summary>
        /// 骨を投げる処理 
        /// </summary>
        public void ThrowBone()
        {
            if(bonePrefab == null || throwPoint == null || playerAim == null)
            {
                Debug.LogError("骨を投げるための設定が不十分です。");
                return;
            }

            Vector2 direction = playerAim.GetAimDirection();

            GameObject boneObject = Instantiate
            (
                bonePrefab, 
                throwPoint.position, 
                Quaternion.identity
            );

            Rigidbody2D bone = boneObject.GetComponent<Rigidbody2D>();

            bone.linearVelocity = direction * throwSpeed;
        }
    }
}