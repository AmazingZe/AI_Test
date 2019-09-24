namespace GamePlay
{
    using System.Collections.Generic;

    using GameUtils;

    public class EntityMgr : Singleton<EntityMgr>
    {
        public static Dictionary<int, string> _charFbxPathDic = new Dictionary<int, string>
        {
            { (int)CharType.Test, "Prefabs/Character/TestBot.prefab"},
        };

        private List<Entity> m_Entities;
        private List<Entity> m_EntitiesToBeAdded;
        private List<int> m_EntitiesToBeRemoved;

        public int entityCount
        {
            get { return m_Entities.Count; }
        }

        #region Singleton
        private EntityMgr()
        {
            m_Entities = new List<Entity>(GameConst.ContainerCapacity);
            m_EntitiesToBeAdded = new List<Entity>(GameConst.ContainerCapacity);
            m_EntitiesToBeRemoved = new List<int>(GameConst.ContainerCapacity);
        }
        public override void Init()
        {
            
        }
        public override void Release()
        {
            //Todo: Release Entity

            m_Entities.Clear();
            m_EntitiesToBeAdded.Clear();
            m_EntitiesToBeRemoved.Clear();
        }
        #endregion
        
        public void Update(float totalTime, float deltaTime)
        {
            int num = m_EntitiesToBeRemoved.Count;
            int count = entityCount;
            for (int i = count - 1; i >= 0; i--)
            {
                if (num == 0)
                    break;

                var entity = m_Entities[i];
                if (m_EntitiesToBeRemoved.Contains(entity.EntityId))
                {
                    //Todo: Release Entity
                    m_Entities.RemoveAt(i);
                    num--;
                }
            }
            m_EntitiesToBeRemoved.Clear();

            foreach (var entity in m_EntitiesToBeAdded)
            {
                //Todo: Init Entity
                m_Entities.Add(entity);
            }
            m_EntitiesToBeAdded.Clear();

            foreach (var entity in m_Entities)
            {

            }

        }

        public void AddEntity(Entity addMe)
        {
            if (addMe == null) return;

            m_EntitiesToBeAdded.Add(addMe);
        }
        public void RemoveEntity(int removeMe)
        {

        }
        public Entity GetEntityWithId(int entityId)
        {

        }
        public static Entity GetEntity()
        {

        }
    }
}