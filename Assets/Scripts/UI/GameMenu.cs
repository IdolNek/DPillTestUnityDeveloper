using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.Infrastructure.StateMachine.State;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class GameMenu : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;
        private IGameFactory _gameFactory;

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        private void Awake()
        {
            _exitButton.onClick.AddListener(ExitGameMenu);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            _gameFactory.ResetPlayer();
            ExitGameMenu();
        }

        private void ExitGameMenu() => 
            gameObject.SetActive(false);

        private void OnEnable() =>
            Time.timeScale = 0f;
        private void OnDisable() => 
            Time.timeScale = 1f;
    }
}