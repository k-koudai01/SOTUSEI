/*********************************************************************/
// * \file   PressurePlateController.cs
// * \brief  感圧板の制御クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 感圧板の制御クラス
/// </summary>
public class PressurePlateController : MonoBehaviour
{
    //=================================================================
    // 変数宣言
    //=================================================================

    // HashSetとは、重複しない要素の管理するためのデータ構造です。
    // 配列やリストと異なり、HashSetは順序を保持しないため、要素の順序が重要でない場合に適しています。
    //
    // new() = new HashSet<Rigidbody2D>()
    private HashSet<Rigidbody2D> objectsOnPlate = new();

    //=================================================================
    // プロパティ
    //=================================================================

    public bool IsPressed => objectsOnPlate.Count > 0;

    //=================================================================
    // トリガー処理
    //=================================================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;

        if(rb != null) { objectsOnPlate.Add(rb); }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;

        if(rb != null) { objectsOnPlate.Remove(rb); }
    }
}