namespace GameFramework
{
    using System;

    using UnityEngine;

    using GameUtils;

    public sealed class CharParam : BaseParam, IPoolable
    {
        public const int CharTypeOffset = 8;
        public const int CharTypeMask = 7 << CharTypeOffset;
        #region Pools
        
        public static CharParam Create(int entityID, Vector3 position, PlayerType playerType)
        {
            var retMe = Pool<CharParam>.Allocate();

            retMe.ID = entityID;
            retMe.m_RespawnPos = position;
            retMe.PlayerType = playerType;

            return retMe;
        }
        #endregion
        
        #region Properties
        private Vector3 m_RespawnPos;
        #endregion

        public Vector3 Position
        {
            get { return m_RespawnPos; }
        }
        public PlayerType PlayerType
        {
            get
            {
                int retMe = m_Params & CharTypeMask;
                return (PlayerType)retMe;
            }
            private set
            {
                int val = (int)value;
                m_Params = (m_Params & ~CharTypeMask) | (val << CharTypeOffset);
            }
        }

        public override void SetAI()
        {
            switch (PlayerType)
            {
                case PlayerType.Test:

                    break;
                default:
                    throw new Exception(GameConst.InvalidEntityType);
            }
        }

        #region IPoolable
        public override void Recycle()
        {
            m_RespawnPos = Vector3.zero;
            base.Recycle();
        }
        #endregion
    }
}