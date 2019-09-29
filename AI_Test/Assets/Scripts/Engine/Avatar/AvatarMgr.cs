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
            var obj = MonoBehaviour.Instantiate<GameObject>(fbx);
            retMe.animator = obj.GetComponent<Animator>();
            retMe.transform = obj.transform;
            return retMe;
        }
        public override void RecycleAvatar(IAvatar avatar)
        {
            
        }
    }
}