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

        
    }
}