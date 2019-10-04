namespace GamePlay
{
    using UnityEngine;

    using GameInterface;
    using GameUtils;

    public class CameraHelper : Singleton<CameraHelper>
    {
        private ICameraController m_Controller;

        #region Singleton
        private CameraHelper()
        {
            m_OnTargetChange = new GameEvent<int>();
            m_Controller = ICameraController.Instance;

            m_RotateSensitivity = 1;
            m_ScrollWheelSensitivity = 1;
            m_MaxYDegree = 60;
            m_MinYDegree = 10;

            m_LockOnTargetId = EntityMgr.InvalidEntityId;
        }
        public override void Init()
        {
            m_Controller.OnInit();
            
            m_Controller.Distance = 5;
            m_Controller.AngleX = 0;
            m_Controller.AngleY = 30;
        }
        public override void Release()
        {
            
        }
        #endregion

        #region Properties
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
                m_LockOnTargetId = value.EntityId;
                m_Controller.LockOnTarget = value.Avatar.transform;

                m_OnTargetChange?.Invoke(m_LockOnTargetId);
            }
        }

        public Vector3 CameraForward
        {
            get
            {
                var cam = m_Controller.MainCamera;
                var dir = cam.transform.forward;
                return new Vector3(dir.x, 0, dir.z);
            }
        }
        public Vector3 CameraRight
        {
            get
            {
                var cam = m_Controller.MainCamera;
                var dir = cam.transform.right;
                return dir;
            }
        }

        private float m_RotateSensitivity;
        public float RotateSensitivity
        {
            get { return m_RotateSensitivity; }
            set { m_RotateSensitivity = value; }
        }

        private float m_ScrollWheelSensitivity;
        public float ScrollWheelSensitivity
        {
            get { return m_ScrollWheelSensitivity; }
            set { m_ScrollWheelSensitivity = value; }
        }

        private float m_MaxYDegree;
        public float MaxYDegree
        {
            get { return m_MaxYDegree; }
            set { m_MaxYDegree = value; }
        }

        private float m_MinYDegree;
        public float MinYDegree
        {
            get { return m_MinYDegree; }
            set { m_MinYDegree = value; }
        }

        public float CameraDistance
        {
            get { return m_Controller.Distance; }
            set { m_Controller.Distance = value; }
        }
        public float CameraAngleX
        {
            get { return m_Controller.AngleX; }
            set { m_Controller.AngleX = value; }
        }
        public float CameraAngleY
        {
            get { return m_Controller.AngleY; }
            set { m_Controller.AngleY = Mathf.Clamp(value, m_MinYDegree, m_MaxYDegree); }
        }
        public Vector3 CameraOffset
        {
            get { return m_Controller.Offset; }
        }
        public Camera MainCam
        {
            get { return m_Controller.MainCamera; }
        }
        #endregion

        public void Update(float totalTime, float deltaTime)
        {
            IInputMgr inputMgr = IInputMgr.Instance;

            float offsetX = inputMgr.GetAxis(VirtualAxis.MouseAxisX);
            float offsetY = -inputMgr.GetAxis(VirtualAxis.MouseAxisY);
            float scrollOffset = inputMgr.GetAxis(VirtualAxis.MouseAxisZ);

            var tanX = offsetX * m_RotateSensitivity / m_Controller.Distance;
            var angleX = Mathf.Atan(tanX) * Mathf.Rad2Deg;
            var tanY = offsetY * m_RotateSensitivity / m_Controller.Distance;
            var angleY = Mathf.Atan(tanY) * Mathf.Rad2Deg;

            float curAngleY = m_Controller.AngleY;
            if (curAngleY + angleY > m_MaxYDegree)
                angleY = m_MaxYDegree - curAngleY;
            else if (curAngleY + angleY < m_MinYDegree)
                angleY = m_MinYDegree - curAngleY;

                m_Controller.AngleOffsetX = angleX;
            m_Controller.AngleOffsetY = angleY;

            m_Controller.Distance -= (scrollOffset * m_ScrollWheelSensitivity);

            m_Controller.Update(totalTime, deltaTime);
        }
    }
}