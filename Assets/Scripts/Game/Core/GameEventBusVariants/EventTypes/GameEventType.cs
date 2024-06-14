namespace Game.Core.GameEventBusVariants.EventTypes
{
    public enum GameEventType : int
    {
        None = 0,
        LoadingProgressChanged = 1,
        LoadingGetCurrentPct = 2,
        StartClick,
        PrepareGameMap,
        GameMapReady,
        ChangeGameState,
        GameStateChanged
    }
}