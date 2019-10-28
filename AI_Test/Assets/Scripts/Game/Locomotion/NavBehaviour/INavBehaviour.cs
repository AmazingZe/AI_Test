namespace GamePlay
{
    public interface INavBehaviour
    {
        uint NavBehID { get; }

        void Update(ILMEntity agent);
    }
}