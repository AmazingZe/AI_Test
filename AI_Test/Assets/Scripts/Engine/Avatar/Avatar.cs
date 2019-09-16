namespace GameEngine
{
    using UnityEngine;

    using GameInterface;

    public class Avatar : IAvatar
    {
        #region Properties
        private Animator m_Animator;
        private Transform m_Transform;

        public Animator animator
        {
            get { return m_Animator; }
        }
        public Transform transform
        {
            get { return m_Transform; }
        }
        #endregion

        public Avatar(GameObject obj)
        {
            m_Animator = obj.GetComponent<Animator>();
            m_Transform = obj.transform;
        }
    }
}