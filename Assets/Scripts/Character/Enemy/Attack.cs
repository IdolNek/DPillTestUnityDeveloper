using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private AnimatorBase _animator;
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

        public void DoDamage(Health character)
        {
            if (_currentAttackCountDown < _attackCountDown) return;
            character.TakeDamage(_damage);
            _animator.Attack();
            _currentAttackCountDown = 0;
        }
    }
}