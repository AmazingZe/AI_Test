namespace GameUtils
{
    using System.Collections.Generic;

    public class Pool<T> : Singleton<Pool<T>> where T : class, IPoolable, new()
    {
        private Stack<T> m_Pools;

        #region Public API
        public static T Allocate()
        {
            return _Instance.m_Pools.Count == 0 ? new T() : _Instance.m_Pools.Pop();
        }
        public static void Recycle(ref T item)
        {
            if (item == null) return;

            item.Recycle();
            _Instance.m_Pools.Push(item);
            item = null;
        }
        #endregion

        #region Singleton
        private Pool()
        {
            m_Pools = new Stack<T>(8);
        }
        public override void Init() { }
        public override void Release()
        {
            m_Pools.Clear();
        }
        #endregion
    }
}