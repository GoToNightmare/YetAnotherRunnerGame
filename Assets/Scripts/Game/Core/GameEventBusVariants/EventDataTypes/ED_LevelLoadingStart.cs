using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_LevelLoadingStart : IEventDataType
    {
        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.LevelLoadingStart;
        }
    }
}