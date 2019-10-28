namespace GamePlay
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameUtils;

    public sealed class LMAgent : ILMEntity, IPoolable
    {
        #region Properties
        private float m_Radius;
        public override float Radius { get { return m_Radius; } }

        private float m_CurSpeed;
        public override float CurSpeed { get { return m_CurSpeed; } }

        private Vector3 m_CurDirection;
        public override Vector3 CurDirection { get { return m_CurDirection; } }

        private Dictionary<uint, INavBehaviour> m_NavBehs;
        
        private bool m_InGroup;
        public bool InGroup
        {
            get { return m_InGroup; }
            set { m_InGroup = value; }
        }

        public Vector3 CurPos;

        private int m_EntityId;
        #endregion

        public LMAgent(int entityId)
        {
            m_Interpolator = new PathInterpolator();
            m_NavBehs = new Dictionary<uint, INavBehaviour>();

            m_InGroup = false;
            m_EntityId = entityId;
        }
        public void Recycle()
        {

        }

        public override void AddNavBeh(INavBehaviour beh)
        {
            uint id = beh.NavBehID;
            INavBehaviour behaviour;
            if (!m_NavBehs.TryGetValue(id, out behaviour))
                m_NavBehs.Add(id, beh);
        }
        public override void RemoveNavBeh(INavBehaviour beh)
        {
            m_NavBehs.Remove(beh.NavBehID);
        }

        public override void Update()
        {
            foreach(var item in m_NavBehs)
            {
                var beh = item.Value;
                beh.Update(this);
            }
        }

        #region Path Follow
        private PathInterpolator m_Interpolator;

        public override void SetPath(List<Vector3> path)
        {
            m_Interpolator.Init(path, CurPos);
        }
        #endregion


    }
}