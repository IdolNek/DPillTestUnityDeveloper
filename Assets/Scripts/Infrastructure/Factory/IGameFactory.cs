using Assets.Scripts.Infrastructure.GameOption.EnemyData;
using Assets.Scripts.Infrastructure.Services;
using Assets.Scripts.SpawnPool;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        EnemySpawner Spawner { get; }
        GameObject Player { get; }

        GameObject CreateEnemy(EnemyTypeId enemyTypeId);
        GameObject CreateHero(Vector3 at);
        GameObject CreateHud();
        void CreateSpawner(EnemySpawnStaticData enemySpawnerStaticData);
        GameObject CreatePlayerBaseTrigger(Vector3 playerBaseCenter, Vector3 playerBaseSize);
        GameObject CreateBullet();
    }
}