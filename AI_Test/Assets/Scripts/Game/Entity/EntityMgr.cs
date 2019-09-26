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

        private Dictionary<int, Entity> m_Entities;
        private List<Entity> m_EntitiesToBeAdded;
        private List<int> m_EntitiesToBeRemoved;

        private int m_EntityId;
        private List<int> m_EntityIdPool;

        public int entityCount
        {
            get { return m_Entities.Count; }
        }

        #region Singleton
        private EntityMgr()
        {
            m_EntityId = 0;

            m_Entities = new Dictionary<int, Entity>(GameConst.ContainerCapacity);
            m_EntitiesToBeAdded = new List<Entity>(GameConst.ContainerCapacity);
            m_EntitiesToBeRemoved = new List<int>(GameConst.ContainerCapacity);

            m_EntityIdPool = new List<int>(GameConst.ContainerCapacity);
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

            m_EntityIdPool.Clear();
            m_EntityId = 0;
        }
        #endregion

        public static Entity GetEntity(CharType type)
        {
            //Todo: Pool
            Entity retMe = new Entity();
            retMe.SetModel(_charFbxPathDic[(int)type]);
            return retMe;
        }

        public void Update(float totalTime, float deltaTime)
        {
            foreach (int index in m_EntitiesToBeRemoved)
            {
                Entity removeMe;
                if (m_Entities.TryGetValue(index, out removeMe))
                {
                    removeMe.OnRelease();
                    m_Entities.Remove(index);
                }
            }
            m_EntitiesToBeRemoved.Clear();

            foreach (var entity in m_EntitiesToBeAdded)
            {
                if (m_Entities[entity.EntityId] != null)
                    continue;

                m_Entities.Add(entity.EntityId, entity);
            }
            m_EntitiesToBeAdded.Clear();

            foreach (var item in m_Entities)
            {

            }

        }

        public void AddEntity(Entity addMe)
        {
            if (addMe == null) return;

            addMe.EntityId = m_EntityId++;
            m_EntitiesToBeAdded.Add(addMe);
        }
        public void RemoveEntity(int removeMe)
        {

        }
        public Entity GetEntityWithId(int entityId)
        {
            Entity retMe;
            if (m_Entities.TryGetValue(entityId, out retMe))
                return retMe;

            return null;
        }
    }
}