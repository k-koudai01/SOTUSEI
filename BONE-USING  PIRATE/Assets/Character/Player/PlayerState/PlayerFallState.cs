using System.Collections;
using UnityEngine;

namespace Assets.Character.Player.PlayerState
{
    public class PlayerFallState : PlayerState
    {
        public PlayerFallState(PlayerStateMachine stateMachine)
            : base(stateMachine)
        {

        }

        public override void Enter()
        {
            Debug.Log("現在FallState");
        }

        public override void Update()
        {
           if(stateMachine.Movement.IsGrounded)
           {
                if(stateMachine.Movement.MoveDirection !=
                   UnityEngine.Vector2.zero)
                {
                    stateMachine.ChangeState
                    (
                        stateMachine.MoveState
                    );
                }
                else
                {
                    stateMachine.ChangeState    
                    (
                        stateMachine.IdleState
                    );
                }
           }
        }
    }
}