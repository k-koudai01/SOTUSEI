using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Character.Player.PlayerState
{
    public abstract class PlayerState
    {
        protected PlayerStateMachine stateMachine;

        protected PlayerState(PlayerStateMachine StateMachine)
        {
            this.stateMachine = StateMachine;   
        }

        public virtual void Enter() {}

        public virtual void Update() {}

        public virtual void Exit() {}

        /// <summary>
        /// 物理演算のタイミングで呼ばれる
        /// </summary>
        public virtual void FixedUpdate() {}

    }
}
