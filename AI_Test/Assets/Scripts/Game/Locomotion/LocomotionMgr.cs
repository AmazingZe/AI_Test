namespace GamePlay
{
    using System.Collections.Generic;

    using GameUtils;

    public class LocomotionMgr : Singleton<LocomotionMgr>
    {
        #region Singleton
        private LocomotionMgr()
        {
            
        }
        public override void Init()
        {
            
        }
        public override void Release()
        {
            
        }
        #endregion

        private Dictionary<int, LMAgent> m_Entities;
        private List<ILMEntity> m_Agents;

        public void RegisterAgent(int entityId)
        {
            LMAgent agent;
            if(!m_Entities.TryGetValue(entityId, out agent))
            {
                agent = new LMAgent(entityId);

            }

        }
        public void UnregisterAgent(int entityId)
        {
            
        }

        public void Update(float totalTime, float deltaTime)
        {


            int count = m_Agents.Count;
            for (int i = 0; i < count; i++)
                m_Agents[i].Update();
        }
    }
}