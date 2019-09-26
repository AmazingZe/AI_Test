namespace GamePlay
{

    public class Idle : State<Entity>
    {
        public override int stateId { get { return (int)StateID.Idle; } }
        
        protected override void OnDoEnter(State<Entity> prev)
        {
            
        }

        protected override void OnDoLeave(State<Entity> next)
        {
            
        }

        public override int OnUpdate()
        {

        }

        public override void SendMsg(int msgId)
        {

        }
    }
}