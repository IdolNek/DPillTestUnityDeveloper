using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public class EnemySpawnPool : Pool
    {
        private IGameFactory _gameFactory;
        private EnemyTypeId _enemyTypeId;
        private int _poolCount;
        protected EnemySpawnStaticData _enemySpawnStaticData;

        public void Construct(IGameFactory gameFactory, EnemySpawnStaticData enemySpawnerStaticData)
        {
            _enemySpawnStaticData = enemySpawnerStaticData;
            _gameFactory = gameFactory;
            _enemyTypeId = _enemySpawnStaticData.EnemyTypeId;
            _poolCount = _enemySpawnStaticData.MaxEnemyCount;
            InitializePool();

        }
        protected override void InitializePool()
        {
            for (int i = 0; i < _poolCount; i++)
            {
                GameObject spawned = _gameFactory.CreateEnemy(_enemyTypeId);
                AddToPool(spawned);
            }
        }
    }
}