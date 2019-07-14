namespace GameFramework
{
    using GameUtils;

    using UnityEngine;

    using System;
    using System.Collections.Generic;

    public class AssetFactory : Singleton<AssetFactory>
    {
        private const string PrefabPath = "Prefabs/";

        private Dictionary<EntityType, Dictionary<int, UnityEngine.Object>> m_Prefabs;

        public GameObject LoadChar(CharType type)
        {
            UnityEngine.Object instantiateMe;
            var prefabPool = m_Prefabs[EntityType.Char];
            if (!prefabPool.TryGetValue((int)type, out instantiateMe))
            {
                switch (type)
                {
                    case CharType.Test:
                        instantiateMe = Resources.Load<UnityEngine.Object>(PrefabPath + "Test_Prefab");
                        break;
                    default:
                        throw new Exception(GameConst.InvalidEntityType);
                }
                prefabPool.Add((int)type, instantiateMe);
            }
            GameObject retMe = MonoBehaviour.Instantiate(instantiateMe) as GameObject;
            return retMe;
        }

        #region Singleton_APIs
        private AssetFactory() { }
        public override void OnInit()
        {
            m_Prefabs = new Dictionary<EntityType, Dictionary<int, UnityEngine.Object>>();
            System.Array values = System.Enum.GetValues(typeof(EntityType));
            foreach (var value in values)
                m_Prefabs.Add((EntityType)value, new Dictionary<int, UnityEngine.Object>());
        }
        protected override void _OnRelease()
        {

            base._OnRelease();
        }
        #endregion
    }
}