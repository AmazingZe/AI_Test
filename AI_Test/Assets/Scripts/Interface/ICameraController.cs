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
        public abstract Transform LockOnTarget { get; set; }
        
        public abstract float AngleOffsetX { get; set; }
        public abstract float AngleOffsetY { get; set; }
        public abstract float AngleX { get; set; }
        public abstract float AngleY { get; set; }

        public abstract Vector3 Offset { get; }
        public abstract float Distance { get; set; }

        public abstract void Update(float totalTime, float deltaTime);
    }
}