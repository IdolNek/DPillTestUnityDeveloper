using UnityEngine;

namespace Assets.Scripts.Infrastructure.GameOption.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/Player")]
    public class PlayerStaticData : ScriptableObject
    {
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

        public GameObject PlayerPrefab;
        public GameObject BulletPrefab;
    }
}
