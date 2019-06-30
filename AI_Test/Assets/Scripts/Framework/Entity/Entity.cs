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