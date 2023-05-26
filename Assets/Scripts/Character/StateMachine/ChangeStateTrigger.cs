using Assets.Scripts.Character.Player;
using Assets.Scripts.Character.StateMachine.State;
using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.StateMachine
{
    public class ChangeStateTrigger : MonoBehaviour
    {
        private bool _isPlayerInBase = true;
        private IStateMachineBase _characterStateMachine;

        public void Construct(IStateMachineBase characterStateMachine) => 
            _characterStateMachine = characterStateMachine;
        private void OnTriggerStay(Collider other)
        {
            if (_isPlayerInBase) return;
            _isPlayerInBase = true;
            if(other.TryGetComponent<MoneyCollector>(out MoneyCollector money)) 
                money.RemoveAllMoney();
            _characterStateMachine.Enter<PlayerInBaseArea>();
        }
        private void OnTriggerExit(Collider other)
        {
            if(!_isPlayerInBase) return;
            _isPlayerInBase = false;
            _characterStateMachine.Enter<PlayerInAttackArea>();
        }
    }
}