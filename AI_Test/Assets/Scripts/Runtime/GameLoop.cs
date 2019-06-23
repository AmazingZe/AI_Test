namespace GameRuntime
{
    using GameFramework;

    using UnityEngine;

    using System.Collections.Generic;

    public class GameLoop : MonoBehaviour
    {
        private static GameLoop m_Instance = null;

        #region Properties
        private float m_TotalTime = 0;
        private List<ISystem> m_Systems;
        #endregion

        #region Unity_Callback
        private void Start()
        {
            m_Systems = new List<ISystem>();
        }
        private void Update()
        {
            m_TotalTime += Time.deltaTime;

            foreach (var system in m_Systems)
                system.Update(m_TotalTime);


        }
        #endregion

        #region Public_API
        public GameLoop Instance
        {
            get
            {
                if(ReferenceEquals(m_Instance, null))
                    m_Instance = GameObject.Find("GameLoop").GetComponent<GameLoop>();

                return m_Instance;
            }
        }
        #endregion
    }
}