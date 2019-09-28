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

        //Interaction
        private IStateMachine m_StatemMachine;

        #region Locomotion
        public virtual void MoveTo(Vector3 des)
        {

        }
        #endregion

        

        public void OnRelease()
        {
            IAvatarMgr.Instance.RecycleAvatar(m_Avatar);
            m_Avatar = null;
        }
    }
}
