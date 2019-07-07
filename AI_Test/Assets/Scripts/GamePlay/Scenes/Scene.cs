namespace GameFramework
{
    using UnityEngine;

    public abstract class Scene
    {
        public abstract string SceneName { get; }

        public abstract void AddObject(GameObject obj, int id);
        public abstract void RemoveObject(int id);

        public abstract void OnInit();
        public abstract void OnUpdate(float totalTime, float deltaTime);
        public abstract void OnExit();
    }
}