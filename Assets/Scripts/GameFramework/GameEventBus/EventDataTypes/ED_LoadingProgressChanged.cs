namespace GameFramework.GameEventBus.EventDataTypes
{
    public struct ED_LoadingProgressChanged : IEventDataType
    {
        public float ProgressPct01;


        public GameEventType GameEventType()
        {
            return global::GameEventType.LoadingProgressChanged;
        }
    }
}