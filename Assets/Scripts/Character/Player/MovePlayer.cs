using Assets.Scripts.Infrastructure.Services.Input;
using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class MovePlayer : MonoBehaviour
    {

        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _turnSpeed;

        private IInputService _inputService;
        private Camera _camera;

        private float _rotateAngle;
        private float _moveSpeed;

        private const float epsilon = 0.001f;

        public void Construct(IInputService inputService) =>
            _inputService = inputService;
        public void Initialize(float moveSpeed) => 
            _moveSpeed = moveSpeed;

        void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (_inputService == null) return;

            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();
                float targetAngle = Mathf.Atan2(movementVector.x, movementVector.z) * Mathf.Rad2Deg;
                _rotateAngle = Mathf.LerpAngle(_rotateAngle, targetAngle, _turnSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.up * _rotateAngle);
            }

            movementVector += Physics.gravity;

            _characterController.Move(_moveSpeed * movementVector * Time.deltaTime);

        }
    }
}
