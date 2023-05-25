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
        private bool _isPlayerTarget;

        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;

        private void Update()
        {
            if (_playerTransform == null) return;
            _meshAgent.destination = _isPlayerTarget ? _playerTransform.position : _targetPosition;
        }
        public void SetTargetToPlayer() => 
            _isPlayerTarget = true;

        public void SetRandomPosition()
        {
            _isPlayerTarget = false;
            _targetPosition = _randomPointInAttackArea.GetRandomPointInAttackArea();
        }
    }
}