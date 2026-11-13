/*********************************************************************/
// * \file   MenuManager.cs
// * \brief  メニュー処理管理クラス
// *
// * \author 石森虹大
/*********************************************************************/

using System.Collections;
using UnityEngine;

namespace Assets.Script.System
{
    /// <summary>
    /// メニュー処理管理クラス
    /// </summary>
    public class MenuManager : MonoBehaviour
    {
        ///<summary>
        ///ゲームを終了する処理
        ///</summary>
        public void CloseGame()
        {
            Debug.Log("ゲームを終了します");
            Application.Quit();
        }
    }
}