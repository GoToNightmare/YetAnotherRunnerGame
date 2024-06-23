using Game.Core.GameEventBusVariants.EventDataTypes;
using Game.Core.StateMachineVariants.Data;
using GameFramework.GameEventBus;
using GameFramework.StateMachine;

namespace Game.Core.StateMachineVariants.States
{
    public class State_Active : StateHandler<EnterStateData, ExitStateData, UpdateData>
    {
        public override void EnterState(EnterStateData param)
        {
            new ED_LevelLoadingEnd().TriggerEvent();
        }

        public override void ExitState(ExitStateData param)
        {
        }

        public override void Update(UpdateData param)
        {
        }
    }
}