namespace GamePlay
{
    using System.Collections.Generic;

    public class StateMachine<Host> : IStateMachine where Host : Entity
    {
        private Host m_Host;
        private Dictionary<int, State<Host>> m_States;
        private State<Host> m_CurState;
        private State<Host> m_PrevState;

        public StateMachine() { }
        public StateMachine<Host> Init(Host host)
        {
            m_Host = host;

            return this;
        }

        public StateMachine<Host> AddState(State<Host> state)
        {


            return this;
        }
        public State<Host> GetState(int stateId)
        {
            State<Host> retMe;
            if (m_States.TryGetValue(stateId, out retMe))
                return retMe;

            return null;
        }

        public override void ChangeToState(int stateId)
        {
            var nextState = GetState(stateId);
            if (m_CurState != null)
                m_CurState.OnLeave(nextState);
            m_PrevState = m_CurState;
            m_CurState = nextState;
            m_CurState.OnEnter(m_PrevState);
        }
        public override int Update()
        {
            if (m_CurState == null) return -1;

            int nextId = m_CurState.OnUpdate();

            if (nextId == 0) return 0;

            ChangeToState(nextId);
            return nextId;
        }
        public override void SendMsg(int msgId)
        {

        }
    }
}