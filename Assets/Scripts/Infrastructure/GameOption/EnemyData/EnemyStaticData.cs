using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.EnemyData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        [Range(1, 100)]
        public int Hp;
        [Range(1, 30)]
        public int Damage;
        [Range(0.5f, 100)]
        public float MoveSpeed;
        [Range(0.1f, 100)]
        public float AttackRange;
        [Range(0.1f, 5)]
        public float AttackCountDown;

        public int LootCount;

        public GameObject EnemyPrefab;
    }
}