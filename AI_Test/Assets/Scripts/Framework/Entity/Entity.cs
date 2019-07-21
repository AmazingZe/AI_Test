namespace GameFramework
{
    using System.Collections.Generic;

    using GameUtils;

    using UnityEngine;

    public sealed class Entity : IPoolable
    {
        public const int EntityNotInScene = -1;

        public static Entity Create(int id, GameObject obj)
        {
            var retMe = Pool<Entity>.Allocate();

            retMe.m_Id = id;
            retMe.m_Object = obj;
            retMe.m_Transform = obj.transform;

            return retMe;
        }
        public static void Recycle(Entity entity) { Pool<Entity>.Recycle(entity); }

        #region Unity_Properties
        private GameObject m_Object;
        private Transform m_Transform;
        public Vector3 Position
        {
            get { return m_Transform.position; }
            set { m_Transform.position = value; }
        }
        public Quaternion Rotation
        {
            get { return m_Transform.rotation; }
            set { m_Transform.rotation = value; }
        }
        #endregion

        #region Properties
        private int m_Id;
        public int ID { get { return m_Id; } }

        private List<int> m_Neighbors;
        public List<int> Neighbors { get { return m_Neighbors; } }
        #endregion

        #region IPoolable_API
        public Entity()
        {
            m_Neighbors = new List<int>();
        }
        public void Recycle()
        {
            m_Id = EntityNotInScene;
            m_Neighbors.Clear();

            m_Transform = null;
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