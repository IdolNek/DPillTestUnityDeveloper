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
using Assets.Scripts.Infrastructure.UI.Factory;
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
        private readonly IWindowsService _windowsService;
        private readonly IInputService _inputService;
        private readonly IUIFactory _uIFactory;
        private GameObject _player;
        private EnemySpawner _spawner;

        public GameObject Player => _player;
        public EnemySpawner Spawner => _spawner;

        public GameFactory(IAssetService asset, IStaticDataService staticData,
            IProgressService progress, IWindowsService windowsService, IInputService inputService, IUIFactory uIFactory)
        {
            _asset = asset;
            _staticData = staticData;
            _progress = progress;
            _windowsService = windowsService;
            _inputService = inputService;
            _uIFactory = uIFactory;
            InitializaUIFactory();
        }

        private void InitializaUIFactory() => 
            _uIFactory.Initialize(this);

        public GameObject CreateHero(Vector3 at)
        {
            PlayerStaticData playerData = _staticData.PlayerConfig;
            _player = Object.Instantiate(playerData.PlayerPrefab, at, Quaternion.identity);
            MovePlayer movePlayer = _player.GetComponent<MovePlayer>();
            movePlayer.Construct(_inputService);
            movePlayer.Initialize(playerData.MoveSpeed);
            _player.GetComponent<PlayerHealth>().Initialize(playerData.Hp);
            _player.GetComponent<MoneyCollector>().Construct(_progress);
            _player.GetComponent<PlayerDeath>().Construct(_windowsService);
            _player.GetComponentInChildren<BulletSpawner>().Construct(this);
            _player.GetComponentInChildren<PlayerWeapon>().Initialize(playerData.AttackCountDown);
            _player.GetComponentInChildren<PlayerAttackTrigger>().Initialize(playerData.AttackRange);
            return _player;
        }
        public void ResetPlayer()
        {
            LevelStaticData levelData = _staticData.ForLevel(SceneManager.GetActiveScene().name);
            _player.GetComponent<CharacterController>().enabled = false;
            _player.transform.position = levelData.InitialHeroPosition;
            _player.GetComponent<CharacterController>().enabled = true;
            _player.GetComponent<PlayerHealth>().ResetHP();
            _player.GetComponent<MoneyCollector>().ResetMoneyBank();
        }

        public GameObject CreateHud()
        {
            GameObject hud = _asset.Instantiate(AssetPath.HUDPath);
            hud.GetComponentInChildren<MoneyCounter>().Construct(_progress.Money);
            hud.GetComponentInChildren<OpenGameMenu>().Construct(_windowsService);
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
            MoneySpawn moneySpawn = enemy.GetComponent<MoneySpawn>();
            moneySpawn.Initialize(enemydata.MoneyCount);
            moneySpawn.Construct(this);
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

        public GameObject CreateMoney(Vector3 position)
        {
            var money = _asset.Instantiate(AssetPath.Money, position);
            return money;
        }        
    }
}