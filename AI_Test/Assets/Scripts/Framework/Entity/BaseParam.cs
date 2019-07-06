namespace GameFramework
{
    using UnityEngine;

    using GameUtils;

    public abstract class BaseParam : IPoolable
    {
        public const int IDOffset = 0;
        public const int IDMask = 255;

        protected int m_Params;

        public int ID
        {
            get { return m_Params & IDMask; }
            set
            {
                m_Params = (m_Params & ~IDMask) | (value << IDOffset);
            }
        }

        public abstract void SetAI();

        #region IPoolable
        public virtual void Recycle()
        {
            m_Params = 0;
        }
        #endregion
    }
}