namespace GameEngine
{
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

        public override IAvatar CreateAvatar(string prefabPath)
        {
            var fbx = ResourceLoader.Instance.LoadPrefab(prefabPath);
            Avatar retMe = new Avatar();
            retMe.Init(fbx);
            return retMe;
        }
    }
}