/*********************************************************************/
// * \file   RockTargetTrigger.cs
// * \brief  ターゲットの位置から岩を移動させるクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// ターゲットの位置から岩を移動させるクラス
/// </summary>
public class RockTargetTrigger : ObjectBase
{
    //==========================================================
    // 変数宣言
    //==========================================================

    [SerializeField]
    private RockController rockController;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float triggerDistance = 0.1f;

    private bool isTriggered;

    //==========================================================
    // 更新処理
    //==========================================================

    private void Update()
    {
        if(isTriggered) { return; }

        float distance = Mathf.Abs(transform.position.x - target.position.x);

        if(distance <= triggerDistance)
        {
            isTriggered = true;
            rockController.Activate();
        }
    }
}
