using Assets.Scripts.Character.Player;
using UnityEngine;

namespace Assets.Scripts.MoneyBank
{
    public class MoneyTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<MoneyCollector>(out MoneyCollector collector))
            {
                collector.AddMoneyBank(other.gameObject);
            }
        }
    }
}