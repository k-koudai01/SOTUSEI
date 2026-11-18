/*********************************************************************/
// * \file   SwitchController.cs
// * \brief  スイッチ制御クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchInteraction : MonoBehaviour
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [Header("スイッチ設定")]
    [SerializeField]
    private SwitchController switchController;

    [Header("入力設定")]
    [SerializeField]
    private Key key = Key.E;

    private bool isPlayerNearby;

    //=====================================================================
    // プレイヤーとの接触判定
    //=====================================================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("範囲にプレイヤーが入りました。");

        if(other.CompareTag("Player")) { isPlayerNearby = true; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("範囲からプレイヤーが出ました。");

        if(other.CompareTag("Player")) { isPlayerNearby = false; }
    }

    //=====================================================================
    // 入力処理
    //=====================================================================

    private void Update()
    {
        if(!isPlayerNearby) return;

        if(Keyboard.current[key].wasPressedThisFrame)
        {
            //Debug.Log($"入力が検出されました。{key}キーが押されました。");

            switchController.Activate();
        }
    }
}
