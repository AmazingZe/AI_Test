﻿namespace GamePlay
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameUtils;
    using GameInterface;

    public class Entity : IPoolable
    {
        private int m_EntityId;
        public int EntityId
        {
            get { return m_EntityId; }
            set { m_EntityId = value; }
        }

        public Entity()
        {
            m_EntityId = EntityMgr.InvalidEntityId;
            m_Speed = 0.5f;

            m_RouteNodes = new List<Vector3>();

            m_OnPFSucceed = new GameEvent();
            m_OnPFPartial = new GameEvent();
            m_OnPFFailed = new GameEvent();
        }

        public void SetModel(string prefabPath)
        {
            m_Avatar = IAvatarMgr.Instance.GetAvatar(prefabPath);
        }

        #region Properties
        private IAvatar m_Avatar;
        public IAvatar Avatar { get { return m_Avatar; } }

        public Vector3 Position
        {
            get { return m_Avatar == null ? Vector3.zero : m_Avatar.position; }
            set { m_Avatar.position = value; }
        }
        public Vector3 Forward
        {
            get { return m_Avatar == null ? Vector3.zero : m_Avatar.forward; }
            set { m_Avatar.forward = value; }
        }
        #endregion

        //Interaction
        private IStateMachine m_StatemMachine;

        #region Locomotion
        private GameEvent m_OnPFSucceed;
        public GameEvent OnPathFindingSucceed { get { return m_OnPFSucceed; } }
        private GameEvent m_OnPFPartial;
        public GameEvent OnPathFindingPartial { get { return m_OnPFPartial; } }
        private GameEvent m_OnPFFailed;
        public GameEvent OnPathFindingFailed { get { return m_OnPFFailed; } }

        private float m_Speed;
        private Vector3 m_NextPos;

        private List<Vector3> m_RouteNodes;

        public virtual void MoveTo(Vector3 des)
        {

        }
        #endregion



        public void Recycle()
        {
            IAvatarMgr.Instance.RecycleAvatar(m_Avatar);
            m_Avatar = null;
        }
    }
}
