namespace GameEngine
{
    using UnityEngine;

    using GameInterface;

    public class ResourceLoader : IResourceLoader
    {
        private static string _PrefabRootPath = "Prefabs/";

        #region Singleton
        public override void OnInit()
        {

        }
        public override void OnRelease()
        {

        }
        #endregion

        public override GameObject LoadPrefab(string prefabPath)
        {
            
        }
    }
}