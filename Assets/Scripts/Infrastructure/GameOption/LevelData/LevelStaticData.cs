using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private string _levelKey;
        [SerializeField] private Vector3 _initialHeroPosition;
        [SerializeField] private Vector3 _enemySpawnAreaCenter;
        [SerializeField] private Vector3 _enemySpawnAreaSize;

        public string LevelKey => _levelKey;
        public Vector3 InitialHeroPosition => _initialHeroPosition;

        public Vector3 EnemySpawnAreaCenter => _enemySpawnAreaCenter;
        public Vector3 EnemySpawnAreaSize => _enemySpawnAreaSize;

        public void SetEnemySpawnArea(Vector3 position, Vector3 localScale)
        {
            _enemySpawnAreaCenter = position;
            _enemySpawnAreaSize = localScale;
        }

        public void SetInitialPlayerPosition(Vector3 position) => 
            _initialHeroPosition = position;

        public void SetLevelKey(string name) => 
            _levelKey = name;
    }
}