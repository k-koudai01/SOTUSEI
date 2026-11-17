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

        //=====================================================================
        // 各コンポーネント
        //=====================================================================
        public PlayerMovement Movement { get; private set; }
        public PlayerInput Input { get; private set; }
        public PlayerAnimation Animation { get; private set; }

        //=====================================================================
        // 各State
        //=====================================================================
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerJumpState JumpState { get; private set; }
        public PlayerFallState FallState { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();
            Input = GetComponent<PlayerInput>();
            Animation = GetComponent<PlayerAnimation>();

            if(Movement == null || Input == null || Animation == null)
            {
                Debug.LogError
                (
                    "Playerに必要なコンポーネントがありません。",
                    this
                );

                enabled = false;
                return;
            }

            // Stateの生成
            IdleState = new PlayerIdleState(this);
            MoveState = new PlayerMoveState(this);
            JumpState = new PlayerJumpState(this);
            FallState = new PlayerFallState(this);
        }

        private void Start()
        {
            ChangeState(IdleState);
        }

        private void Update()
        {
            //　入力の更新
            Movement.SetMoveDirection(Input.GetMoveInput());

            currentState?.Update();
        }

        private void FixedUpdate()
        {
            currentState?.FixedUpdate();
        }

        /// <summary>
        /// 新しい状態に変更するメソッド
        /// @param newState 新しい状態
        /// </summary>
        public void ChangeState(PlayerState newState)
        {
            if(newState == null || currentState == newState)
            {
                return;
            }

            currentState?.Exit();

            currentState = newState;

            currentState.Enter();
        }

    }
}
