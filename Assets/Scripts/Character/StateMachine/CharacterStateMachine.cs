using Assets.Scripts.Character.StateMachine.State;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.StateMachine;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Character.StateMachine
{
    public class CharacterStateMachine : StateMachineBase
    {
        private readonly IGameFactory _gameFactory;

        public CharacterStateMachine(IGameFactory gameFactory) 
        {
            _gameFactory = gameFactory;
            _states = new Dictionary<Type, IExitAbleState>
            {
                [typeof(PlayerInBaseArea)] = new PlayerInBaseArea(_gameFactory),
                [typeof(PlayerInAttackArea)] = new PlayerInAttackArea(_gameFactory),
            };
        }
    }
}
