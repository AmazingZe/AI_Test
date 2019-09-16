namespace GameInterface
{
    using System;

    public abstract class IAvatarMgr : IBase<IAvatarMgr>
    {
        public static IAvatarMgr Instance
        {
            get
            {
                if (_Instance == null)
                {
                    Type type = Type.GetType("GameEngine.AvatarMgr");
                    _Instance = Activator.CreateInstance(type) as IAvatarMgr;
                }
                return _Instance;
            }
        }

        public abstract IAvatar CreateAvatar(string prefabPath);
    }
}