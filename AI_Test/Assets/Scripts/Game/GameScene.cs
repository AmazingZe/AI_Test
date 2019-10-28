namespace GamePlay
{
    using GameUtils;
    using GameInterface;

    using UnityEngine;

    public class GameScene : Singleton<GameScene>
    {
        #region Properties
        private GameScene()
        {
            m_Ray = new Ray();

            m_Doupdate = new GameEvent();
            m_DoFixedUpdate = new GameEvent();
        }
        public override void Init()
        {
            IInputMgr.Instance.OnInit();

            IAvatarMgr.Instance.OnInit();
            IResourceLoader.Instance.OnInit();

            InitMainChar();
        }
        public override void Release()
        {

        }
        #endregion

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

            CharController.Instance.Update();

            CameraHelper.Instance.Update(totalTime, deltaTime);

            LocomotionMgr.Instance.Update(totalTime, deltaTime);

            m_Doupdate?.Invoke();
        }
        public void FixedUpdate(float totalTime, float deltaTime)
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
        private CharController m_CharController;

        private Entity m_MainChar;
        public Entity MainChar
        {
            get { return m_MainChar; }
        }
        
        private void InitMainChar()
        {
            m_MainChar = new Entity();
            m_MainChar.SetModel("Character/TestBot");
        }
        #endregion

        private Ray m_Ray;
        private void RaycastEntity()
        {
            RaycastHit hit;
            if(Physics.Raycast(m_Ray, out hit))
            {

            }
        }
    }
}