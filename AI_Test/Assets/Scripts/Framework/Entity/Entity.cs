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

        public int ID { get { return m_Id; } }
        public Transform Transform { get { return m_Transform; } }

        public Entity(int id, GameObject obj)
        {
            m_Id = id;

            m_Transform = obj.transform;
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