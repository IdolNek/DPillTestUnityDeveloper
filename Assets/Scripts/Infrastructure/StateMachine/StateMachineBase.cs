using Assets.Scripts.Infrastructure.Services;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public abstract class StateMachineBase : IStateMachineBase
    {
        protected Dictionary<Type, IExitAbleState> _states;
        protected IExitAbleState _activeState;

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }
        protected TState ChangeState<TState>() where TState : class, IExitAbleState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitAbleState =>
            _states[typeof(TState)] as TState;
    }
}
