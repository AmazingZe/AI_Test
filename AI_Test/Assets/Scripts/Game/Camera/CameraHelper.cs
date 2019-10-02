namespace GamePlay
{
    using GameInterface;
    using GameUtils;

    public class CameraHelper : Singleton<CameraHelper>
    {
        private ICameraController m_Controller;

        #region Singleton
        private CameraHelper()
        {
            m_OnTargetChange = new GameEvent<int>();

            m_LockOnTargetId = EntityMgr.InvalidEntityId;
        }
        public override void Init()
        {
            m_Controller = ICameraController.Instance;
            m_Controller.OnInit();

            m_Controller.TranslationSpeed = 0.5f;
        }
        public override void Release()
        {
            
        }
        #endregion

        private GameEvent<int> m_OnTargetChange;
        public GameEvent<int> OnTargetChange
        {
            get { return m_OnTargetChange; }
        }

        private int m_LockOnTargetId;
        public Entity LockOnTarget
        {
            get
            {
                var retMe = EntityMgr.Instance.GetEntityWithId(m_LockOnTargetId);
                return retMe;
            }
            set
            {
                if (value.EntityId == m_LockOnTargetId)
                    return;

                m_LockOnTargetId = value.EntityId;
                m_Controller.LockedTarget = value.Avatar.transform;

                m_OnTargetChange?.Invoke(m_LockOnTargetId);
            }
        }

        public void Update(float totalTime, float deltaTime)
        {
            m_Controller.Update(totalTime, deltaTime);
        }
    }
}