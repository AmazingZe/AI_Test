namespace GameFramework
{
    using GameUtils;

    using UnityEngine;

    using System;
    using System.Collections.Generic;

    public class AssetFactory : Singleton<AssetFactory>
    {
        private const string PrefabPath = "Prefabs/";

        private Dictionary<string, UnityEngine.Object> m_CharPrefabs;

        public GameObject LoadChar(string prefabPath)
        {
            UnityEngine.Object instantiateMe;
            if (!m_CharPrefabs.TryGetValue(prefabPath, out instantiateMe))
            {
                instantiateMe = Resources.Load<UnityEngine.Object>(PrefabPath + prefabPath);
                m_CharPrefabs.Add(prefabPath, instantiateMe);
            }
            GameObject retMe = MonoBehaviour.Instantiate(instantiateMe) as GameObject;
            return retMe;
        }

        #region Singleton_APIs
        private AssetFactory() { }
        public override void OnInit()
        {
            m_CharPrefabs = new Dictionary<string, UnityEngine.Object>();
        }
        protected override void _OnRelease()
        {

            base._OnRelease();
        }
        #endregion
    }
}