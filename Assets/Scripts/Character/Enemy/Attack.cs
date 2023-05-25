using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private EnemyAnimator _enemyAnimator;
        private float _damage;
        private float _attackCountDown;
        private float _currentAttackCountDown;
        public void Initialize(int damage, float attackCountDown)
        {
            _damage = damage;
            _attackCountDown = attackCountDown;
        }
        private void Update()
        {
            _currentAttackCountDown += Time.deltaTime;
        }

        public void DoDamage(PlayerHealth player)
        {
            if (_currentAttackCountDown < _attackCountDown) return;
            player.TakeDamage(_damage);
            _enemyAnimator.Attack();
            _currentAttackCountDown = 0;
        }
    }
}