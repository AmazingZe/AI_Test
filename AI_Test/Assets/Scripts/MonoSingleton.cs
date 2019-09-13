namespace GameEngine
{
    using UnityEngine;

    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        protected static T _Instance = null;
        public static T Instance
        {
            get
            {
                if(ReferenceEquals(_Instance, null))
                {
                    GameObject attachment = GameObject.Find("Singleton Attachment");
                    if (ReferenceEquals(attachment, null))
                    {
                        attachment = new GameObject("Singleton Attachment");
                        DontDestroyOnLoad(attachment);
                    }

                    _Instance = attachment.AddComponent<T>();
                }

                return _Instance;
            }
        }
    }
}