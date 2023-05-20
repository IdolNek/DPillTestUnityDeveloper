using Assets.Scripts.Infrastructure.GameFactory;
using Assets.Scripts.Infrastructure.Services.AssetManagement;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.ServiceLocater;
using Assets.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.StateMachine.State
{
    public class BootStrapState : IState
    {
        private const string _initialScene = "Initial";
        private const string _gameScene = "GameScene";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootStrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(_initialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(_gameScene);
        }

        private void RegisterServices()
        {
            _allServices.RegisterSingle<IInputService>(InputService());

            RegisterStaticData();

            _allServices.RegisterSingle<IAssetProvider>(new AssetProvider());

            _allServices.RegisterSingle<IPersistentProgressService>(
                new PersistentProgressService());


            _allServices.RegisterSingle<IGameFactory>(
                new GameFactory(_allServices.Single<IAssetProvider>()
                    , _allServices.Single<IStaticDataService>()
                    , _allServices.Single<IPersistentProgressService>()
                    , _allServices.Single<ITimerEventSystem>()));


            //_allServices.RegisterSingle<IUIFactory>(new UIFactory(_allServices.Single<IAssetProvider>()
            //, _allServices.Single<IStaticDataService>()
            //, _allServices.Single<IPlayerUpgradeService>()));

            //_allServices.RegisterSingle<IWindowsService>(new WindowsService(_allServices.Single<IUIFactory>()));

        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadStaticData();
            _allServices.RegisterSingle<IStaticDataService>(staticData);
        }

        private IInputService InputService()
        {
            if (Application.isEditor)
                return new StandaloneInputService();
            else
                return new MobileInputService();
        }
    }
}