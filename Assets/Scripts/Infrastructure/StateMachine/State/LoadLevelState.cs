using Assets.Scripts.CameraLogic;
using Assets.Scripts.Infrastructure.GameFactory;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.UIFactory;
using UnityEngine;

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
            //var hero = _gameFactory.CreateHero(GameObject.FindWithTag(_initialPointTag));
            //_gameFactory.CreateHud();
            //CameraFollow(hero);
            //InitSpawners();
            _uiFactory.CreateUIRoot();
            _stateMachine.Enter<GameLoopState>();
        }

        //private void InitSpawners()
        //{
        //    // string sceneKey = SceneManager.GetActiveScene().name;
        //    LevelStaticData levelStaticData = _staticDataService.ForLevel(LevelKey.LevelOne);
        //    foreach (EnemySpawnerData spawnerData in levelStaticData.EnemySpawners)
        //    {
        //        _gameFactory.CreateSpawner(spawnerData);
        //    }
        //}

        private static void CameraFollow(GameObject hero)
        {
            Camera.main.GetComponent<CameraFollow>().Follow(hero);
        }
    }
}