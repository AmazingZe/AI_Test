namespace GameCore.Steering
{
    using GameUtils;
    using GameFramework;

    using UnityEngine;

    public class Agent : IPoolable
    {
        public static Agent Create(Entity entity)
        {
            var retMe = Pool<Agent>.Allocate();

            retMe.m_Entity = entity;

            return retMe;
        }
        public static void Recycle(ref Agent agent)
        {
            Pool<Agent>.Recycle(agent);
            agent = null;
        }

        #region Properties
        private Entity m_Entity;

        private Vector3 m_SimPos;
        private Vector3 m_DesiredPos;
        private Vector3 m_CurVelocity;
        #endregion



        #region IPoolable

        public void Recycle()
        {

        }
        #endregion
    }
}