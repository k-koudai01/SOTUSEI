/*********************************************************************/
// * \file   RockFalling.cs
// * \brief  岩を落下させるクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// 岩を落下させるクラス
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class RockFalling : ObjectBase
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    [Header("物理設定")]
    [SerializeField]
    private float gravityScale = 0.5f;

    [SerializeField]
    private float initialVelocity = 0f;

    private Rigidbody2D rb;

    private bool isActivated;

    //=====================================================================
    // 初期化処理
    //=====================================================================

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    //=====================================================================
    // 岩の発動処理
    //=====================================================================

    public void Activate()
    {
        if(isActivated) { return; }

        isActivated = true;

        rb.gravityScale = gravityScale;

        rb.linearVelocity = Vector2.down * initialVelocity;
    }
}
