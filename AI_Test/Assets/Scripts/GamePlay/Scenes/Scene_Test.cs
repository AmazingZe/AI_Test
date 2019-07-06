namespace GameRuntime
{
    using GameFramework;

    using UnityEngine;

    public sealed class Scene_Test : Scene
    {
        #region Properties
        private string m_SceneName = "Scene_Test";


        #endregion

        public override string SceneName { get { return m_SceneName; } }
        public override void OnInit()
        {
            var instance = EntityManager.Instance;
        }
        public override void OnUpdate(float totalTime, float deltaTime)
        {
            EntityManager.Update(totalTime, deltaTime);
        }
        public override void OnExit()
        {
            EntityManager.OnRelease();
        }


    }
}