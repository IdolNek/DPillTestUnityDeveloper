namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IState : IExitAbleState
    {
        void Enter();
    }
}