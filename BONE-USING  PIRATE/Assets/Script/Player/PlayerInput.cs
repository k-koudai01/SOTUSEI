using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// プレイヤーの入力を管理するクラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    //=====================================================================
    // 変数
    //=====================================================================
    [Header("参照")]

    [Header("入力設定")]

    [SerializeField]
   //  private Key bulletDeleteAreaKey = Key.Q;

    private GameObject currentPlayer;
    //=====================================================================
    // 初期化
    //=====================================================================

    private void Awake()
    {
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        if(currentPlayer == null)
        {
            Debug.LogError("Playerオブジェクトが見つかりません。");
        }
    }

    private void Update()
    {
        if(Keyboard.current == null) { return; }

        // 移動入力を更新
        UpdateMoveInput(currentPlayer);
    }
    //=====================================================================
    // アクション開始関数
    //=====================================================================

    /// <summary>
    /// 移動入力を更新する
    /// </summary>
    /// <param name="currentPlayer"></param>
    private void UpdateMoveInput(GameObject currentPlayer)
    { 
        PlayerMovement movement = currentPlayer.GetComponent<PlayerMovement>();
        if(movement == null) { return; }

        Vector2 moveInput = GetMoveInput();

        movement.SetMoveDirection(moveInput);
    }

    //=====================================================================
    // 入力取得関数
    //=====================================================================

    /// <summary>
    /// 移動入力を取得する
    /// </summary>
    /// <returns> 移動入力 </returns>
    public Vector2 GetMoveInput()
    {
        float horizontal = 0.0f;
        float vertical   = 0.0f;

        if(Keyboard.current.dKey.isPressed ||
           Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = 1.0f;

        }
        else if(Keyboard.current.aKey.isPressed ||
                Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -1.0f;
        }

        return new Vector2(horizontal, vertical);
    }
}