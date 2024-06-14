using System;
using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_ChangeGameState : IEventDataType
    {
        public Type NewState;


        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.ChangeGameState;
        }
    }
}