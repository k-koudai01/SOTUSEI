/*********************************************************************/
// * \file   Impactable.cs
// * \brief  衝突を検知するためのクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System;

/// <summary>
/// 衝突を検知するためのクラス
/// </summary>
public class Impactable : MonoBehaviour
{
    //=====================================================================
    // イベント宣言
    //=====================================================================

    public event Action<Collider2D> OnImpacted;

    //=====================================================================
    // 衝突イベント
    //=====================================================================

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(IsPlayerTag(collision))
    //    {
    //        // プレイヤーとの衝突を検知した場合、イベントを発火
    //        OnImpacted?.Invoke(collision);
    //    }
    //    else
    //    {
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsPlayerTag(collision))
        {
            // プレイヤーとの衝突を検知した場合、イベントを発火
            OnImpacted?.Invoke(collision);
        }
        else if(IsGroundTag(collision))
        {
            
        }
    }

    //=====================================================================
    // タグ判定
    //=====================================================================

    public bool IsPlayerTag(Collider2D collision)
    {
        return collision.gameObject.CompareTag("Player");
    }

    public bool IsGroundTag(Collider2D collider)
    {
        return collider.gameObject.CompareTag("Ground");
    }
}
