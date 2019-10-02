namespace GameInterface
{
    using System;

    using UnityEngine;

    public abstract class ICameraController : IBase<ICameraController>
    {
        public static ICameraController Instance
        {
            get
            {
                if(_Instance == null)
                {
                    Type type = Type.GetType("GameEngine.CameraController");
                    _Instance = Activator.CreateInstance(type) as ICameraController;
                }

                return _Instance;
            }
        }

        public abstract Camera MainCamera { get; }
        public abstract Transform LockedTarget { get; set; }

        public abstract float Distance { get; set; }

        public abstract float TransitionTime { get; set; }
        public abstract float TranslationSpeed { get; set; }

        public abstract void Update(float totalTime, float deltaTime);
    }
}