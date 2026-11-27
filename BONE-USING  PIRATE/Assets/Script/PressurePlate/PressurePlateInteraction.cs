/*********************************************************************/
// * \file   PressurePlateController.cs
// * \brief  感圧板の制御クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// 感圧板を調べたときの個別処理クラス
/// </summary>
public class PressurePlateInteraction : Interactable
{
    [Header("起動に必要な感圧板の震度")]
    [SerializeField]
    private float pressDepth = 0.2f;

    [SerializeField]
    private float currentDepth = 0f;

    //=====================================================================
    // インタラクト可能判定
    //=====================================================================

    protected override bool CanInteract()
    {
        return currentDepth >= pressDepth;
    }

    //=====================================================================
    // インタラクト処理
    //=====================================================================

    protected override void Interact()
    {
        Debug.Log("感圧板が起動しました");
    }
}
