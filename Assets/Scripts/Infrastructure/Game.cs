using Assets.Scripts.Infrastructure.Services.ServiceLocater;
using Assets.Scripts.Infrastructure.StateMachine;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        public GameStateMachine GameStateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            GameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), AllServices.Container);
        }
    }
}