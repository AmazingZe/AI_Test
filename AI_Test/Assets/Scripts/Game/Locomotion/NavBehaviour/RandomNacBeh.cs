namespace GamePlay
{
    public class RandomNavBeh : NavBehSingleton<RandomNavBeh>
    {
        private string m_NavName = "RandomNavBeh";

        private uint m_NavBehID;
        public override uint NavBehID { get { return m_NavBehID; } }

        public override void Init()
        {
            m_NavBehID = (uint)m_NavName.GetHashCode();
        }

        public override void Update(ILMEntity agent)
        {
            
        }
    }
}