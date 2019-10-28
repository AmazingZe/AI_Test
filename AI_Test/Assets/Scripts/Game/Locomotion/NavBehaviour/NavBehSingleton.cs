namespace GamePlay
{
    using System;
    using System.Reflection;

    using GameUtils;

    public abstract class NavBehSingleton<T> : INavBehaviour where T : NavBehSingleton<T>
    {
        protected static T _Instance = null;
        public static T Instance
        {
            get
            {
                if(_Instance == null)
                {
                    Type t = typeof(T);
                    var ctors = t.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                        throw new Exception("Non-Public Constructor() not found! in " + typeof(T));

                    _Instance = ctor.Invoke(null) as T;
                    _Instance.Init();
                }

                return _Instance;
            }
        }

        public abstract uint NavBehID { get; }

        public abstract void Init();

        public abstract void Update(ILMEntity agent);
    }
}