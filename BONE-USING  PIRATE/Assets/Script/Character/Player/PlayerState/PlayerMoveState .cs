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
            Debug.Log("現在MoveState");
        }

        public override void Update()
        {
            if (stateMachine.Movement.MoveDirection == Vector2.zero)
            {
                stateMachine.ChangeState(
                    new PlayerIdleState(stateMachine)
                );
            }
        }

        public override void Exit()
        {
            // 移動状態から抜けるときの処理
        }
    }
}