/*********************************************************************/
// * \file   BoneInventory.cs
// * \brief  骨の所持数を管理するクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System;

/// <summary>
/// 骨の所持数を管理するクラス
/// </summary>

/// Serializableはクラスをシリアライズ可能にする
[Serializable]
public class BoneInventory
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [SerializeField]
    private int boneCount = 0;

    [SerializeField]
    private int maxBoneCount = 60;

    //=====================================================================
    // プロパティ
    //=====================================================================

    public int BoneCount => boneCount;

    //=====================================================================
    // 所持数変更関数
    //=====================================================================

    public void AddBone(int amount)
    {
        boneCount += amount;
        if(boneCount > maxBoneCount)
        {
            boneCount = maxBoneCount;
        }
    }

    public void RemoveBone(int amount)
    {
        boneCount -= amount;
        if(boneCount < 0)
        {
            boneCount = 0;
        }
    }
}
