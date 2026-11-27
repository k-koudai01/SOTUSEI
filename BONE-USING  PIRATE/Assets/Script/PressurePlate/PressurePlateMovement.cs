/*********************************************************************/
// * \file   PressurePlateMovement.cs
// * \brief  感圧板の動きを制御するクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;

/// <summary>
/// 感圧板の動きを制御するクラス
/// </summary>
[RequireComponent(typeof(PressurePlateController))]
public class PressurePlateMovement : MonoBehaviour
{
    //=================================================================
    // 変数宣言
    //=================================================================

    [Header("感圧板の設定")]

    [Tooltip("感圧板のTransform")]
    [SerializeField]
    private Transform plate;

    [Header("押し込みの設定")]

    [Tooltip("感圧板が押し込まれる深さ")]
    [SerializeField]
    private float pressDepth = 0.15f;

    [SerializeField]
    private float pressSpeed = 5f;

    private Vector3 originalPosition;

    private Vector3 pressedPosition;

    private PressurePlateController plateController;

    //=================================================================
    // プロパティ
    //=================================================================

    public float PressDepth => pressDepth;

    //=================================================================
    // 初期化
    //=================================================================

    private void Start()
    {
        plateController = GetComponent<PressurePlateController>();

        // 感圧板の初期位置と押された位置を計算
        originalPosition = plate.localPosition;
        pressedPosition = originalPosition + Vector3.down * pressDepth;
    }

    private void Update()
    {
        Vector3 targetPosition = plateController.IsPressed ? pressedPosition : originalPosition;

        // 感圧板の位置を滑らかに補間して移動
        plate.localPosition = Vector3.Lerp(
            plate.localPosition,
            targetPosition,
            Time.deltaTime * pressSpeed
        );
    }
}
