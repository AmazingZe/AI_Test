namespace GameFramework
{
    using System;
    using System.Collections.Generic;

    using GameUtils;

    public sealed class EntityManager : Singleton<EntityManager>
    {
        #region Properties
        
        #endregion

        #region Public_API

        #endregion
        
        #region Singleton_API
        private EntityManager() { }
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