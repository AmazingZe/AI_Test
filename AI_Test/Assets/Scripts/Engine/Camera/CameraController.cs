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
        public CameraController()
        {
            m_Offset = new Vector3(0, 1, -11).normalized;
        }
        public override void OnInit()
        {
            m_MainCam = Camera.main;

            m_MainCam.transform.position = m_Offset;
        }
        public override void OnRelease()
        {
            m_Target = null;
        }
        #endregion

        #region Properties
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

        private Transform m_Target;
        public override Transform LockOnTarget
        {
            get { return m_Target; }
            set
            {
                if (!ReferenceEquals(m_Target, value))
                    m_Target = value;
            }
        }
        #endregion

        #region Transition
        private Vector3 m_Offset;
        public override Vector3 Offset
        {
            get { return m_Offset; }
        }

        private void UpdateCamPosPhase()
        {
            m_MainCam.transform.position = m_Target.position + m_Offset;
        }
        #endregion

        #region Rotation
        private float m_AngleOffsetX;
        public override float AngleOffsetX
        {
            get { return m_AngleOffsetX; }
            set { m_AngleOffsetX = value; }
        }
        private float m_AngleOffsetY;
        public override float AngleOffsetY
        {
            get { return m_AngleOffsetY; }
            set { m_AngleOffsetY = value; }
        }

        private float m_AngleX;
        public override float AngleX
        {
            get { return m_AngleX; }
            set
            {
                SetToAngle(value, m_AngleY);
                m_AngleX = value;
            }
        }

        private float m_AngleY;
        public override float AngleY
        {
            get { return m_AngleY; }
            set
            {
                SetToAngle(m_AngleX, value);
                m_AngleY = value;
            }
        }

        private void UpdateRotation()
        {
            Vector3 center = m_Target.position;

            RotateAround(center, Vector3.up, m_AngleOffsetX);
            RotateAround(center, m_MainCam.transform.right, m_AngleOffsetY);

            m_AngleX += m_AngleOffsetX;
            m_AngleY += m_AngleOffsetY;
        }

        private void RotateAround(Vector3 center, Vector3 axis, float angle)
        {
            if (angle == 0) return;

            var rot = Quaternion.AngleAxis(angle, axis);
            m_Offset = rot * m_Offset;

            var myRot = m_MainCam.transform.rotation;
            m_MainCam.transform.rotation = rot * myRot;
        }

        private void SetToAngle(float angleX, float angleY)
        {
            float deltaAngleX = angleX - m_AngleX;
            float deltaAngleY = angleY - m_AngleY;

            Quaternion curRot;

            if(deltaAngleX != 0)
            {
                curRot = m_MainCam.transform.rotation;
                var rotX = Quaternion.AngleAxis(deltaAngleX, Vector3.up);
                m_Offset = rotX * m_Offset;
                m_MainCam.transform.rotation = rotX * curRot;
            }
            if(deltaAngleY != 0)
            {
                curRot = m_MainCam.transform.rotation;
                var rotY = Quaternion.AngleAxis(deltaAngleY, m_MainCam.transform.right);
                m_Offset = rotY * m_Offset;
                m_MainCam.transform.rotation = rotY * curRot;
            }
        }
        #endregion

        #region Zoom
        private float m_Radius = 1;
        public override float Distance
        {
            get { return m_Radius; }
            set
            {
                m_Radius = value;
                m_Offset = m_Offset.normalized * m_Radius;
            }
        }
        #endregion

        public override void Update(float totalTime, float deltaTime)
        {
            if (m_Target == null) return;

            UpdateRotation();

            UpdateCamPosPhase();
        }
    }
}