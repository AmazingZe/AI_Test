namespace GameInterface
{
    using System;

    public enum VirtualAxis
    {
        AxisX,
        AxisY,
        AxisZ,

        MouseAxisX,
        MouseAxisY,
        MouseAxisZ,

        Count,
    }

    public class SingleAxis
    {
        public VirtualAxis axis { get; set; }
        public float offset { get; set; }
    }

    public abstract class IInputMgr : IBase<IInputMgr>
    {
        public static IInputMgr Instance
        {
            get
            {
                if (_Instance == null)
                {
                    Type type = Type.GetType("GameEngine.InputMgr");
                    _Instance = Activator.CreateInstance(type) as IInputMgr;
                }

                return _Instance;
            }
        }

        public abstract void Update(float totalTime, float deltaTime);

        public abstract float GetAxis(VirtualAxis axis);
        
    }
}