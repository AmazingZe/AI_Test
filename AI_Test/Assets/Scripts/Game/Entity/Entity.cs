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

        public Entity()
        {
            m_EntityId = EntityMgr.InvalidEntityId;
            Speed = 1;

            m_OnPFSucceed = new GameEvent();
            m_OnPFPartial = new GameEvent();
            m_OnPFFailed = new GameEvent();
        }

        private IAvatar m_Avatar;
        public void SetModel(string prefabPath)
        {
            m_Avatar = IAvatarMgr.Instance.GetAvatar(prefabPath);
        }

        private bool m_IsMainChar;
        public bool IsMainChar
        {
            get { return m_IsMainChar; }
            set { m_IsMainChar = value; }
        }

        //Interaction
        private IStateMachine m_StatemMachine;

        #region Locomotion
        private GameEvent m_OnPFSucceed;
        public GameEvent OnPathFindingSucceed { get { return m_OnPFSucceed; } }
        private GameEvent m_OnPFPartial;
        public GameEvent OnPathFindingPartial { get { return m_OnPFPartial; } }
        private GameEvent m_OnPFFailed;
        public GameEvent OnPathFindingFailed { get { return m_OnPFFailed; } }

        public float Speed;
        public Vector3 Position
        {
            get { return m_Avatar == null ? Vector3.zero : m_Avatar.transform.position; }
            set { m_Avatar.transform.position = value; }
        }
        public Vector3 Direction
        {
            get { return m_Avatar == null ? Vector3.zero : m_Avatar.transform.forward; }
            set { m_Avatar.transform.rotation = Quaternion.Euler(value); }
        }

        public virtual void MoveTo(Vector3 des)
        {

        }
        
        private void OnPFSucceed()
        {
            m_OnPFSucceed.Invoke();
        }
        private void OnPFPartial()
        {
            m_OnPFPartial.Invoke();
        }
        private void OnPFFailed()
        {
            m_OnPFFailed.Invoke();
        }
        #endregion



        public void OnRelease()
        {
            IAvatarMgr.Instance.RecycleAvatar(m_Avatar);
            m_Avatar = null;
        }
    }
}
