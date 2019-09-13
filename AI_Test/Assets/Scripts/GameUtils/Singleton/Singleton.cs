namespace GameUtils
{
    using System;
    using System.Reflection;

    public abstract class Singleton<T> where T : Singleton<T>
    {
        protected static T _Instance = null;
        public static T Instance
        {
            get
            {
                if(_Instance == null)
                {
                    Type t = typeof(T);
                    var ctors = t.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                    var ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                    if (ctor == null)
                        throw new Exception("Non-Public Constructor() not found! in " + typeof(T));

                    _Instance = ctor.Invoke(null) as T;
                    _Instance.Init();
                }

                return _Instance;
            }
        }

        public abstract void Init();
        public abstract void Release();
    }
}