/*********************************************************************/
// * \file   Interactable.cs
// * \brief  インタラクト可能オブジェクトの基底クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// インタラクト可能オブジェクトの抽象クラス
/// </summary>
public abstract class Interactable : MonoBehaviour
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [Header("インタラクト入力設定")]
    [SerializeField]
    private Key interactKeyInput = Key.E;

    private bool isPlayerNearby = false;

    //=====================================================================
    // プレイヤーとの接触判定
    //=====================================================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("範囲にプレイヤーが入りました。");

        if(!IsPlayerTag(other)) { return; }

        isPlayerNearby = true;

        // プレイヤーが範囲に入ったときの個別処理を実行
        OnPlayerEnter(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("範囲からプレイヤーが出ました。");

        if(!IsPlayerTag(other)) { return; }

        isPlayerNearby = false;

        // プレイヤーが範囲から出たときの個別処理を実行
        OnPlayerExit(other.gameObject);
    }

    //=====================================================================
    // 入力処理
    //=====================================================================

    void Update()
    {
        if(!isPlayerNearby) { return; }

        // インタラクトキーが押されたときに処理を呼び出す
        if(Keyboard.current[interactKeyInput].wasPressedThisFrame)
        {
            Interact();
        }
    }

    //=====================================================================
    // プレイヤータグのオブジェクトかを調べる関数
    //=====================================================================

    public bool IsPlayerTag(Collider2D other)
    {
        return other.CompareTag("Player");
    }

    //=====================================================================
    // 仮想関数
    //=====================================================================

    /// <summary>
    /// 個別のインタラクト処理を実装する純粋仮想関数（必ず継承先で実装しなければいけない）
    /// </summary>
    protected abstract void Interact();

    /// <summary>
    /// プレイヤーが範囲に入ったときに呼ばれる仮想関数（継承先で必要なら使う）
    /// </summary>
    protected virtual void OnPlayerEnter(GameObject other) { }

    /// <summary>
    /// プレイヤーが範囲から出たときに呼ばれる仮想関数（継承先で必要なら使う）
    /// </summary>
    protected virtual void OnPlayerExit(GameObject exitedPlayer) { }
}
