namespace GameEngine
{
    using System.Collections.Generic;
    using UnityEngine;

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

        public override IAvatar GetAvatar(string prefabPath)
        {
            var fbx = ResourceLoader.Instance.Load(prefabPath) as GameObject;
            Avatar retMe = new Avatar();
            retMe.animator = fbx.GetComponent<Animator>();
            retMe.transform = fbx.transform;
            return retMe;
        }
        public override void RecycleAvatar(IAvatar avatar)
        {
            
        }
    }
}