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

    //=====================================================================
    // アクション開始関数
    //=====================================================================
    private void UpdateMoveInput(GameObject currentPlayer)
    {
        PlayerMovement movement
    }
}
