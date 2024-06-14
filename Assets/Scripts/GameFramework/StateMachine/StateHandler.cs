namespace GameFramework.StateMachine
{
    public abstract class StateHandler<TEnter, TExit, TUpdate>
    {
        public abstract void EnterState(TEnter param);


        public abstract void ExitState(TExit param);


        public abstract void Update(TUpdate param);
    }
}