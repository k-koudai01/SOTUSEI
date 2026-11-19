using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Script.Character.Player.PlayerSystem
{
    /// <summary>
    /// プレイヤーの入力を管理するクラス
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        //=====================================================================
        // 変数
        //=====================================================================
        //[Header("参照")]

        //[Header("入力設定")]

        //[SerializeField]
        //  private Key bulletDeleteAreaKey = Key.Q;

        //private  PlayerMovement movement;

        //private GameObject currentPlayer;

        ///=====================================================================
        /// プロパティ
        ///===================================================================== 

        //=====================================================================
        // 初期化
        //=====================================================================

        private void Awake()
        {
            //currentPlayer = GameObject.FindGameObjectWithTag("Player");
            //if (currentPlayer == null)
            //{
            //    Debug.LogError("Playerオブジェクトが見つかりません。");
            //    return;
            //}

            //movement = currentPlayer.GetComponent<PlayerMovement>();
            //if(movement == null)
            //{
            //    Debug.LogError("PlayerMovementコンポーネントが見つかりません。");
            //    return;
            //}
        }

        //=====================================================================
        // 入力取得関数
        //=====================================================================

        /// <summary>
        /// ジャンプ入力を取得する 
        /// </summary>
        /// <returns> ジャンプ入力 </returns>
        public bool GetJumpInput()
        {
            bool keyboardInput = 
                Keyboard.current != null && 
                Keyboard.current.spaceKey.wasPressedThisFrame;

            bool gamepadInput = 
                Gamepad.current != null && 
                Gamepad.current.buttonSouth.wasPressedThisFrame;

            return keyboardInput || gamepadInput;
        }

        /// <summary>
        /// 移動入力を取得する
        /// </summary>
        /// <returns> 移動入力 </returns>
        public Vector2 GetMoveInput()
        {
           Vector2 input = Vector2.zero;
           
            if(Keyboard.current != null)
            {
                if (Keyboard.current.dKey.isPressed ||
                    Keyboard.current.rightArrowKey.isPressed)
                {
                    input.x = 1.0f;
                }
                else if (Keyboard.current.aKey.isPressed ||
                         Keyboard.current.leftArrowKey.isPressed)
                {
                    input.x = -1.0f;
                }
            }

            if(Gamepad.current != null)
            {
                Vector2 stickInput = Gamepad.current.leftStick.ReadValue();
                if(Mathf.Abs(stickInput.x) > 0.1f)
                {
                    input.x = stickInput.x;
                }
            }

            return new Vector2(input.x, 0.0f);
        }

        /// <summary>
        /// Gets the current aiming input.
        /// </summary>
        /// <returns>The current aiming input as a two-dimensional vector.</returns>
        public Vector2 GetAimInput()
        {
            Vector2 input = Vector2.zero;

            if(Keyboard.current != null)
            {
                if (Keyboard.current.dKey.isPressed ||
                    Keyboard.current.rightArrowKey.isPressed)
                {
                    input.x = 1.0f;
                }
                else if (Keyboard.current.aKey.isPressed ||
                         Keyboard.current.leftAltKey.isPressed)
                {
                    input.x = -1.0f;
                }

                if (Keyboard.current.wKey.isPressed ||
                    Keyboard.current.upArrowKey.isPressed)
                {
                    input.y = 1.0f;
                }
                else if (Keyboard.current.sKey.isPressed ||
                         Keyboard.current.downArrowKey.isPressed)
                {
                    input.y = -1.0f;
                }
            }

            if(Gamepad.current != null)
            { 
                Vector2 stickInput = Gamepad.current.leftStick.ReadValue();

                // スティックが一定以上倒されているか
                if(stickInput.sqrMagnitude > 0.01f)
                {
                    input = stickInput;
                }
            }
            return input;
        }
    }
}
