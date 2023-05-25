using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private string _levelKey;
        [SerializeField] private Vector3 _initialHeroPosition;
        [Header("EnemySpawnArea")]
        [SerializeField] private Vector3 _center;
        [SerializeField] private Vector3 _size;
        [Header("PlayerBaseArea")]
        [SerializeField] private Vector3 _centerArea;
        [SerializeField] private Vector3 _sizeArea;

        public string LevelKey => _levelKey;
        public Vector3 InitialHeroPosition => _initialHeroPosition;

        public Vector3 EnemySpawnAreaCenter => _center;
        public Vector3 EnemySpawnAreaSize => _size;

        public Vector3 PlayerBaseCenter => _centerArea; 
        public Vector3 PlayerBaseSize => _sizeArea; 

        public void SetEnemySpawnArea(Vector3 position, Vector3 localScale)
        {
            _center = position;
            _size = localScale;
        }

        public void SetInitialPlayerPosition(Vector3 position) => 
            _initialHeroPosition = position;

        public void SetLevelKey(string name) => 
            _levelKey = name;

        public void SetPlayerBaseArea(Vector3 position, Vector3 localScale)
        {
            _centerArea = position;
            _sizeArea = localScale;
        }
    }
}