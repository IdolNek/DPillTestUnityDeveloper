using Assets.Scripts.CameraScripts;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.UI.Factory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.StateMachine.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIFactory _uiFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader
            , IGameFactory gameFactory, IStaticDataService staticDataService
            , IUIFactory uiFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _staticDataService = staticDataService;
            _uiFactory = uiFactory;
        }

        public void Enter(string sceneName)
        {
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            LevelStaticData leveldata = _staticDataService.ForLevel(SceneManager.GetActiveScene().name);
            GameObject hero = _gameFactory.CreateHero(leveldata.InitialHeroPosition);
            _gameFactory.CreateHud();
            CameraFollow(hero);
            InitializeEnemySpawner();
            _uiFactory.CreateUIRoot();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InitializeEnemySpawner()
        {
            EnemySpawnStaticData enemySpawnerStaticData = _staticDataService.ForSpawn(EnemyTypeId.Enemy);
            _gameFactory.CreateSpawner(enemySpawnerStaticData);
        }

        private static void CameraFollow(GameObject hero) => 
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
    }
}