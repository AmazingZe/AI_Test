namespace GameUtils
{
    public class Pool<T> : Singleton<Pool<T>> where T : class, IPoolable, new()
    {
        private const int InitSize = 8;

        #region Properties
        private int m_FirstFree = 0;

        private T[] m_Pools;
        #endregion

        #region Public_API
        public static T Allocate()
        {
            return Instance._Allocate();
        }
        public static void Recycle(T item)
        {
            if (ReferenceEquals(item, null)) return;

            Instance._Recycle(item);
        }
        #endregion

        #region ISingleton_API
        private Pool() { }

        public override void OnInit()
        {
            m_Pools = new T[InitSize];
            for (int i = 0; i < InitSize; i++)
            {
                m_Pools[i] = new T();
                m_Pools[i].Recycle();
            }
        }

        protected override void _OnRelease()
        {
            
            base._OnRelease();
        }
        #endregion

        private T _Allocate()
        {
            if (m_FirstFree >= m_Pools.Length)
            {
                int oldSize = m_Pools.Length;
                var newPool = new T[oldSize * 2];
                int i = 0;
                for (; i < oldSize; i++)
                    newPool[i] = m_Pools[i];
                for (; i < oldSize * 2; i++)
                {
                    newPool[i] = new T();
                    newPool[i].Recycle();
                }

                m_Pools = newPool;
            }

            return m_Pools[m_FirstFree++];
        }
        private void _Recycle(T item)
        {
            item.Recycle();
            m_Pools[--m_FirstFree] = item;
        }
    }
}