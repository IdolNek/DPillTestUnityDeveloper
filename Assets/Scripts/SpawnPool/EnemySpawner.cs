using UnityEngine;

namespace Assets.Scripts.SpawnPool
{
    public class EnemySpawner : EnemySpawnPool
    {
        private int _countEnemyToSpawn;
        private float _timeBetweenSpawn;
        private float _currentTimeBetweenSpawn;
        private Vector3 _centerAreaSpawn;
        private Vector3 _sizeAreaSpawn;

        public void InitializeSpawnArea(Vector3 centerAreaSpawn, Vector3 sizeAreaSpawn)
        {
            _centerAreaSpawn = centerAreaSpawn;
            _sizeAreaSpawn = sizeAreaSpawn;
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
                enemy.transform.position = GetRandomSpawnPointInArea();
                enemy.SetActive(true);
            }
        }
        private Vector3 GetRandomSpawnPointInArea()
        {
            float minX = _centerAreaSpawn.x - (_sizeAreaSpawn.x / 2);
            float maxX = _centerAreaSpawn.x + (_sizeAreaSpawn.x / 2);
            float xRange = Random.Range(minX, maxX);
            float minY = _centerAreaSpawn.y - (_sizeAreaSpawn.y / 2); ;
            float maxY = _centerAreaSpawn.y + (_sizeAreaSpawn.y / 2); ;
            float yRange = Random.Range(minY, maxY); ;
            const float ground = 0.1f;
            return new Vector3(xRange, yRange, ground);
        }
    }
}
