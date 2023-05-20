using Assets.Scripts.Infrastructure.Services.AssetManagement;
using Assets.Scripts.Infrastructure.Services.PersistentProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Infrastructure.StaticData.WindowsData;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.UIFactory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _asset;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _persistentProgressService;
        private const string uiRootPath = "Ui/UIRoot";
        private Transform _uiRoot;

        public UIFactory(IAssetProvider asset, IStaticDataService staticData
            ,IPersistentProgressService persistentProgressService)
        {
            _asset = asset;
            _staticData = staticData;
            _persistentProgressService = persistentProgressService;
        }

        public void CreateShop()
        {
            WindowConfig windowsConfig = _staticData.ForWindow(WindowsId.GameMenu);
            //ShopWindow window = Object.Instantiate(windowsConfig.Prefab, _uiRoot) as ShopWindow;
            //window.Construct(_adsService, _persistentProgressService);
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(uiRootPath).transform;
    }
}