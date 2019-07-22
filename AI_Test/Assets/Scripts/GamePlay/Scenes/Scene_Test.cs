namespace GameFramework
{
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
            instance.CurScene = this;
        }
        public override void OnUpdate(float totalTime, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
            }

            EntityManager.Instance.Update(totalTime, deltaTime);
        }
        public override void OnExit()
        {
            EntityManager.OnRelease();
        }
    }
}