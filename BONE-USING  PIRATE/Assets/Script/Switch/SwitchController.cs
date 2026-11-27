/*********************************************************************/
// * \file   SwitchController.cs
// * \brief  スイッチ制御クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ギミックのスイッチを制御するクラス
/// </summary>
public class SwitchController : ObjectBase
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [Header("起動対象")]
    [SerializeField]
    private List<MonoBehaviour> targets;

    //=====================================================================
    // スイッチのアクティベート処理
    //=====================================================================

    public void Activate()
    {
        foreach(MonoBehaviour target in targets)
        {
            if(target == null)
            {
                Debug.LogWarning("ターゲットが存在していない");
                continue;
            }

            if(target is IActivatable activatable)
            {
                Debug.Log($"{this.name}が{target.name}をアクティベートしました。");
                activatable.Activate();
            }
            else
            {
                Debug.LogWarning($"{target.name} IActivatableを実装していません。");
            }
        }
    }
}
