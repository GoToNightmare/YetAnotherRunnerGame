namespace GameFramework.GameEventBus.EventDataTypes
{
    public struct ED_LoadingGetCurrentPct : IEventDataType
    {
        public GameEventType GameEventType()
        {
            return global::GameEventType.LoadingGetCurrentPct;
        }
    }
}