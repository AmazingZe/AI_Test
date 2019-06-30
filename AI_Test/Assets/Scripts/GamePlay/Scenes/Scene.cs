namespace GameRuntime
{
    public abstract class Scene
    {
        public abstract string SceneName { get; }

        public abstract void OnInit();
        public abstract void OnUpdate(float totalTime, float deltaTime);
        public abstract void OnExit();
    }
}