namespace Game.Core.GameEventBusVariants.EventTypes
{
    public enum GameEventType : int
    {
        None = 0,
        LoadingProgressChanged,
        LoadingGetCurrentPct,
        StartClick,
        PrepareGameMap,
        GameMapReady,
        ChangeGameState,
        GameStateChanged,
        InitialLoadingFinished,
        LevelLoadingStart,
        LevelLoadingEnd
    }
}