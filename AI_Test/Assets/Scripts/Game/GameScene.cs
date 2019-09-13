namespace GamePlay
{
    using GameUtils;
    using GameInterface;

    using UnityEngine;

    public class GameScene : Singleton<GameScene>
    {
        private GameEvent<float, float> m_Doupdate;

        private GameScene() { }

        public void Update(float totalTime, float deltaTime)
        {
            m_Doupdate.Invoke(totalTime, deltaTime);
        }

        public override void Init()
        {
            m_Doupdate = new GameEvent<float, float>();
            m_Doupdate.AddListener(DoUpdate);
        }
        public override void Release()
        {

        }

        private void DoUpdate(float totalTime, float deltaTime)
        {
            Debug.Log("DoUpdate");
        }
    }
}