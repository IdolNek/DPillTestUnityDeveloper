using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Character.Enemy
{
    public class MoveEnemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _meshAgent;
        private Transform _playerTransform;
        private Vector3 _targetPosition;
        public void Construct(Transform playerTransform) => 
            _playerTransform = playerTransform;

        private void Update()
        {
            if (_playerTransform == null) return;
            _meshAgent.destination = _targetPosition;
        }
        public void SetTarget() => 
            _targetPosition = _playerTransform.position;
        public void SetTarget(Vector3 targetPosition) => 
            _targetPosition = targetPosition;

    }
}