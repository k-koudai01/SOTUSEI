/*********************************************************************/
// * \file   SwitchController.cs
// * \brief  スイッチドア制御クラス
// *
// * \author 成田悠真
/*********************************************************************/

using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// スイッチよって制御されるドアクラス
/// </summary>
public class SwitchDoorController : ObjectBase, IActivatable
{
    //=====================================================================
    // 変数宣言
    //===================================================================== 

    [SerializeField]
    private DoorMovement doorMovement;

    [Header("ドアが移動してから閉じるまでの時間")]
    [SerializeField]
    private float openDuration = 3f;

    private Coroutine closeCoroutine;

    //=====================================================================
    // ドアの開閉処理
    //=====================================================================

    public void Activate()
    {
        if (closeCoroutine != null)
        {
            StopCoroutine(closeCoroutine);
        }

        // ドアを開く処理を開始
        closeCoroutine = StartCoroutine(AutoClose());
    }

    private IEnumerator AutoClose()
    {
        // ドアが開き終わるまで待機
        yield return doorMovement.Open();

        // 開き終わってから指定時間待機
        yield return new WaitForSeconds(openDuration);

        // ドアが閉じ終わるまで待機
        yield return doorMovement.Close();

        closeCoroutine = null;
    }
}
