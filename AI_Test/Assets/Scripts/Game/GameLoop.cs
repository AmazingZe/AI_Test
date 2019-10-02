namespace GamePlay
{
    using UnityEngine;

    using GameEngine;

    public delegate void UpdateDel(float totalTime, float deltaTime);

    public class GameLoop : MonoSingleton<GameLoop>
    {
        private GameScene scene = null;

        private float m_TotalTime;

        private void Awake()
        {
            m_TotalTime = 0;
            
            scene = GameScene.Instance;
        }
        private void OnApplicationQuit()
        {
            scene.Release();
            scene = null;
        }

        private void Update()
        {
            m_TotalTime += Time.deltaTime;
            scene.Update(m_TotalTime, Time.deltaTime);
        }
        private void FixedUpdate()
        {
            scene.FixedUpdate(m_TotalTime, Time.deltaTime);
        }
    }
}