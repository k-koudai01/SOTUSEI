/*********************************************************************/
// * \file   InventoryManager.cs
// * \brief  インベントリの管理を行うクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// インベントリの管理を行うクラス
/// </summary>
public class InventoryManager : MonoBehaviour
{
    //=====================================================================
    // シングルトンのインスタンス
    //=====================================================================

    public static InventoryManager Instance { get; private set; }

    //=====================================================================
    // 変数宣言
    //=====================================================================

    [SerializeField]
    private BoneInventory boneInventory;

    [SerializeField]
    private KeyInventory keyInventory;

    //=====================================================================
    // プロパティ
    //=====================================================================

    public int BoneCount => boneInventory.BoneCount;

    public int RedKeyCount => keyInventory.RedKeyCount;

    public int BlueKeyCount => keyInventory.BlueKeyCount;

    public int GreenKeyCount => keyInventory.GreenKeyCount;

    //=====================================================================
    // 初期化処理
    //=====================================================================

    private void Awake()
    {
        // シングルトンの重複防止
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    //=====================================================================
    // 骨の管理関数
    //=====================================================================

    public void AddBone(int amount) { boneInventory.AddBone(amount); }

    public void RemoveBone(int amount) { boneInventory.RemoveBone(amount); }

    //=====================================================================
    // 鍵の管理関数
    //=====================================================================

    public void AddKey(KeyColor color) { keyInventory.AddKey(color); }

    public bool HasKey(KeyColor color) { return keyInventory.HasKey(color); }

    public void UseKey(KeyColor color) { keyInventory.UseKey(color); }
}
