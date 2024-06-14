using Game.Core.GameEventBusVariants.EventTypes;

namespace GameFramework.GameEventBus
{
    public interface IEventDataType
    {
        GameEventType GameEventType();
    }
}