namespace GamePlay
{
    public abstract class IStateMachine
    {


        public abstract void ChangeToState(int stateId);

        public abstract int Update();
        public abstract void SendMsg(int msgId);
    }

    public enum StateID
    {
        Idle,

        Count,
    }
}