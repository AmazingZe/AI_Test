namespace GameFramework
{
    using GameUtils;

    using GameCore.AI;

    using System.Collections.Generic;

    public class AIManager : Singleton<AIManager>
    {
        #region Properties
        private Dictionary<int, BlackBoard> m_Agents;
        #endregion

        #region Public_API
        public void AddAgent(Entity entity, int id)
        {

        }
        public void RemoveAgent(int id)
        {

        }
        #endregion

        #region Singleton_APIs
        private AIManager() { }

        public override void OnInit()
        {

        }
        protected override void _OnRelease()
        {

            base._OnRelease();
        }
        #endregion
    }
}