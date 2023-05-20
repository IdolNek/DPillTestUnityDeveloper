namespace Assets.Scripts.Infrastructure.StateMachine
{
    public interface IPayLoadedState<TPayLoad> : IExitAbleState
    {
        void Enter(TPayLoad payLoad);
    }
}