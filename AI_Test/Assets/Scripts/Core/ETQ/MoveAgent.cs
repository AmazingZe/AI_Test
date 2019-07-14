namespace GameCore
{
    using GameUtils;
    using GameFramework;

    using UnityEngine;

    using System.Collections.Generic;

    public class MoveAgent : IPoolable
    {
        public static MoveAgent Create(Entity entity, Transform transform)
        {
            var retMe = Pool<MoveAgent>.Allocate();

            retMe.entity = entity;
            retMe.transform = transform;

            return retMe;
        }
        public static void Recycle(ref MoveAgent agent)
        {
            Pool<MoveAgent>.Recycle(agent);
            agent = null;
        }

        #region Properties
        public MoveAgent next;
        public Entity entity;
        public Transform transform;

        public bool UpdatePos = true;
        
        public Vector3 m_CurVelocity;

        private Vector3 m_DesiredPos;
        public Vector3 DesiredPos
        {
            get { return m_DesiredPos; }
            set { m_DesiredPos = value; }
        }

        private Vector3 m_SimPos;
        public Vector3 SimPos
        {
            get { return m_SimPos; }
            set { m_SimPos = value; }
        }
        
        public List<int> Neighbors
        {
            get { return entity.Neighbors; }
            set { entity.Neighbors = value; }
        }
        #endregion

        #region IPoolable

        public void Recycle()
        {
            next = null;
            entity = null;
            transform = null;
        }
        #endregion
    }
}