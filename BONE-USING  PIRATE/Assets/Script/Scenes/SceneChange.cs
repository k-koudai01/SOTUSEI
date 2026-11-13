/*********************************************************************/
// * \file   SceneChange.cs
// * \brief  シーン遷移クラス
// *
// * \author 成田悠真
/*********************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移クラス
/// </summary>
public class SceneChange : MonoBehaviour
{
    // 遷移先のシーン名をInspectorで設定できるようにする
    [SerializeField]
    private string sceneName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // プレイヤーと衝突した場合にシーンを変更する
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeScene(sceneName);
        }
    }

    /// <summary>
    /// シーンを変更するメソッド
    /// </summary>
    /// <param name="sceneName"></param>
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
