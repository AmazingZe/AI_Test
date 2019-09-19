namespace GameEngine
{
    using UnityEngine;

    using GameInterface;

    public class Avatar : IAvatar
    {
        public Avatar() { }
        public void Recycle()
        {

        }

        #region Animation
        private Animator m_Animator;
        public Animator animator
        {
            get { return m_Animator; }
            set { m_Animator = value; }
        }

        public void SetParamBool(int paramId, bool value)
        {
            m_Animator.SetBool(paramId, value);
        }
        public void SetParamFloat(int paramId, float value)
        {
            m_Animator.SetFloat(paramId, value);
        }
        #endregion

        #region LocoMotion
        private Transform m_Transform;
        public Transform transform
        {
            get { return m_Transform; }
            set { m_Transform = value; }
        }
        public Vector3 position
        {
            get { return m_Transform.position; }
            set { m_Transform.position = value; }
        }
        #endregion
    }
}