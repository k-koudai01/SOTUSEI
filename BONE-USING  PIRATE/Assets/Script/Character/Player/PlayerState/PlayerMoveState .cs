using Assets.Script.Character.Player.PlayerState;
using UnityEngine;

namespace Assets.Script.Character.Player.PlayerState
{
    public class PlayerMoveState : PlayerState
    {
        public PlayerMoveState(PlayerStateMachine stateMachine)
            : base(stateMachine)
        {
        }

        public override void Enter()
        {
            //Debug.Log("現在MoveState");
             stateMachine.Animation.SetDirection
             (
                 stateMachine.Movement.MoveDirection
             );
        }

        public override void Update()
        {
           if(stateMachine.Input.GetJumpInput() &&
              stateMachine.Movement.IsGrounded)
           {
                stateMachine.ChangeState
                (
                    stateMachine.JumpState 
                );

                return;
           }

           if(stateMachine.Movement.MoveDirection == Vector2.zero)
           {
                stateMachine.ChangeState
                (
                    stateMachine.IdleState
                );
           }
        }

        public override void Exit()
        {
            // 移動状態から抜けるときの処理
        }
    }
}