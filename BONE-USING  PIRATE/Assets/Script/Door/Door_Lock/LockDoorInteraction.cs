/*********************************************************************/
// * \file   LockDoorInteraction.cs
// * \brief  鍵付きドアを調べるためのクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// 鍵付きドアを調べるためのクラス
/// </summary>
[RequireComponent(typeof(LockDoorOnColor))]
public class LockDoorInteraction : Interactable
{
    //==========================================================
    // 変数宣言
    //==========================================================

    [Header("ドアの設定")]
    [SerializeField]
    private LockDoorOnColor lockDoor;

    //==========================================================
    // インタラクト処理
    //==========================================================

    protected override void Interact()
    {
        if(lockDoor.IsOpen) { return; }

        // 対応する色の鍵を持っているか確認
        if(InventoryManager.Instance.HasKey(lockDoor.DoorColor))
        {
            // 鍵を1つ消費
            InventoryManager.Instance.UseKey(lockDoor.DoorColor);

            // ドアを開く
            lockDoor.OpenDoor();
        }
        else
        {
            Debug.Log("対応する鍵を持っていません");
        }
    }
}
