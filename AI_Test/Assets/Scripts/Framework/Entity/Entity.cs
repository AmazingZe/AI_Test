namespace GameFramework
{
    using System.Collections.Generic;

    using GameUtils;
    using GameCore.AI;

    public abstract class Entity : IPoolable
    {
        public const int EntityNotInScene = -1;

        #region Properties
        private int m_Id;
        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        private EntityType m_EntityType;
        public EntityType EntityType
        {
            get { return m_EntityType; }
            set { m_EntityType = value; }
        }

        private List<int> m_Neighbors;
        public List<int> Neighbors
        {
            get { return m_Neighbors; }
            set { m_Neighbors = value; }
        }

        public BlackBoard BBdata;
        #endregion
        
        #region IPoolable_API
        public virtual void Recycle()
        {
            m_Id = EntityNotInScene;
        }
        #endregion
    }

    public enum EntityType
    {
        Char,
        Tool,
        Trap
    }
}