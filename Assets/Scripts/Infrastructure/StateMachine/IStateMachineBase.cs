using Assets.Scripts.Infrastructure.Services;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IStateMachineBase : IService
    {
        void Enter<TState>() where TState : class, IState;
    }
}