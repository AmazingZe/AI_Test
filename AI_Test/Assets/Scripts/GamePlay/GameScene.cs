﻿namespace GameRuntime
{
    using GameUtils;

    using UnityEngine.SceneManagement;

    using System.Collections.Generic;

    public sealed class GameScene : MonoSingleton<GameScene>
    {
        private const int MaxSceneNum = 3;

        #region Properties
        private Dictionary<SceneType, Scene> m_Scenes;

        private SceneType m_CurType;
        private Scene m_CurScene;
        private Scene m_NextScene;
        #endregion

        #region Public_APIs
        public Scene CurScene { get { return m_CurScene; } }

        public bool TryOpenScene(SceneType sceneType)
        {
            Scene scene;
            if (!m_Scenes.TryGetValue(sceneType, out scene))
                return false;

            m_NextScene = scene;
            return true;
        }
        public void AddScene(SceneType sceneType, Scene newScene)
        {
            m_Scenes.Add(sceneType, newScene);
            m_NextScene = newScene;
        }
        #endregion

        #region Statics
        public static void OnUpdate(float totalTime, float deltaTime) { Instance._OnUpdate(totalTime, deltaTime); }
        #endregion

        #region Singleton_APIs
        protected override void OnInit()
        {
            m_Scenes = new Dictionary<SceneType, Scene>();
        }
        public override void OnRelease()
        {
            if(m_CurScene != null)
            {
                m_CurScene.OnExit();

                
            }

            base.OnRelease();
        }
        #endregion

        private void _OnUpdate(float totalTime, float deltaTime)
        {
            if(m_NextScene != null)
            {
                if (m_CurScene != null)
                    m_CurScene.OnExit();

                SceneManager.LoadScene(m_NextScene.SceneName);
                m_NextScene.OnInit();
                m_CurScene = m_NextScene;
                m_NextScene = null;
            }

            if (m_CurScene == null) return;

            m_CurScene.OnUpdate(totalTime, deltaTime);
        }
    }
}