using Assets.Script.Character.Player.PlayerSystem;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.XR;

namespace Assets.Script.Character.Player.PlayerState
{
    public class PlayerStateMachine : PlayerBase
    {
        private PlayerState currentState;

        // この書き方は、PlayerStateMachineクラスの外部から
        // Movementプロパティを取得することができるようにするためのものです。
        //
        // C++でいうところの「getter」に相当します。
        public PlayerMovement Movement { get; private set; }
        public PlayerInput Input { get; private set; }
        public PlayerAnimation Animation { get; private set; }

        private void Awake()
        {
            Movement  = GetComponent<PlayerMovement>();
            Input     = GetComponent<PlayerInput>();
            Animation = GetComponent<PlayerAnimation>();

            if (Movement == null)
            {
                Debug.LogError("PlayerMovementが見つかりません。", this);
            }
            if (Input == null)
            {
                Debug.LogError("PlayerInputが見つかりません。", this);
            }
            if (Animation == null)
            {
                Debug.LogError("PlayerAnimationが見つかりません。", this);
            }

        }

        private void Start()
        {
            ChangeState(new PlayerIdleState(this));
        }

        private void Update()
        {
            currentState?.Update();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        public void ChangeState(PlayerState newState)
        {
            if(newState == null) return;

            // 現在の状態を終了し、新しい状態に切り替える
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

    }
}
