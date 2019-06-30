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
        #endregion

        #region Unity_Callback
        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            var gameScene = GameScene.Instance;
            if (!gameScene.TryOpenScene(SceneType.Test))
                gameScene.AddScene(SceneType.Test, new Scene_Test());
        }
        private void Update()
        {
            if (!Application.isPlaying) return;

            m_TotalTime += Time.deltaTime;
            GameScene.OnUpdate(m_TotalTime, Time.deltaTime);
        }
        private void OnApplicationQuit()
        {
            GameScene.Instance.OnRelease();
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