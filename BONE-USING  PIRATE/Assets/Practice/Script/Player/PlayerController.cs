using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;  // Rigidbody2D型の変数
    float axisH = 0.0f; // 入力
    public float speed = 3.0f; // 移動速度

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Rigidbody2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        axisH = Input.GetAxis("Horizontal");
        Move();
    }

    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2
        (
            axisH * speed,
            rbody.linearVelocity.y
        );
    }

    void Move()
    {
        if(axisH > 0.0f)
        {
            // 右移動
            Debug.Log("右移動");
            transform.localScale = new Vector2(1.0f, 1.0f);
        }
        else if(axisH < 0.0f)
        {
            // 左移動
            Debug.Log("左移動");
            transform.localScale = new Vector2(-1.0f, 1.0f);
        }
    }
}
