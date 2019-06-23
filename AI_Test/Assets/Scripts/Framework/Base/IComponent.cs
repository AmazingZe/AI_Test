namespace GameFramework
{
    public interface IComponent
    {


        void Init();
        void Update(float targetTime);
        void Release();


    }
}