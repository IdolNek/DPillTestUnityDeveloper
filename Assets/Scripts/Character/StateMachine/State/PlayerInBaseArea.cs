using Assets.Scripts.Character.Enemy;
using Assets.Scripts.Character.Player;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using UnityEngine;

namespace Assets.Scripts.Character.StateMachine.State
{
    public class PlayerInBaseArea: IState
    {
        private readonly IGameFactory _gameFactory;

        public PlayerInBaseArea(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Enter()
        {
            foreach (GameObject Enemy in _gameFactory.Spawner.GameObjPool)
            {
                Enemy.GetComponent<MoveEnemy>().SetRandomPosition();
            }
            _gameFactory.Player.GetComponent<PlayerAttack>().SetInAttackArea(false);
        }

        public void Exit()
        {
        }
    }
}
