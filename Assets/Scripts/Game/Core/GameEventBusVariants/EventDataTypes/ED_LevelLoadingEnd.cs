using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_LevelLoadingEnd : IEventDataType
    {
        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.LevelLoadingEnd;
        }
    }
}