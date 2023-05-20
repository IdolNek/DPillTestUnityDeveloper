using Assets.Scripts.Infrastructure.StateMachine.State;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public class GameLoader : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        private void Awake()
        {
            _game = new Game(this);
            _game.GameStateMachine.Enter<BootStrapState>();
            DontDestroyOnLoad(this);
        }
    }
}