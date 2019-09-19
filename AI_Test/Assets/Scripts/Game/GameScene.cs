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
            m_Doupdate = new GameEvent<float, float>();

            IInputMgr.Instance.OnInit();
        }
        public override void Release()
        {

        }

        #region Update
        private GameEvent<float, float> m_Doupdate;
        public GameEvent<float, float> DoUpdate
        {
            get { return m_Doupdate; }
        }
        public void Update(float totalTime, float deltaTime)
        {
            IInputMgr.Instance.Update(totalTime, deltaTime);

            m_Doupdate.Invoke(totalTime, deltaTime);

            Debug.Log("Axis Z is " + IInputMgr.Instance.GetAxis(VirtualAxis.AxisZ));
        }
        public void FixedUpdate()
        {

        }
        #endregion

        #region Entity-interface
        private Entity m_MainChar;
        public Entity MainChar
        {
            get { return m_MainChar; }
            set { m_MainChar = value; }
        }

        public void AddChar(CharType type)
        {

        }

        private void UpdateEntity()
        {
            // Todo: Update Main Char From InputMgr


        }
        #endregion
    }
}