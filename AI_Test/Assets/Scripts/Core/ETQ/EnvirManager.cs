namespace GameCore
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameUtils;
    using GameFramework;

    public class EnvirManager : Singleton<EnvirManager>
    {
        #region Public API
        public void AddMoveEntity(Entity entity, Transform transform)
        {
            var addMe = MoveAgent.Create(entity, transform);
            m_MoveAgents.Add(entity.ID, addMe);
        }
        public void RemoveMoveEntity(int id) { m_MoveAgents.Remove(id); }
        #endregion

        #region Properties
        private Dictionary<int, MoveAgent> m_MoveAgents;
        public Dictionary<int, MoveAgent> MoveAgents
        {
            get { return m_MoveAgents; }
            set { m_MoveAgents = value; }
        }
        #endregion

        #region Singleton
        private EnvirManager() { }

        public override void OnInit()
        {
            m_MoveAgents = new Dictionary<int, MoveAgent>(GameConst.DicitionaryInitNum);
        }
        protected override void _OnRelease()
        {
            m_MoveAgents.Clear();
            m_MoveAgents = null;

            base._OnRelease();
        }
        #endregion
    }
}