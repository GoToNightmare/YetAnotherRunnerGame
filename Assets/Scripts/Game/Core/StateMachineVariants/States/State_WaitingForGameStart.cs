using Game.Core.GameEventBusVariants.EventDataTypes;
using Game.Core.StateMachineVariants.Data;
using GameFramework.GameEventBus;
using GameFramework.StateMachine;

namespace Game.Core.StateMachineVariants.States
{
    public class State_WaitingForGameStart : StateHandler<EnterStateData, ExitStateData, UpdateData>
    {
        public override void EnterState(EnterStateData param)
        {
            GameEventBus.AddListener<ED_GameMapReady>(GameMapReady);
            new ED_PrepareGameMap().TriggerEvent();
        }


        public override void ExitState(ExitStateData param)
        {
            GameEventBus.AddListener<ED_GameMapReady>(GameMapReady);
        }


        private void GameMapReady(ED_GameMapReady eventData)
        {
            new ED_ChangeGameState() { NewState = typeof(State_Active) };
        }


        public override void Update(UpdateData param)
        {
        }
    }
}