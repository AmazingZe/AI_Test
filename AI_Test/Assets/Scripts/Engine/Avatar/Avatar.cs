namespace GameEngine
{
    using UnityEngine;

    using GameInterface;

    public class Avatar : IAvatar
    {
        public Avatar() { }
        public void Init(GameObject obj)
        {
            m_Animator = obj.GetComponent<Animator>();
            m_Transform = obj.transform;
        }

        #region Animator
        private Animator m_Animator;
        public Animator animator
        {
            get { return m_Animator; }
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
        public Vector3 position
        {
            get { return m_Transform.position; }
            set { m_Transform.position = value; }
        }
        #endregion
    }
}