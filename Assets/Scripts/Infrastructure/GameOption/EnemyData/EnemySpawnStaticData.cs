using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.EnemyData
{
    [CreateAssetMenu(fileName = "EnemySpawnerData", menuName = "StaticData/EnemySpawner")]
    public class EnemySpawnStaticData: ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        public int MaxEnemyCount;
        public int EnemyInOneWave;
        public float TimeBetweenSpawn;
        public GameObject SpawnPrefab;
    }
}
