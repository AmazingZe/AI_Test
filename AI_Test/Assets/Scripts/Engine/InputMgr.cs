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
            }
        }
        public override void OnRelease()
        {
            m_VirtualAxises.Clear();
        }
        #endregion

        #region Properties
        private Dictionary<int, SingleAxis> m_VirtualAxises = new Dictionary<int, SingleAxis>();

        private bool lr_changed = false;
        private bool l_Down = false;
        private bool r_Down = false;

        private bool fb_changed = false;
        private bool f_Down = false;
        private bool b_Down = false;
        #endregion

        public override float GetAxis(VirtualAxis axis)
        {
            return m_VirtualAxises[(int)axis].offset;
        }

        public override void Update(float totalTime, float deltaTime)
        {
            fb_changed = lr_changed = false;

            #region WASD Listener
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
            #endregion

            #region Update Axises
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
            #endregion
        }
    }
}