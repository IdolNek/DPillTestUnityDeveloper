using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.StateMachine.State
{
    public class PlayerInAttackArea : IState
    {
        private readonly IGameFactory _gameFactory;

        public PlayerInAttackArea(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Enter()
        {
            foreach (GameObject Enemy in _gameFactory.Spawner.GameObjPool)
            {
                Enemy.GetComponent<MoveEnemy>().SetTargetToPlayer();
            }
        }

        public void Exit()
        {
        }
    }
}
