using Assets.Scripts.Character;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.Services.Windows;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {

        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _persistentProgress;
        private readonly IWindowsService _windowService;
        private readonly IInputService _inputService;

        public GameObject player { get; set; }

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IWindowsService windowsService, IInputService inputService)
        {
            _asset = asset;
            _staticData = staticData;
            _persistentProgress = progress;
            _windowService = windowsService;
            _inputService = inputService;
        }

        public GameObject CreateHero(Vector3 at)
        {
            player = _asset.Instantiate(AssetPath.PlayerPath, at);
            player.GetComponent<MovePlayer>().Construct(_inputService);
            return player;
        }

        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            //hud.GetComponent<LootCounter>().Construct(_persistentProgress.PlayerProgress.WorldData);
            //foreach (OpenWindowButton openWindow in hud.GetComponentsInChildren<OpenWindowButton>())
            //    openWindow.Construct(_windowService);
            return hud;
        }

        //public LootPiece CreateLoot()
        //{
        //    LootPiece lootPiece = InstantiateRegistered(AssetAdress.LootPath).GetComponent<LootPiece>();
        //    lootPiece.Construct(_persistentProgress.PlayerProgress.WorldData);
        //    return lootPiece;
        //}

        //public void CreateSpawner(Vector3 at, string spawnerId, MonsterTypeID monsterTypeID)
        //{
        //    var spawner = InstantiateRegistered(AssetAdress.SpawnerPath, at).GetComponent<SpawnPoint>();
        //    spawner.Construct(this);
        //    spawner.Id = spawnerId;
        //    spawner.MonsterTypeID = monsterTypeID;
        //}
    }
}