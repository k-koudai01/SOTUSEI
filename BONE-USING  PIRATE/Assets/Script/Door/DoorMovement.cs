/*********************************************************************/
// * \file   DoorMovement.cs
// * \brief  ドアの動きを制御するクラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using System.Collections;

/// <summary>
/// ドアの動きを制御するクラス
/// </summary>
public class DoorMovement : ObjectBase
{
    //=====================================================================
    // ドアの位置モード
    //=====================================================================

    public enum PositionMode
    {
        Automatic,
        Manual
    }

    //=====================================================================
    // 変数宣言
    //=====================================================================

    [Header("移動対象")]
    [SerializeField]
    private Transform doorTransform;

    [Header("移動設定")]

    [SerializeField]
    private PositionMode positionMode = PositionMode.Automatic;

    [Header("ドアが移動する位置までの距離")]
    [SerializeField]
    private Vector3 openOffset;

    [Tooltip("ドアが開いた位置")]
    [SerializeField]
    private Vector3 openPosition;

    [Tooltip("ドアが閉じる位置")]
    [SerializeField]
    private Vector3 closePosition;

    [SerializeField]
    private float moveSpeed = 2f;

    //=====================================================================
    // 内部変数
    //=====================================================================

    private Vector3 initialPosition;

    private Coroutine moveCoroutine;

    //=====================================================================
    // 初期化処理
    //=====================================================================

    private void Awake()
    {
        if(doorTransform == null)
        {
            Debug.LogError("DoorTransformが設定されていません。", this);
            return;
        }

        // 最初の位置を取得
        initialPosition = doorTransform.localPosition;

        // 自動設定の場合
        if(positionMode == PositionMode.Automatic)
        {
            closePosition = initialPosition;
            openPosition = initialPosition + openOffset;
        }
    }

    //=====================================================================
    // ドアの開閉処理
    //=====================================================================

    public IEnumerator Open()
    {
        yield return StartMovement(openPosition);
    }

    public IEnumerator Close()
    {
        yield return StartMovement(closePosition);
    }

    //=====================================================================
    // 移動開始処理
    //=====================================================================

    private IEnumerator StartMovement(Vector3 target)
    {
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        // 移動が完了するまで待機
        yield return MoveDoor(target);
    }

    //=====================================================================
    // ドアの移動処理
    //=====================================================================

    private IEnumerator MoveDoor(Vector3 target)
    {
        while(Vector3.Distance(doorTransform.localPosition, target) > 0.01f)
        {
            doorTransform.localPosition = Vector3.MoveTowards(
                doorTransform.localPosition,
                target,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        doorTransform.localPosition = target;

        moveCoroutine = null;
    }
}
