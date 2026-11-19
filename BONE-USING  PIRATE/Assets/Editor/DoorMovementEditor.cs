/*********************************************************************/
// * \file   DoorMovementEditor.cs
// * \brief  ドアの動きを制御するクラスのカスタムエディタ
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEditor;
using static DoorMovement;

/// <summary>
/// ドアの動きを制御するクラスのカスタムエディタ
/// </summary>
[CustomEditor(typeof(DoorMovement))]
public class DoorMovementEditor : Editor
{
    //=====================================================================
    // 変数宣言
    //=====================================================================

    // SerializedPropertyは、UnityのInspectorで表示される変数を扱うためのクラスです。
    // これにより、Inspector上での変数の表示や編集が容易になります。

    private SerializedProperty doorTransform;

    private SerializedProperty positionMode;

    private SerializedProperty openOffset;

    private SerializedProperty openPosition;

    private SerializedProperty closePosition;

    private SerializedProperty moveSpeed;

    //=====================================================================
    // 初期化処理
    //=====================================================================

    private void OnEnable()
    {
        doorTransform = serializedObject.FindProperty("doorTransform");

        positionMode = serializedObject.FindProperty("positionMode");

        openOffset = serializedObject.FindProperty("openOffset");

        openPosition = serializedObject.FindProperty("openPosition");

        closePosition = serializedObject.FindProperty("closePosition");

        moveSpeed = serializedObject.FindProperty("moveSpeed");
    }

    //=====================================================================
    // Inspector表示処理
    //=====================================================================

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        // 移動対象
        EditorGUILayout.PropertyField(doorTransform);

        EditorGUILayout.Space();

        // 移動方式
        EditorGUILayout.PropertyField(positionMode);

        // 移動方式による表示切り替え
        PositionMode mode = (PositionMode)positionMode.enumValueIndex;

        // モードごとに、表示するプロパティを切り替える
        switch(mode)
        {
            case PositionMode.Automatic:
            {
                EditorGUILayout.PropertyField(openOffset);
                break;
            }

            case PositionMode.Manual:
            {
                EditorGUILayout.PropertyField(openPosition);
                EditorGUILayout.PropertyField(closePosition);
                break;
            }
        }

        EditorGUILayout.Space();

        // 移動速度は、常に表示する
        EditorGUILayout.PropertyField(moveSpeed);

        // 変更を反映
        serializedObject.ApplyModifiedProperties();
    }
}