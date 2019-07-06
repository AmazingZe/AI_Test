namespace GameFramework
{
    using System;
    using System.Collections.Generic;

    using UnityEngine;

    using GameUtils;

    public sealed class EntityManager : Singleton<EntityManager>
    {
        private const int InitNum = 10;

        private NavSystem m_NavSystem; 
        #region Properties
        private Dictionary<int, GameObject> m_Players;
        #endregion

        #region Public_API
        public static void AddEntity(EntityType type, object param)
        {
            switch (type)
            {
                case EntityType.Bot:
                    Instance.AddBot(param);
                    break;
                case EntityType.Trap:
                    Instance.AddTrap(param);
                    break;
                case EntityType.Tool:
                    Instance.AddTool(param);
                    break;
                case EntityType.Player:
                    var buildParam = param as CharParam;
                    Instance.AddPlayer(buildParam);
                    break;
                default:
                    throw new Exception(GameConst.InvalidEntityType);
            }
        }

        public static void Update(float totalTime, float deltaTime)
        {
            Instance._Update(totalTime, deltaTime);
        }
        #endregion
        
        private int AddPlayer(CharParam param)
        {

            return param.ID;
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
            m_Players = new Dictionary<int, GameObject>(InitNum);
        }
        protected override void _OnRelease()
        {
            m_Players.Clear();

            base._OnRelease();
        }
        #endregion
        
    }
}