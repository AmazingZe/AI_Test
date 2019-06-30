namespace GameFramework
{
    using UnityEngine;

    using GameUtils;

    public class Entity : IPoolable
    {
        #region Properties
        private int m_Id;

        public Transform transform;
        #endregion

        #region Public_API
        public void Update(float deltaTime)
        {
            var data = EntityManager.GetEntityDataWithID(m_Id);


        }
        #endregion

        #region IPoolable_API
        public void Recycle()
        {
            transform = null;
        }
        #endregion
    }
}