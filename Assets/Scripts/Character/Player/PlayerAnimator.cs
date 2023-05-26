using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerAnimator : AnimatorBase
    {
        [SerializeField] private CharacterController _characterController;

        protected override void Update() => 
            _animator.SetFloat(_move, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
    }
}