namespace GameFramework
{
    using GameUtils;
    using GameCore;

    using UnityEngine;

    using System.Collections.Generic;

    public class SteerManager : Singleton<SteerManager>
    {
        #region Properties

        #endregion

        public void SetTarget(int id, Vector3 target)
        {

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
            base._OnRelease();
        }
        #endregion
    }
}