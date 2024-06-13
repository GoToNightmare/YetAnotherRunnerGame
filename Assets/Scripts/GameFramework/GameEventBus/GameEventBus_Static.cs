using System.Collections.Generic;

public static partial class GameEventBus
{
    private static readonly Dictionary<GameEventType, object> AllStaticEvents = new();
}