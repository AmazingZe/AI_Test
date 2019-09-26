namespace GamePlay
{
    using UnityEngine;

    using GameInterface;

    public class Entity
    {
        private int m_EntityId;
        public int EntityId
        {
            get { return m_EntityId; }
            set { m_EntityId = value; }
        }

        public Entity() { }

        private IAvatar m_Avatar;
        public void SetModel(string prefabPath)
        {
            m_Avatar = IAvatarMgr.Instance.GetAvatar(prefabPath);
        }

        #region Animation
        public void CrossFade(int animateHash)
        {
            m_Avatar.animator.CrossFade(animateHash, 0.5f);
        }
        public void SetParamBool(int paramId, bool value)
        {
            m_Avatar.animator.SetBool(paramId, value);
        }
        public void SetParamFloat(int paramId, float value)
        {
            m_Avatar.animator.SetFloat(paramId, value);
        }
        #endregion

        #region Locomotion
        public virtual void MoveTo(Vector3 des)
        {

        }
        #endregion

        #region StateMachine
        private IStateMachine m_StatemMachine;
        #endregion

        public void OnRelease()
        {
            IAvatarMgr.Instance.RecycleAvatar(m_Avatar);
            m_Avatar = null;
        }
    }
}
