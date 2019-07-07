namespace GameFramework
{
    using UnityEngine;

    using System.Collections.Generic;

    public sealed class Scene_Test : Scene
    {
        #region Properties
        private string m_SceneName = "Scene_Test";

        private Dictionary<int, GameObject> m_GameObjects;
        #endregion

        public override string SceneName { get { return m_SceneName; } }

        public override void AddObject(GameObject obj, int id)
        {
            m_GameObjects.Add(id, obj);
        }
        public override void RemoveObject(int id)
        {
            m_GameObjects.Remove(id);
        }

        public override void OnInit()
        {
            m_GameObjects = new Dictionary<int, GameObject>();

            var instance = EntityManager.Instance;
            instance.CurScene = this;
        }
        public override void OnUpdate(float totalTime, float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                EntityManager.Instance.CreateEntity(EntityType.Player,
                               CharParam.Create(new Vector3(0, 0.5f, 0),
                                                PlayerType.Test));
            }

            EntityManager.Update(totalTime, deltaTime);
        }
        public override void OnExit()
        {
            EntityManager.OnRelease();
            AssetFactory.OnRelease();

            foreach(var item in m_GameObjects)
                MonoBehaviour.Destroy(item.Value);
        }
    }
}