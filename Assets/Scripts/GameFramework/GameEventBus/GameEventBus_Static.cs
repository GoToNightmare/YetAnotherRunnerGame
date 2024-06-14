using System.Collections.Generic;
using Game.Core.GameEventBusVariants.EventTypes;

namespace GameFramework.GameEventBus
{
    public static partial class GameEventBus
    {
        private static readonly Dictionary<GameEventType, object> AllStaticEvents = new();
    }
}