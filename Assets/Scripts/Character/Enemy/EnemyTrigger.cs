using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private Attack _attack;
        [SerializeField] private SphereCollider _sphereCollider;

        public void Initialize(float attackRange) => 
            _sphereCollider.radius = attackRange;

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent<PlayerHealth>(out PlayerHealth player))
                _attack.DoDamage(player);
        }

    }
}