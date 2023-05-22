using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int _move = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _hit = Animator.StringToHash("Hit");
        private readonly int _die = Animator.StringToHash("Die");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;

        private void Update()
        {
            _animator.SetFloat(_move, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
    }
}