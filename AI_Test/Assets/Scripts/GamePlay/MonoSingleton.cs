namespace GameRuntime
{
    using UnityEngine;

    using GameUtils;

    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T m_Instance = null;
        public static T Instance
        {
            get
            {
                if(ReferenceEquals(m_Instance, null))
                {
                    GameObject target = GameObject.Find("SingletonObj");
                    if (target == null)
                        target = new GameObject("SingletonObj");

                    m_Instance = target.AddComponent<T>();
                    m_Instance.OnInit();
                    DontDestroyOnLoad(target);
                }
                return m_Instance;
            }
        }

        protected abstract void OnInit();
        public virtual void OnRelease()
        {
            var target = GameObject.Find("SingletonObj");
            if (target == null) return;
            
            Destroy(m_Instance);
            m_Instance = null;
        }
    }
}