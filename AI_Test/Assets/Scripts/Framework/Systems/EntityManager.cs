namespace GameFramework
{
    using System;
    using System.Collections.Generic;
    
    using GameUtils;

    public sealed class EntityManager : Singleton<EntityManager>
    {
        private const int InitNum = 10;
        private static int m_EntityID = 0;

        #region Properties
        private Dictionary<int, Entity> m_Entities;

        private List<int> m_RemoveBuffer;
        private List<Entity> m_AddBuffer;

        private Scene m_CurScene;
        public Scene CurScene
        {
            get { return m_CurScene; }
            set { m_CurScene = value; }
        }

        private Action<int> m_OnEntityRemove;
        public Action<int> OnEntityRemove { get { return m_OnEntityRemove; } }
        #endregion

        public void Update(float totalTime, float deltaTime)
        {
            UpdateEnitity();


        }
        private void UpdateEnitity()
        {
            int removeLen = m_RemoveBuffer.Count;
            for (int i = 0; i < removeLen; i++)
            {
                int index = m_RemoveBuffer[i];
                Entity entity;
                if (!m_Entities.TryGetValue(index, out entity))
                    throw new IndexOutOfRangeException();

                m_Entities.Remove(index);
                Entity.Recycle(entity);
            }
            m_RemoveBuffer.Clear();

            int addLen = m_AddBuffer.Count;
            for (int i = 0; i < addLen; i++)
            {
                var entity = m_AddBuffer[i];
                int index = entity.ID;
                if(m_Entities.ContainsKey(index))
                    throw new IndexOutOfRangeException("Index Already Exists");

                m_Entities.Add(index, entity);
            }
            m_AddBuffer.Clear();
        }

        public void AddEntity(string prefabPath)
        {
            var obj = AssetFactory.Instance.LoadChar(prefabPath);
            Entity addMe = Entity.Create(m_EntityID++, obj);
            m_AddBuffer.Add(addMe);
        }
        public void RemoveEntity(int id)
        {
            m_RemoveBuffer.Add(id);
            m_OnEntityRemove.Invoke(id);
        }
        public Entity GetEntity(int id)
        {
            Entity retMe;
            if(!m_Entities.TryGetValue(id, out retMe))
                throw new IndexOutOfRangeException();

            return retMe;
        }

        #region Singleton_API
        private EntityManager() { }
        public override void OnInit()
        {
            m_Entities = new Dictionary<int, Entity>(InitNum);

            m_RemoveBuffer = new List<int>();
            m_AddBuffer = new List<Entity>();
        }
        protected override void _OnRelease()
        {
            m_RemoveBuffer.Clear();
            m_AddBuffer.Clear();

            m_Entities.Clear();

            base._OnRelease();
        }
        #endregion
    }
}