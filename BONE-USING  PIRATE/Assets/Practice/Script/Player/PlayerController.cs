using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;  // Rigidbody2D型の変数
    float axisH = 0.0f; // 入力

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

        //if(Keyboard.current.rightArrowKey.isPressed)
        //{
        //    axisH = 1.0f;
        //}
    }

    void FixedUpdate()
    {
        rbody.linearVelocity = new Vector2
        (
            axisH * 3.0f,
            rbody.linearVelocity.y
        );
    }
}
