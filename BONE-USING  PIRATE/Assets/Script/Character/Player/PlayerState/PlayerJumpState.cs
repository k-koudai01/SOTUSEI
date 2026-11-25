using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Assets.Script.Character.Player.PlayerState
{
    public class PlayerJumpState : PlayerState
    {
        public PlayerJumpState(PlayerStateMachine StateMachine) 
            : base(StateMachine)
        {

        }

        public override void Enter()
        {
            //Debug.Log("現在JumpState");

            stateMachine.Movement.Jump();

        }

        public override void Update()
        {

            if(stateMachine.Movement.VerticalVelocity <= 0.0f)
            {
                stateMachine.ChangeState
                (
                    stateMachine.FallState
                );
            }
        }
    }
}
