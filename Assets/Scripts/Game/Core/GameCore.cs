using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Core.GameEventBusVariants.EventDataTypes;
using Game.Core.StateMachineVariants.Data;
using Game.Core.StateMachineVariants.States;
using GameFramework.GameEventBus;
using GameFramework.StateMachine;
using Loading;
using UnityEngine;

namespace Game.Core
{
    public class GameCore : MonoBehaviour, ILoadableObject
    {
        public async UniTask Load()
        {
            await UniTask.NextFrame();


            Debug.Log("[GameCore] Loaded");
        }


        private void Update()
        {
            float dt = Time.deltaTime;


            currentState?.Update(new UpdateData() { dt = dt });
        }


        private StateHandler<EnterStateData, ExitStateData, UpdateData> currentState;

        private readonly Dictionary<Type, StateHandler<EnterStateData, ExitStateData, UpdateData>> allStates = new Dictionary<Type, StateHandler<EnterStateData, ExitStateData, UpdateData>>()
        {
            { typeof(State_WaitingForGameStart), new State_WaitingForGameStart() },
            { typeof(State_Inactive), new State_Inactive() },
            { typeof(State_Active), new State_Active() },
            { typeof(State_Finished), new State_Finished() },
        };


        private void OnApplicationPause(bool pauseStatus)
        {
        }


        private void OnApplicationQuit()
        {
        }


        private void ChangeState(Type newStateType)
        {
            var current = currentState;
            if (current != null)
            {
                if (current.GetType() == newStateType)
                {
                    Debug.LogWarning($"[ChangeState] Current state == new state, this shouldn't happen, skip: {newStateType}");
                    return;
                }


                current.ExitState(new ExitStateData());
            }


            if (allStates.TryGetValue(newStateType, out var stateHandler))
            {
                currentState = stateHandler;
                currentState.EnterState(new EnterStateData());
            }
            else
            {
                currentState = null;
                throw new Exception($"New state type not found: {newStateType}");
            }


            new ED_GameStateChanged() { NewState = newStateType }.TriggerEvent();
        }


        private void OnApplicationFocus(bool hasFocus)
        {
            // TODO
        }


        private void Start()
        {
            GameEventBus.AddListener<ED_StartClick>(StartClick);
            GameEventBus.AddListener<ED_ChangeGameState>(ChangeStateMessage);
        }


        private void OnDestroy()
        {
            GameEventBus.RemoveListener<ED_StartClick>(StartClick);
            GameEventBus.RemoveListener<ED_ChangeGameState>(ChangeStateMessage);
        }


        private void ChangeStateMessage(ED_ChangeGameState eventData)
        {
            ChangeState(eventData.NewState);
        }


        private void StartClick(ED_StartClick eventData)
        {
            bool canStartTheGame = currentState == null;
            if (canStartTheGame)
            {
                ChangeState(typeof(State_WaitingForGameStart));
            }
        }
    }
}