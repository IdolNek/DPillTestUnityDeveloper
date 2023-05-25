using Assets.Scripts.Character;
using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Character.Player;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.Services.Windows;
using Assets.Scripts.SpawnPool;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {

        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private readonly IProgressService _progress;
        private readonly IWindowsService _windowService;
        private readonly IInputService _inputService;

        private GameObject _player;
        private EnemySpawner _spawner;

        public GameObject Player => _player;
        public EnemySpawner Spawner => _spawner;

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IWindowsService windowsService, IInputService inputService)
        {
            _asset = asset;
            _staticData = staticData;
            _progress = progress;
            _windowService = windowsService;
            _inputService = inputService;
        }

        public GameObject CreateHero(Vector3 at)
        {
            _player = _asset.Instantiate(AssetPath.PlayerPath, at);
            _player.GetComponent<MovePlayer>().Construct(_inputService);
            return _player;
        }

        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            hud.GetComponentInChildren<MoneyCounter>().Construct(_progress.Money);
            hud.GetComponentInChildren<OpenGameMenu>().Construct(_windowService);
            return hud;
        }

        public void CreateSpawner(EnemySpawnStaticData enemySpawnerStaticData)
        {
            _spawner = Object.Instantiate(enemySpawnerStaticData.SpawnPrefab).GetComponent<EnemySpawner>();
            _spawner.Construct(this, enemySpawnerStaticData);
            _spawner.Initialize();

        }

        public GameObject CreateEnemy(EnemyTypeId enemyTypeId)
        {
            EnemyStaticData enemydata = _staticData.ForEnemy(enemyTypeId);
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);
            GameObject enemy = Object.Instantiate(enemydata.EnemyPrefab);
            enemy.GetComponent<MoveEnemy>().Construct(_player.transform);
            enemy.GetComponent<Health>().Construct(enemydata.Hp);
            enemy.GetComponent<GenerateRandomPointInAttackArea>().Construct(levelData.EnemySpawnAreaCenter
                , levelData.EnemySpawnAreaSize);
            return enemy;
        }
    }
}