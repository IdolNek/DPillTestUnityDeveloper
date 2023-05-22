using Assets.Scripts.Infrastructure.GameOption.WindowsData;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progressService;
        private const string uiRootPath = "Ui/UIRoot";
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData
            , IProgressService persistentProgressService)
        {
            _asset = asset;
            _staticData = staticData;
            _progressService = persistentProgressService;
        }

        public void CreateWindow()
        {
            WindowConfig windowsConfig = _staticData.ForWindow(WindowsId.GameMenu);
            //ShopWindow window = Object.Instantiate(windowsConfig.Prefab, _uiRoot) as ShopWindow;
            //window.Construct(_adsService, _persistentProgressService);
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(uiRootPath).transform;
    }
}