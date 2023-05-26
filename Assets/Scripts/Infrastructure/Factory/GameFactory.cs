using Assets.Scripts.Character;
using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Character.Player;
using Assets.Scripts.Character.Player.Weapon;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.GameOption.LevelData;
using Assets.Scripts.Infrastructure.GameOption.Player;
using Assets.Scripts.Infrastructure.Services.Asset;
using Assets.Scripts.Infrastructure.Services.Input;
using Assets.Scripts.Infrastructure.Services.PlayerProgress;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.Services.Windows;
using Assets.Scripts.SpawnPool;
using Assets.Scripts.UI;
using UnityEngine;
using UnityEngine.AI;
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
            PlayerStaticData playerData = _staticData.PlayerConfig;
            _player = Object.Instantiate(playerData.PlayerPrefab, at, Quaternion.identity);
            MovePlayer movePlayer = _player.GetComponent<MovePlayer>();
            movePlayer.Construct(_inputService);
            movePlayer.Initialize(playerData.MoveSpeed);
            _player.GetComponent<PlayerHealth>().Initialize(playerData.Hp);
            _player.GetComponentInChildren<BulletSpawner>().Construct(this);
            _player.GetComponentInChildren<PlayerWeapon>().Initialize(playerData.AttackCountDown);
            _player.GetComponentInChildren<PlayerTrigger>().Initialize(playerData.AttackRange);
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
            enemy.GetComponent<Health>().Initialize(enemydata.Hp);
            enemy.GetComponent<Attack>().Initialize(enemydata.Damage, enemydata.AttackCountDown);
            enemy.GetComponentInChildren<EnemyTrigger>().Initialize(enemydata.AttackRange);
            enemy.GetComponent<NavMeshAgent>().speed = enemydata.MoveSpeed;
            enemy.GetComponent<GenerateRandomPointInAttackArea>().Initialize(levelData.EnemySpawnAreaCenter
                , levelData.EnemySpawnAreaSize);
            return enemy;
        }

        public GameObject CreatePlayerBaseTrigger(Vector3 playerBaseCenter, Vector3 playerBaseSize)
        {
            GameObject basetrigger = _asset.Instantiate(AssetPath.BaseTrigger, playerBaseCenter);
            basetrigger.GetComponent<BoxCollider>().size = playerBaseSize;
            return basetrigger;
        }

        public GameObject CreateBullet()
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            GameObject bullet = Object.Instantiate(playerData.BulletPrefab);
            bullet.GetComponent<Bullet>().Initialize(playerData.Damage);
            return bullet;
        }
    }
}