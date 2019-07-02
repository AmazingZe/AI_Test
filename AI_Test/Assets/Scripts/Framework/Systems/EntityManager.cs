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
        public static void Update(float totalTime, float deltaTime)
        {
            Instance._Update(totalTime, deltaTime);
        }
        #endregion
        
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