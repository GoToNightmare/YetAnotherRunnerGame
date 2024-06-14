using System;
using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_GameStateChanged : IEventDataType
    {
        public Type NewState;


        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.GameStateChanged;
        }
    }
}