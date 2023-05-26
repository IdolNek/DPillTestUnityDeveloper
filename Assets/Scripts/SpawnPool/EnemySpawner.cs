using Assets.Scripts.Character.Enemy;
using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public class EnemySpawner : EnemySpawnPool
    {
        private int _countEnemyToSpawn;
        private float _timeBetweenSpawn;
        private float _currentTimeBetweenSpawn;
        

        public void Initialize()
        {
            _countEnemyToSpawn = _enemySpawnStaticData.EnemyInOneWave;
            _timeBetweenSpawn = _enemySpawnStaticData.TimeBetweenSpawn;
        }
        private void Update()
        {
            if (_enemySpawnStaticData == null) return;
            _currentTimeBetweenSpawn += Time.deltaTime;
            if (_currentTimeBetweenSpawn < _timeBetweenSpawn) return;
            SpawnWave();
        }

        private void SpawnWave()
        {
            for (int i = 0; i < _countEnemyToSpawn; i++)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            if (TryGetObject(out GameObject enemy))
            {
                enemy.transform.position = enemy.GetComponent<GenerateRandomPointInAttackArea>().GetRandomPointInAttackArea();
                enemy.GetComponent<EnemyHealth>().ResetHP();
                enemy.SetActive(true);
            }
        }
    }
}
