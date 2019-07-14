namespace GameFramework
{
    using UnityEngine;

    using GameUtils;

    public sealed class CharParam : BaseParam, IPoolable
    {
        public const int CharTypeOffset = 8;
        public const int CharTypeMask = 7 << CharTypeOffset;
        #region Pools
        
        public static CharParam Create(Vector3 position, CharType playerType)
        {
            var retMe = Pool<CharParam>.Allocate();
            
            retMe.m_RespawnPos = position;
            retMe.PlayerType = playerType;

            return retMe;
        }
        public static void Recycle(ref CharParam param)
        {
            Pool<CharParam>.Recycle(param);

            param = null;
        }
        #endregion
        
        #region Properties
        private Vector3 m_RespawnPos;
        #endregion

        public Vector3 Position
        {
            get { return m_RespawnPos; }
        }
        public CharType PlayerType
        {
            get
            {
                int retMe = m_Params & CharTypeMask;
                return (CharType)retMe;
            }
            private set
            {
                int val = (int)value;
                m_Params = (m_Params & ~CharTypeMask) | (val << CharTypeOffset);
            }
        }

        public override GameObject LoadAsset()
        {
            var assetFactory = AssetFactory.Instance;
            var entityManager = EntityManager.Instance;

            var obj = assetFactory.LoadChar(PlayerType);
            obj.transform.position = Position;
            return obj;
        }
        public override void SetAI(Entity entity)
        {
            var steerManager = SteerManager.Instance;

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