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
            Debug.Log("現在IdleState");
            stateMachine.Animation.SetIdle();
        }

        public override void Update()
        {
            // プレイヤーが移動している場合、Idle状態から別の状態に遷移する処理を追加することができます。
            if (stateMachine.Movement.MoveDirection != UnityEngine.Vector2.zero)
            {
                stateMachine.ChangeState
                (
                    new PlayerMoveState(stateMachine)
                );
            }
        }

        public override void Exit()
        {
            
        }
    }
}