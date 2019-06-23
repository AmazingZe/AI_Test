namespace GameUtils
{
    using GameUtils.Singleton;

    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        private static T m_Instance = null;
        public static T Instance
        {
            get
            {
                if (ReferenceEquals(m_Instance, null))
                    m_Instance = SingletonCreator.Create<T>();

                return m_Instance;
            }
        }
        public static void OnRelease()
        {
            m_Instance._OnRelease();
        }

        public abstract void OnInit();

        protected virtual void _OnRelease() { m_Instance = null; }
    }
}