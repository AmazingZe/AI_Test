namespace GamePlay
{
    using System.Collections.Generic;

    using GameUtils;
    using GameInterface;

    public class EntityMgr : Singleton<EntityMgr>
    {
        public static int InvalidEntityId = -1;
        public static Dictionary<int, string> _charFbxPathDic = new Dictionary<int, string>
        {
            { (int)CharType.Test, "Character/TestBot"},
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
            m_MainCharacterId = InvalidEntityId;

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

        #region MainChar
        private int m_MainCharacterId;
        public Entity MainCharacter
        {
            get
            {
                Entity retMe;
                if (m_Entities.TryGetValue(m_MainCharacterId, out retMe))
                    return retMe;

                return null;
            }
        }
        
        private Entity SetMainCharWithId(int entityId)
        {
            if (m_MainCharacterId != InvalidEntityId)
                m_Entities[m_MainCharacterId].IsMainChar = false;

            Entity retMe;
            if (m_Entities.TryGetValue(entityId, out retMe))
            {
                m_MainCharacterId = entityId;
                retMe.IsMainChar = true;
                return retMe;
            }

            return null;
        }
        #endregion

        public void Update(float totalTime, float deltaTime)
        {
            #region Add & Remove
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
                if (m_Entities.ContainsKey(entity.EntityId))
                    continue;

                m_Entities.Add(entity.EntityId, entity);
            }
            m_EntitiesToBeAdded.Clear();
            #endregion

            #region MainChar
            var MainChar = MainCharacter;
            if (MainChar != null)
            {
                float offset = IInputMgr.Instance.GetAxis(VirtualAxis.AxisZ);
                MainChar.Position += offset * MainChar.Speed * MainChar.Direction;
            }

            #endregion

            foreach (var item in m_Entities)
            {

            }

        }

        public Entity CreateEntity(CharType type, bool isMainChar = false)
        {
            //Todo: Pool
            Entity retMe = new Entity();
            retMe.SetModel(_charFbxPathDic[(int)type]);
            
            if (isMainChar)
            {
                int index = AddEntity(retMe);
                SetMainCharWithId(index);
            }
            else
                AddEntityDelay(retMe);


            return retMe;
        }
        public void RemoveEntity(int removeMe) { m_EntitiesToBeRemoved.Add(removeMe); }
        public Entity GetEntityWithId(int entityId)
        {
            Entity retMe;
            if (m_Entities.TryGetValue(entityId, out retMe))
                return retMe;

            return null;
        }

        private int AddEntityDelay (Entity addMe)
        {
            if (addMe == null) return InvalidEntityId;

            addMe.EntityId = m_EntityId++;
            m_EntitiesToBeAdded.Add(addMe);

            return m_EntityId - 1;
        }
        private int AddEntity(Entity addMe)
        {
            if (addMe == null) return InvalidEntityId;

            addMe.EntityId = m_EntityId++;
            m_Entities.Add(addMe.EntityId, addMe);

            return m_EntityId - 1;
        }
    }
}