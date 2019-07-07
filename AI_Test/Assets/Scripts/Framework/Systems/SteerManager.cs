namespace GameFramework
{
    using GameUtils;
    using GameCore.Steering;

    using UnityEngine;

    public class SteerManager : Singleton<SteerManager>
    {


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