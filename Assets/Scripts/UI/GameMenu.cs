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
        private GameStateMachine _stateMachine;

        public void Construct(GameStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Awake()
        {
            _exitButton.onClick.AddListener(ExitGameMenu);
            _restartButton.onClick.AddListener(RestartGame);
        }

        private void RestartGame()
        {
            ExitGameMenu();
            //string ActiveScene = SceneManager.GetActiveScene().name;
            //_stateMachine.Enter<LoadLevelState, string>(ActiveScene);
        }

        private void ExitGameMenu() => 
            gameObject.SetActive(false);

        private void OnEnable() =>
            Time.timeScale = 0f;
        private void OnDisable() => 
            Time.timeScale = 1f;
    }
}