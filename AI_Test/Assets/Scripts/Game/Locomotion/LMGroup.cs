namespace GamePlay
{
    using UnityEngine;

    using System.Collections.Generic;

    public sealed class LMGroup : ILMEntity
    {
        public static void CreateGroup(LMAgent agent)
        {
            var group = new LMGroup();

            group.AddChild(agent);
        }

        #region Properties
        private float m_Radius;
        public override float Radius { get { return m_Radius; } }

        private float m_CurSpeed;
        public override float CurSpeed { get { return m_CurSpeed; } }

        private Vector3 m_CurDirection;
        public override Vector3 CurDirection { get { return m_CurDirection; } }

        public int Count { get { return m_Children.Count; } }

        private List<LMAgent> m_Children;
        #endregion

        private LMGroup()
        {
            m_Children = new List<LMAgent>();
        }

        public override void AddNavBeh(INavBehaviour beh)
        {
            
        }
        public override void RemoveNavBeh(INavBehaviour beh)
        {
            
        }

        public void AddChild(LMAgent agent)
        {
            if (agent.InGroup) return;

            m_Children.Add(agent);
        }
        public void RemoveChild(LMAgent agent)
        {
            if (!agent.InGroup) return;

            m_Children.Remove(agent);
        }

        public override void Update()
        {
            // Update Virtual Entity's Spatial Information

            foreach (var child in m_Children)
            {
                // Arrange Relative Position First
                child.Update();
            }
        }

        #region Properties
        public override void SetPath(List<Vector3> path)
        {
            
        }
        #endregion
    }
}