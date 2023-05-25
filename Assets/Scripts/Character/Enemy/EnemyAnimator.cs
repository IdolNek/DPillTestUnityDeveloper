using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {

        private static readonly int _move = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _hit = Animator.StringToHash("Hit");

        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private Health _health;
        private void OnEnable() => 
            _health.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged(float arg1, float arg2) => 
            _animator.SetTrigger(_hit);

        private void Update() => 
            _animator.SetFloat(_move, _agent.velocity.magnitude);
        public void Attack() => 
            _animator.SetTrigger(_attack);
        private void OnDisable() => 
            _health.OnHealthChanged -= OnHealthChanged;
    }
}