using Assets.Scripts.Infrastructure.Services.ServiceLocater;
using Assets.Scripts.Infrastructure.StateMachine;

namespace Assets.Scripts.Infrastructure
{
    public class Game
    {
        private GameStateMachine _gameStateMachine;
        public GameStateMachine GameStateMachine => _gameStateMachine;

        public Game(ICoroutineRunner coroutineRunner) => 
            _gameStateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), new AllServices());

    }
}