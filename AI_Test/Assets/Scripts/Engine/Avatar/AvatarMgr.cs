﻿namespace GameEngine
{
    using GameInterface;

    public sealed class AvatarMgr : IAvatarMgr
    {
        #region Singleton
        public override void OnInit()
        {
            
        }
        public override void OnRelease()
        {
            
        }
        #endregion

        public override IAvatar CreateAvatar(string prefabPath)
        {
            Avatar retMe;


            return retMe;
        }
    }
}