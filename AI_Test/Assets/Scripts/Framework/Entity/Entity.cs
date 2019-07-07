namespace GameFramework
{
    using UnityEngine;

    using GameUtils;

    public class Entity : IPoolable
    {
        public const int EntityNotInScene = -1;

        #region Properties
        private int m_Id;

        private Transform m_Transform;
        #endregion

        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        public Transform Transform
        {
            get { return m_Transform; }
            set { m_Transform = value; }
        }

        #region IPoolable_API
        public void Recycle()
        {
            m_Id = EntityNotInScene;

            m_Transform = null;
        }
        #endregion
    }

    public enum EntityType
    {
        Player,
        Bot,
        Tool,
        Trap
    }
}