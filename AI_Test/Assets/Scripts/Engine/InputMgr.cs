namespace GameEngine
{
    using System.Collections.Generic;
    using UnityEngine;

    using GameInterface;

    public class InputMgr : IInputMgr
    {
        #region Singleton
        public override void OnInit()
        {
            for (int i = 0; i < (int)VirtualAxis.Count; i++)
            {
                var addMe = new SingleAxis();
                addMe.axis = (VirtualAxis)i;
                addMe.offset = 0;
                m_VirtualAxises.Add(i, addMe);
            }
        }
        public override void OnRelease()
        {
            m_VirtualAxises.Clear();
        }
        #endregion

        #region Properties
        private Dictionary<int, SingleAxis> m_VirtualAxises = new Dictionary<int, SingleAxis>((int)VirtualAxis.Count);

        private bool lr_changed = false;
        private bool l_Down = false;
        private bool r_Down = false;

        private bool fb_changed = false;
        private bool f_Down = false;
        private bool b_Down = false;

        private float f_MouseOffsetX = 0;
        private float f_MouseOffsetY = 0;
        #endregion

        public override float GetAxis(VirtualAxis axis)
        {
            return m_VirtualAxises[(int)axis].offset;
        }

        #region Mouse
        public override bool GetMouseDown(int button)
        {
            return Input.GetMouseButton(button);
        }
        public override bool GetMouseUp(int button)
        {
            return Input.GetMouseButtonUp(button);
        }
        public override bool GetMouse(int button)
        {
            return Input.GetMouseButton(button);
        }
        #endregion

        #region Key
        public override bool GetKeyDown(KeyCode keyCode)
        {
            return Input.GetKeyDown(keyCode);
        }
        public override bool GetKeyUp(KeyCode keyCode)
        {
            return Input.GetKeyUp(keyCode);
        }
        public override bool GetKey(KeyCode keyCode)
        {
            return Input.GetKey(keyCode);
        }
        #endregion

        public override void Update(float totalTime, float deltaTime)
        {
            fb_changed = false;
            lr_changed = false;

            #region WASD Update Phase
            if (Input.GetKeyDown(KeyCode.W))
            {
                fb_changed = true;
                f_Down = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                fb_changed = true;
                f_Down = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                fb_changed = true;
                b_Down = true;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                fb_changed = true;
                b_Down = false;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                lr_changed = true;
                l_Down = true;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                lr_changed = true;
                l_Down = false;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                lr_changed = true;
                r_Down = true;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                lr_changed = true;
                r_Down = false;
            }

            if (fb_changed)
            {
                if (f_Down && b_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 0;
                }
                else if (!f_Down && !b_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 0;
                }
                else if (f_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 1;
                }
                else if (b_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = -1;
                }
            }

            if (lr_changed)
            {
                if (l_Down && r_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 0;
                }
                else if (!l_Down && !r_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 0;
                }
                else if (l_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = -1;
                }
                else if (r_Down)
                {
                    m_VirtualAxises[(int)VirtualAxis.AxisZ].offset = 1;
                }
            }
            #endregion

            #region Mouse Update Phase
            m_VirtualAxises[(int)VirtualAxis.MouseAxisX].offset = 0;
            m_VirtualAxises[(int)VirtualAxis.MouseAxisY].offset = 0;
            if (Input.GetMouseButton(1))
            {
                f_MouseOffsetX = Input.GetAxis("Mouse X");
                f_MouseOffsetY = Input.GetAxis("Mouse Y");

                m_VirtualAxises[(int)VirtualAxis.MouseAxisX].offset = f_MouseOffsetX;
                m_VirtualAxises[(int)VirtualAxis.MouseAxisY].offset = f_MouseOffsetY;
            }
            #endregion
        }
    }
}