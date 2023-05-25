using System;
using System.Collections.Generic;
using Assets.Scripts.Infrastructure.Factory;
using Assets.Scripts.Infrastructure.Services.ServiceLocater;
using Assets.Scripts.Infrastructure.Services.StaticData;
using Assets.Scripts.Infrastructure.StateMachine.State;
using Assets.Scripts.Infrastructure.UI.Factory;

namespace Assets.Scripts.Infrastructure.StateMachine
{
    public class GameStateMachine : StateMachineBase
    {
        public GameStateMachine(SceneLoader sceneLoader, AllServices allServices)
        {
            _states = new Dictionary<Type, IExitAbleState>
            {
                [typeof(BootStrapState)] = new BootStrapState(this, sceneLoader, allServices),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, allServices.Single<IGameFactory>(), allServices.Single<IStaticDataService>()
                    , allServices.Single<IUIFactory>(), allServices.Single<IStateMachineBase>()),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayLoadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }
    }
}