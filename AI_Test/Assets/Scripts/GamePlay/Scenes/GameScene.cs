namespace GameRuntime
{
    using GameFramework;

    using System.Collections.Generic;

    public class GameScene
    {
        private static GameScene m_Instance;
        public static GameScene Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new GameScene();
                return m_Instance;
            }
        }

        #region Properties
        private Dictionary<int, Entity> m_Entities;
        private List<int> m_LaterRemoveEntities;
        #endregion

        #region Entity
        private void UpdateEntity(float deltaTime)
        {
            for (int i = 0; i < m_LaterRemoveEntities.Count; i++)
                m_Entities.Remove(m_LaterRemoveEntities[i]);
            m_LaterRemoveEntities.Clear();

            for (int i = 0; i < m_Entities.Count; i++)
                m_Entities[i].Update(deltaTime);
        }
        #endregion

        #region Public_API
        public static void OnInit() { Instance._OnInit(); }
        public static void OnUpdate(float targetTime, float deltaTime) { Instance._OnUpdate(targetTime, deltaTime); }
        public static void OnExit() { Instance._OnExit(); }


        #endregion

        private void _OnInit()
        {
            m_Entities = new Dictionary<int, Entity>();
            m_LaterRemoveEntities = new List<int>();
        }
        private void _OnUpdate(float targetTime, float deltaTime)
        {
            // Update game systems
            EntityManager.Update(targetTime);

            // Update instances in scene
            UpdateEntity(deltaTime);
        }
        private void _OnExit()
        {
            EntityManager.OnRelease();
        }
    }
}