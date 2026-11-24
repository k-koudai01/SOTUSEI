/*********************************************************************/
// * \file   BoneInteraction.cs
// * \brief  骨を調べるためのクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// 骨を調べるためのクラス
/// </summary>
public class BoneInteraction : Interactable
{
    //==========================================================
    // 変数宣言
    //==========================================================

    [SerializeField]
    private int addBoneAmount = 1;

    //==========================================================
    // インタラクト処理
    //==========================================================

    protected override void Interact()
    {
        Debug.Log("骨を調べました。");

        InventoryManager.Instance.AddBone(addBoneAmount);
    }
}
