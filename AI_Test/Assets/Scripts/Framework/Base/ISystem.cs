namespace GameFramework
{
    public interface ISystem
    {


        void Init();
        void Update(float targetTime);
        void Release();

        void OnNotice();
    }
}