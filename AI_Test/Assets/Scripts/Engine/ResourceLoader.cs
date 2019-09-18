namespace GameEngine
{
    using System.Collections.Generic;
    using UnityEngine;

    using GameInterface;

    public class ResourceLoader : IResourceLoader
    {
        private static string _PrefabRootPath = "Prefabs/";

        private Dictionary<int, Object> m_PrefabPool;

        #region Singleton
        public override void OnInit()
        {
            m_PrefabPool = new Dictionary<int, Object>(1);
        }
        public override void OnRelease()
        {
            m_PrefabPool.Clear();
        }
        #endregion

        public override Object Load(string prefabPath)
        {
            string tempPath = _PrefabRootPath + prefabPath;
            int hashCode = tempPath.GetHashCode();
            Object target;
            if(!m_PrefabPool.TryGetValue(hashCode, out target))
            {
                target = Resources.Load(tempPath);
                m_PrefabPool[hashCode] = target;
            }
            return target;
        }

    }
}