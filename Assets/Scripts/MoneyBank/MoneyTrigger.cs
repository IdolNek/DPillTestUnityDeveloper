using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.MoneyBank
{
    public class MoneyTrigger : MonoBehaviour
    {
        private bool _isCollect = false;
        private void OnTriggerEnter(Collider other)
        {
            if (_isCollect) return;
            if (other.TryGetComponent<MoneyCollector>(out MoneyCollector collector))
            {
                _isCollect = true;
                collector.AddMoneyBank(gameObject);
            }
        }
    }
}