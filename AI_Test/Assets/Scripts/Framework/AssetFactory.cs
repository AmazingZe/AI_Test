namespace GameFramework
{
    using GameRuntime;

    using UnityEngine;

    using System.Collections.Generic;

    public class AssetFactory : MonoSingleton<AssetFactory>
    {
        private Dictionary<EntityType, Dictionary<int, Object>> m_Prefabs;

        public void LoadAsset(EntityType entityType, int type)
        {
            var prefabPool = m_Prefabs[entityType];
        }

        #region Singleton_APIs
        protected override void OnInit()
        {
            m_Prefabs = new Dictionary<EntityType, Dictionary<int, Object>>();
        }
        public override void OnRelease()
        {

            base.OnRelease();
        }
        #endregion
    }
}