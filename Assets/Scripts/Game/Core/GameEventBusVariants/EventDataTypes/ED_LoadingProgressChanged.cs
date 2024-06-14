using Game.Core.GameEventBusVariants.EventTypes;
using GameFramework.GameEventBus;

namespace Game.Core.GameEventBusVariants.EventDataTypes
{
    public struct ED_LoadingProgressChanged : IEventDataType
    {
        public float ProgressPct01;
        public bool Finished;


        public GameEventType GameEventType()
        {
            return EventTypes.GameEventType.LoadingProgressChanged;
        }
    }
}