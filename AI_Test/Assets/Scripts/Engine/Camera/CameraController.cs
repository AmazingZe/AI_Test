namespace GameEngine
{
    using UnityEngine;

    using GameInterface;

    public enum CamTransitionMode
    {
        LockTime,
        LockSpeed,

        Count
    }

    public class CameraController : ICameraController
    {

        #region Singleton
        public override void OnInit()
        {
            m_MainCam = Camera.main;
        }
        public override void OnRelease()
        {

        }
        #endregion

        private Camera m_MainCam;
        public override Camera MainCamera
        {
            get
            {
                if (m_MainCam == null)
                    m_MainCam = Camera.main;

                return m_MainCam;
            }   
        }
        
        private float m_Radius = 10;
        public override float Distance
        {
            get { return m_Radius; }
            set { m_Radius = value; }
        }

        public override void Update(float totalTime, float deltaTime)
        {
            if (m_Target == null) return;

            //TraceTargetPhase();
            //UpdateCamPosPhase();

            UpdateInput();
            UpdateRotation();
        }

        #region Update Lock-On Target Phase
        private CamTransitionMode m_CamTranMode = CamTransitionMode.LockSpeed;

        private float m_TranslationRate = 1 / (60 * 1);
        public override float TransitionTime
        {
            get { return 1 / (m_TranslationRate * 60); }
            set
            {
                m_TranslationRate = 1 / (value * 60);
                m_CamTranMode = CamTransitionMode.LockTime;
            }
        }

        private float m_TranslationSpeed = 1;
        public override float TranslationSpeed
        {
            get { return m_TranslationSpeed; }
            set
            {
                m_TranslationSpeed = value;
                m_CamTranMode = CamTransitionMode.LockSpeed;
            }
        }

        private Transform m_Target;
        public override Transform LockedTarget
        {
            get { return m_Target; }
            set
            {
                if (!ReferenceEquals(m_Target, value))
                    m_Target = value;
            }
        }

        private Vector3 m_Offset = new Vector3(0, 5, -10);
        private Vector3 m_Delta;
        private Vector3 m_NextPos;

        private bool m_StopFlag = false;

        private void TraceTargetPhase()
        {
            Vector3 camPos = m_MainCam.transform.position;
            m_NextPos = m_Target.position + m_Offset;

            float offset = (m_NextPos - camPos).sqrMagnitude;
            if (offset == 0)
            {
                m_StopFlag = true;
                m_Delta = Vector3.zero;
            }
            else if (offset < 0.25)
            {
                m_StopFlag = false;
                m_Delta = m_NextPos - camPos;
            }
            else
            {
                m_StopFlag = false;
                switch (m_CamTranMode)
                {
                    case CamTransitionMode.LockSpeed:
                        m_Delta = (m_NextPos - camPos).normalized * m_TranslationSpeed;
                        break;
                    case CamTransitionMode.LockTime:
                        m_Delta = (m_NextPos - camPos) * m_TranslationRate;
                        break;
                    default:
                        m_Delta = (m_NextPos - camPos);
                        break;
                }
            }
            
        }
        private void UpdateCamPosPhase()
        {
            if (m_StopFlag) return;

            m_MainCam.transform.position += m_Delta;
        }
        #endregion

        #region Update Rotation Phase
        private float m_RotationScale = 0.3f;

        private float m_AngleX;
        private float m_AngleY;

        private void UpdateInput()
        {
            var offsetX = IInputMgr.Instance.GetAxis(VirtualAxis.MouseAxisX);
            var offsetY = -IInputMgr.Instance.GetAxis(VirtualAxis.MouseAxisY);

            if(Mathf.Abs(offsetX) > Mathf.Abs(offsetY))
            {
                var tanX = offsetX * m_RotationScale / m_Radius;
                m_AngleX = Mathf.Atan(tanX) * Mathf.Rad2Deg;
                m_AngleY = 0;
            }
            else
            {
                var tanY = offsetY * m_RotationScale / m_Radius;
                m_AngleY = Mathf.Atan(tanY) * Mathf.Rad2Deg;
                m_AngleX = 0;
            }

            //var tanX = offsetX * m_RotationScale / m_Radius;
            //var tanY = offsetY * m_RotationScale / m_Radius;

            //m_AngleX = Mathf.Atan(tanX) * Mathf.Rad2Deg;
            //m_AngleY = Mathf.Atan(tanY) * Mathf.Rad2Deg;
        }
        private void UpdateRotation()
        {
            Vector3 center = m_Target.position;

            if (m_AngleX != 0)
                RotateAround(center, Vector3.up, m_AngleX);

            if (m_AngleY != 0)
                RotateAround(center, Vector3.right, m_AngleY);
        }
        #endregion

        private void RotateAround(Vector3 center, Vector3 axis, float angle)
        {
            var rot = Quaternion.AngleAxis(angle, axis);
            Vector3 dir = m_MainCam.transform.position - center;
            Vector3 newDir = rot * dir;
            m_MainCam.transform.position = newDir + center;

            var curRot = m_MainCam.transform.rotation;

            Vector3 newUp = rot * Vector3.up;
            Quaternion q2 = Quaternion.FromToRotation(newUp, Vector3.up);

            m_MainCam.transform.rotation = q2 * rot;
        }

        private bool IsInRange(Vector3 from, Vector3 to) { return (from - to).sqrMagnitude <= m_Radius * m_Radius; }
    }
}