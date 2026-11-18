using UnityEngine;

/// <summary>
/// アクティブ化可能なオブジェクトのインターフェース
/// </summary>
/// 
/// レバーのオンオフ機能をつけるオブジェクトにつける。
/// 
/// 継承とはまた別。
/// 
/// 使い方は、SwitchDoorControllerクラスをみるとわかる。
public interface IActivatable
{
    void Activate();
}
