namespace GameEngine
{
    using System.Collections.Generic;
    using UnityEngine;

    using GameInterface;

    public class ResourceLoader : IResourceLoader
    {
        private static string _PrefabRootPath = "Prefabs/";

        private Dictionary<string, GameObject> m_PrefabPool;

        #region Singleton
        public override void OnInit()
        {
            m_PrefabPool = new Dictionary<string, GameObject>(1);
        }
        public override void OnRelease()
        {
            m_PrefabPool.Clear();
        }
        #endregion

        public override GameObject LoadPrefab(string prefabPath)
        {
            string tempPath = _PrefabRootPath + prefabPath;
            GameObject target;
            if(!m_PrefabPool.TryGetValue(tempPath, out target))
            {
                target = Resources.Load<GameObject>(tempPath);
                m_PrefabPool[tempPath] = target;
            }

            GameObject retMe = MonoBehaviour.Instantiate<GameObject>(target);
            return retMe;
        }
    }
}