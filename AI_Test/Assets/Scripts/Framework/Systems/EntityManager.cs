namespace GameFramework
{
    using GameUtils;

    public class EntityManager : Singleton<EntityManager>
    {
        #region Properties
        private int m_EntityNum = 10;
        private int m_FirstFree = 0;

        private Entity[] m_Entities; //Todo:Pool
        #endregion

        #region Public_API
        public void Update(float deltaTime)
        {

            //Update Position
            for (int i = 0; i < m_FirstFree; i++)
            {
                var curPosition = m_Entities[i].transform.position;
                curPosition += deltaTime * m_Entities[i].curVelocity;
                m_Entities[i].transform.position = curPosition;
            }
        }
        
        public Entity Add()
        {
            if(m_FirstFree >= m_EntityNum)
            {

            }
        }
        #endregion

        #region ISingleton_API
        private EntityManager() { }

        public override void OnInit()
        {
            m_Entities = new Entity[m_EntityNum];
            for (int i = 0; i < m_EntityNum; i++) //Todo:Pool
                m_Entities[i] = new Entity();
        }

        protected override void _OnRelease()
        {

            base._OnRelease();
        }
        #endregion
    }
}