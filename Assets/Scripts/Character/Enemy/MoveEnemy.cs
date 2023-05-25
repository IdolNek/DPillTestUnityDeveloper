using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character.Enemy
{
    public class MoveEnemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _meshAgent;
        [SerializeField] private GenerateRandomPointInAttackArea _randomPointInAttackArea;
        private Transform _playerTransform;
        private Vector3 _targetPosition;
        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;

        private void Update()
        {
            if (_playerTransform == null) return;
            _meshAgent.destination = _targetPosition;
        }
        public void SetTargetToPlayer() => 
            _targetPosition = _playerTransform.position;
        public void SetRandomPosition()
        {
            _targetPosition = _randomPointInAttackArea.GetRandomPointInAttackArea();
        }
    }
}