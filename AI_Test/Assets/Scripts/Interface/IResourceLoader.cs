namespace GameInterface
{
    using System;
    using UnityEngine;

    public abstract class IResourceLoader : IBase<IResourceLoader>
    {
        public static IResourceLoader Instance
        {
            get
            {
                if (_Instance == null)
                {
                    Type type = Type.GetType("GameEngine.ResourceLoader");
                    _Instance = Activator.CreateInstance(type) as IResourceLoader;
                }
                return _Instance;
            }
        }

        public abstract UnityEngine.Object Load(string prefabPath);
    }
}