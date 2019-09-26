namespace GamePlay
{
    public class SMFactory
    {
        public static IStateMachine GetSM(Entity entity)
        {
            StateMachine<Entity> retMe = new StateMachine<Entity>(entity);
        }
    }
}