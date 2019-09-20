namespace GamePlay
{
    public abstract class State<Host> where Host : Entity
    {
        private Host m_Host;

        public void OnEnter(State<Host> prev)
        {

            OnDoEnter(prev);
        }
        public void OnLeave(State<Host> next)
        {

            OnDoLeave(next);
        }

        public abstract int OnUpdate();
        public abstract void SendMsg(int msgId);

        protected abstract void OnDoEnter(State<Host> prev);
        protected abstract void OnDoLeave(State<Host> next);
        
    }
}