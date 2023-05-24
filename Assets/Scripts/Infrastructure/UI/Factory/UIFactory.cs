using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly GameStateMachine _stateMachine;
        private const string uiRootPath = "UI/UIRoot";
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData, GameStateMachine stateMachine)
        {
            _asset = asset;
            _staticData = staticData;
            _stateMachine = stateMachine;
        }

        public void CreateGameMenuWindow()
        {
            WindowConfig windowConfig = _staticData.ForWindow(WindowsId.GameMenu);
            GameMenu window = Object.Instantiate(windowConfig.WindowPrefab, _uiRoot).GetComponent<GameMenu>();
            window.Construct(_stateMachine);
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(uiRootPath).transform;
    }
}