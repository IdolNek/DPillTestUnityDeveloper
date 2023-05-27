using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.UI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private const string uiRootPath = "UI/UIRoot";
        private IGameFactory _gameFactory;
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData)
        {
            _asset = asset;
            _staticData = staticData;
        }
        public void Initialize(GameFactory gameFactory) =>
            _gameFactory = gameFactory;

        public void CreateGameMenuWindow()
        {
            WindowConfig windowConfig = _staticData.ForWindow(WindowsId.GameMenu);
            GameMenu window = Object.Instantiate(windowConfig.WindowPrefab, _uiRoot).GetComponent<GameMenu>();
            window.Construct(_gameFactory);
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(uiRootPath).transform;
    }
}