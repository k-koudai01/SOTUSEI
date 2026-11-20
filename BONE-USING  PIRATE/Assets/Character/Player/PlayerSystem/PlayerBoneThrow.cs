using UnityEngine;

namespace Assets.Character.Player.PlayerSystem
{
    /// <summary>
    /// プレイヤーの骨投げ処理クラス
    /// </summary>
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
            if (playerAim == null)
            {
                Debug.LogError("PlayerAimコンポーネントが見つかりません。");
            }
        }

        /// <summary>
        /// 骨を投げる
        /// </summary>
        public void ThrowBone()
        {
            if(bonePrefab == null || throwPoint == null || playerAim == null)
            {
                Debug.LogError("骨投げに必要な設定が不足しています。", this);
                return;
            }

            Vector2 direction = playerAim.GetAimDirection();

            // 骨を生成
            GameObject boneObject = Instantiate(
                bonePrefab,
                throwPoint.position,
                Quaternion.identity
            );

            if (boneObject == null)
            {
                Debug.LogError("骨の生成に失敗しました。", this);
                return;
            }

            // 骨のRigidbody2Dを取得
            Rigidbody2D bone = boneObject.GetComponent<Rigidbody2D>();

            // 骨に速度を設定
            bone.linearVelocity = direction * throwSpeed;
        }
    }
}
