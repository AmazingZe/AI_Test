namespace GameInterface
{
    public abstract class IBase<T>
    {
        protected static T _Instance;

        public abstract void OnInit();
        public abstract void OnRelease();
    }
}