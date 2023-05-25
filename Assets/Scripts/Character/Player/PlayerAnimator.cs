﻿using UnityEngine;

namespace Assets.Scripts.Character.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private static readonly int _move = Animator.StringToHash("Speed");
        private readonly int _attack = Animator.StringToHash("Attack");
        private readonly int _hit = Animator.StringToHash("Hit");

        [SerializeField] private Animator _animator;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private PlayerHealth _health;

        private void OnEnable() =>
            _health.OnHealthChanged += OnHealthChanged;

        private void OnHealthChanged(float arg1, float arg2) =>
            _animator.SetTrigger(_hit);
        private void Update() => 
            _animator.SetFloat(_move, _characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        public void Attack() =>
            _animator.SetTrigger(_attack);
        private void OnDisable() =>
            _health.OnHealthChanged -= OnHealthChanged;
    }
}