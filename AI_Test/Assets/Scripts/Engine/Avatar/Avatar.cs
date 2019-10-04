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
        public Vector3 forward
        {
            get { return m_Transform.forward; }
            set
            {
                var curRot = m_Transform.rotation;
                var dir = m_Transform.forward;
                var rot = Quaternion.FromToRotation(m_Transform.forward, value);

                m_Transform.rotation = rot * curRot;
            }
        }
        #endregion
    }
}