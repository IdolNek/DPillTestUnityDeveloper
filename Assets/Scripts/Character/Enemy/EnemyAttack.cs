using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        private int _damage;
        private float _attackCountdown;
        private float _attackRange;
        private float _currentCountdown;

        public void Construct(int damage, float attackRange, float attackCountdown)
        {
            _damage = damage;
            _attackCountdown = attackCountdown;
            _attackRange = attackRange;
        }
        private void OnTriggerStay(Collider other)
        {
            if (_currentCountdown > 0) return;
            if (other.TryGetComponent<Health>(out Health health))
                Attack(health);
        }

        private void Attack(Health health)
        {
            health.TakeDamage(_damage);
            _currentCountdown = _attackCountdown;
        }
    }
}