/*********************************************************************/
// * \file   KeyInventory.cs
// * \brief  鍵の所持数を管理するクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System;

/// <summary>
/// 鍵の所持数を管理するクラス
/// </summary>
[Serializable]
public class KeyInventory
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [SerializeField]
    private int redKeyCount = 0;

    [SerializeField]
    private int blueKeyCount = 0;

    [SerializeField]
    private int greenKeyCount = 0;

    //=====================================================================
    // プロパティ
    //=====================================================================

    public int RedKeyCount => redKeyCount;

    public int BlueKeyCount => blueKeyCount;

    public int GreenKeyCount => greenKeyCount;

    //=====================================================================
    // 鍵の追加処理
    //=====================================================================

    public void AddKey(KeyColor color)
    {
        switch(color)
        {
            case KeyColor.Red:
            {
                redKeyCount++;
                break;
            }

            case KeyColor.Blue:
            {
                blueKeyCount++;
                break;
            }

            case KeyColor.Green:
            {
                greenKeyCount++;
                break;
            }
        }
    }

    //=====================================================================
    // 鍵の所持確認処理
    //=====================================================================

    public bool HasKey(KeyColor color)
    {
        switch(color)
        {
            case KeyColor.Red:
            {
                return redKeyCount > 0;
            }

            case KeyColor.Blue:
            {
                return blueKeyCount > 0;
            }   

            case KeyColor.Green:
            {
                return greenKeyCount > 0;
            }
        }

        return false;
    }

    //=====================================================================
    // 鍵の消費処理
    //=====================================================================

    public void UseKey(KeyColor color)
    {
        switch(color)
        {
            case KeyColor.Red:
            {
                if(redKeyCount > 0) { redKeyCount--; }
                break;
            }

            case KeyColor.Blue:
            {
                if(blueKeyCount > 0) { blueKeyCount--; }
                break;
            }

            case KeyColor.Green:
            {
                if(greenKeyCount > 0) { greenKeyCount--; }
                break;
            }
        }
    }
}
