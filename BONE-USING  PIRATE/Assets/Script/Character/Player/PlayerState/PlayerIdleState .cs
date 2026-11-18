using System.Collections;
using UnityEngine;

namespace Assets.Script.Character.Player.PlayerState
{
    public class PlayerIdleState : PlayerState
    {
        public PlayerIdleState(PlayerStateMachine stateMachine)
             : base(stateMachine)
        {

        }

        public override void Enter()
        {
            //Debug.Log("現在IdleState");
            stateMachine.Animation.SetIdle();
        }

        public override void Update()
        {
            // ジャンプ入力
            if(stateMachine.Input.GetJumpInput() &&
               stateMachine.Movement.IsGrounded)
            {
                stateMachine.ChangeState
                (
                    stateMachine.JumpState
                );

                return;
            }


            // 移動入力
            if(stateMachine.Movement.MoveDirection != UnityEngine.Vector2.zero)
            {
                stateMachine.ChangeState
                (
                    stateMachine.MoveState
                );
            }
        }

        public override void Exit()
        {
            
        }
    }
}