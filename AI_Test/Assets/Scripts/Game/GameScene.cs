namespace GamePlay
{
    using GameUtils;
    using GameInterface;

    using UnityEngine;

    public class GameScene : Singleton<GameScene>
    {
        private GameScene() { }
        public override void Init()
        {
            m_Doupdate = new GameEvent();
            m_DoFixedUpdate = new GameEvent();

            IInputMgr.Instance.OnInit();
        }
        public override void Release()
        {

        }

        #region Update
        private GameEvent m_Doupdate;
        public GameEvent DoUpdate
        {
            get { return m_Doupdate; }
        }

        private GameEvent m_DoFixedUpdate;
        public GameEvent DoFixedUpdate
        {
            get { return m_DoFixedUpdate; }
        }

        public void Update(float totalTime, float deltaTime)
        {
            IInputMgr.Instance.Update(totalTime, deltaTime);

            EntityMgr.Instance.Update(totalTime, deltaTime);

            m_Doupdate?.Invoke();
        }
        public void FixedUpdate()
        {
            m_DoFixedUpdate?.Invoke();
        }
        #endregion

        #region Entity-interface
        public void AddChar(CharType type)
        {

        }

        private void UpdateEntity()
        {
            // Todo: Update Main Char From InputMgr


        }
        #endregion

        #region Main Character

        #endregion
    }
}