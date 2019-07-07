namespace GameFramework
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    using GameUtils;

    public sealed class EntityManager : Singleton<EntityManager>
    {
        private const int InitNum = 10;
        private static int m_EntityID = 0;

        #region Properties
        private Scene m_Scene;
        private Dictionary<int, Entity> m_Entities;

        public Scene CurScene
        {
            set { m_Scene = value; }
        }
        #endregion

        #region Public_API
        public int CreateEntity(EntityType type, BaseParam param)
        {
            param.ID = m_EntityID++;
            switch (type)
            {
                case EntityType.Bot:
                    AddBot(param);
                    break;
                case EntityType.Trap:
                    AddTrap(param);
                    break;
                case EntityType.Tool:
                    AddTool(param);
                    break;
                case EntityType.Player:
                    var buildParam = param as CharParam;

                    AddPlayer(buildParam);
                    break;
                default:
                    throw new Exception(GameConst.InvalidEntityType);
            }

            return m_EntityID - 1;
        }
        private Entity AddEntity(GameObject obj, int entityID)
        {
            var newEntity = Pool<Entity>.Allocate();

            newEntity.ID = entityID;
            newEntity.Transform = obj.transform;

            m_Entities.Add(entityID, newEntity);

            m_Scene.AddObject(obj, entityID);

            return newEntity;
        }
        public void RemoveEntity(int id)
        {


            m_Scene.RemoveObject(id);
        }
        
        public static void Update(float totalTime, float deltaTime)
        {
            Instance._Update(totalTime, deltaTime);
        }
        #endregion
        
        // Logic-Entity
        private void AddPlayer(CharParam param)
        {
            var obj =  param.LoadAsset();
            var entity = AddEntity(obj, param.ID);

            param.SetAI(entity);

            CharParam.Recycle(ref param);
        }
        private void AddBot(object param)
        {

        }
        private void AddTrap(object param)
        {

        }
        private void AddTool(object param)
        {

        }

        private void _Update(float totalTime, float deltaTime)
        {

        }

        #region Singleton_API
        private EntityManager() { }
        public override void OnInit()
        {
            m_Entities = new Dictionary<int, Entity>(InitNum);
        }
        protected override void _OnRelease()
        {
            m_Entities.Clear();

            base._OnRelease();
        }
        #endregion
        
    }
}