namespace GameFramework
{
    using GameUtils;
    using GameCore;

    using UnityEngine;

    using System.Collections.Generic;

    public class SteerManager : Singleton<SteerManager>
    {
        #region Properties
        private Dictionary<int, MoveAgent> m_Agents;
        public Dictionary<int, MoveAgent> Agents
        {
            get { return m_Agents; }
            set { m_Agents = value; }
        }
        #endregion

        public void SetTarget(int id, Vector3 target)
        {
            var setMe = m_Agents[id];
            setMe.DesiredPos = target;
        }
        public void SetRoute(int id, List<Vector3> route)
        {

        }

        public void Update(float totalTime, float deltaTime)
        {

        }

        #region Singleton_APIs
        private SteerManager() { }

        public override void OnInit()
        {

        }
        protected override void _OnRelease()
        {
            Agents = null;

            base._OnRelease();
        }
        #endregion
    }
}