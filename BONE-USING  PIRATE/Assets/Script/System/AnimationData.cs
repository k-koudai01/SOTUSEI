using System.Collections;
using UnityEngine;

[System.Serializable]
public class AnimationData
{
    //==========================================
    // 変数
    // ==========================================
    [SerializeField] private string stateName;
    [SerializeField] private float speed = 1.0f;

    private int stateHash;

    //==========================================
    // プロパティ
    // ==========================================
    public int StateHash => stateHash;
    public float Speed => speed;
    //==========================================
    // 関数
    // ==========================================

    public void Initialize()
    {
        //　AnimatorのStateの名前をHash化して、stateHashに格納する。
        stateHash = Animator.StringToHash(stateName);
    }
}