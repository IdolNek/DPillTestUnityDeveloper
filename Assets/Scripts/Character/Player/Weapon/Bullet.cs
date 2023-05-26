using Assets.Scripts.Character.Enemy;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Character.Player.Weapon
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _timeToDestroy = 10f;
        private float _damage;
        [SerializeField]
        private float _speed = 10f;

        public void Initialize(float damage) => _damage = damage;
        private void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }

        private void OnEnable() =>
            StartCoroutine(DestroyHimSelf());

        private IEnumerator DestroyHimSelf()
        {
            yield return new WaitForSeconds(_timeToDestroy);
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
                enemyHealth.TakeDamage(_damage);
            gameObject.SetActive(false);
        }
    }
}