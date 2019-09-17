namespace GamePlay
{
    using GameInterface;

    public class Entity
    {
        public Entity() { }
        public void Init()
        {
            m_Avatar = IAvatarMgr.Instance.CreateAvatar();
        }

        private IAvatar m_Avatar;
    }
}