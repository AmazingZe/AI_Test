namespace GameUtils
{
    using System.Collections.Generic;

    public class SafePool<T> : Singleton<SafePool<T>> where T : class, IPoolable, new ()
    {
        private static object m_Lock = new object();

        private HashSet<T> m_Check;

        #region Public_API
        public static T Allocate()
        {
            lock (m_Lock)
            {
                var retMe = Pool<T>.Allocate();
                Instance.m_Check.Remove(retMe);
                return retMe;
            }
        }
        public static void Recycle(ref T item)
        {
            if (!Instance.m_Check.Add(item)) return;

            Pool<T>.Recycle(ref item);
        }
        #endregion

        #region ISingleton_API
        private SafePool() { }

        public override void OnInit()
        {
            lock (m_Lock)
            {
                m_Check = new HashSet<T>();
            }
        }
        protected override void _OnRelease()
        {
            lock (m_Lock)
            {
                Pool<T>.OnRelease();
                base._OnRelease();
            }
        }
        #endregion
    }
}