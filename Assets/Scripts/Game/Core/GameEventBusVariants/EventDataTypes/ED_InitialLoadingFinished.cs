using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_InitialLoadingFinished : IEventDataType
    {
        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.InitialLoadingFinished;
        }
    }
}