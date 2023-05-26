using UnityEngine.AI;
using UnityEngine;

namespace Assets.Scripts.Character.Enemy
{
    public class EnemyAnimator : AnimatorBase
    {
        [SerializeField] private NavMeshAgent _agent;
        protected override void Update()
        {
            float magnitude = _agent.velocity.magnitude;
            if(magnitude > 1 ) _animator.SetFloat(_move, magnitude);
            else _animator.SetFloat(_move, 0f);

        }
    }
}
