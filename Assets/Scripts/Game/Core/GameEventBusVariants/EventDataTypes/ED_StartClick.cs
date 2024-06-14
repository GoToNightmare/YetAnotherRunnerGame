using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_StartClick : IEventDataType
    {
        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.StartClick;
        }
    }
}