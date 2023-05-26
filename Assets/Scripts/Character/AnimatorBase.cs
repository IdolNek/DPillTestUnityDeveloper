using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character
{
    public abstract class AnimatorBase : MonoBehaviour
    {

        protected readonly int _move = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _hit = Animator.StringToHash("Hit");

        [SerializeField] protected Animator _animator;
        
        [SerializeField] private Health _health;
        private void OnEnable() =>
            _health.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged(float arg1, float arg2) =>
            _animator.SetTrigger(_hit);

        protected abstract void Update();
        public void Attack() =>
            _animator.SetTrigger(_attack);
        private void OnDisable() =>
            _health.OnHealthChanged -= OnHealthChanged;
    }
}