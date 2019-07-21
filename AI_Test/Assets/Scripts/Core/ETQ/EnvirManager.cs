namespace GameCore
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameUtils;
    using GameFramework;

    public class EnvirManager : Singleton<EnvirManager>
    {
        #region Public API

        #endregion

        #region Properties
        
        #endregion

        #region Singleton
        private EnvirManager() { }

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