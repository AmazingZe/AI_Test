namespace GamePlay
{
    using GameInterface;
    using GameUtils;

    public class CharController : Singleton<CharController>
    {
        private Entity m_Entity;

        #region Singleton
        private CharController() { }
        public override void Init()
        {
            m_Entity = GameScene.Instance.MainChar;

            CameraHelper.Instance.LockOnTarget = m_Entity;
        }
        public override void Release()
        {
            
        }
        #endregion

        public Entity Target
        {
            get { return m_Entity; }
            set
            {
                m_Entity = value;
                CameraHelper.Instance.LockOnTarget = m_Entity;
            }
        }

        public void Update()
        {
            if (m_Entity == null) return;

            var InputMgr = IInputMgr.Instance;
            var CamHelper = CameraHelper.Instance;

            float offsetZ = InputMgr.GetAxis(VirtualAxis.AxisZ);
            m_Entity.Position += offsetZ * m_Entity.Speed * CamHelper.CameraForward;
            if (offsetZ != 0)
                m_Entity.Forward = CamHelper.CameraForward;
            float offsetX = InputMgr.GetAxis(VirtualAxis.AxisX);
            m_Entity.Position += offsetX * m_Entity.Speed * CamHelper.CameraRight;
            if (offsetX != 0)
                m_Entity.Forward = CamHelper.CameraRight;
        }
    }
}