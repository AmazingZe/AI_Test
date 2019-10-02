namespace GamePlay
{
    using GameUtils;
    using GameInterface;

    using UnityEngine;

    public class GameScene : Singleton<GameScene>
    {
        private GameScene()
        {
            m_Doupdate = new GameEvent();
            m_DoFixedUpdate = new GameEvent();
        }
        public override void Init()
        {
            IInputMgr.Instance.OnInit();
            CameraHelper.Instance.Init();

            IAvatarMgr.Instance.OnInit();
            IResourceLoader.Instance.OnInit();
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

            CameraHelper.Instance.Update(totalTime, deltaTime);

            #region Client Mgr

            EntityMgr.Instance.Update(totalTime, deltaTime);
            
            #endregion

            if (IInputMgr.Instance.GetKeyDown(KeyCode.Space))
            {
                var entity = EntityMgr.Instance.CreateEntity(CharType.Test, true);
                CameraHelper.Instance.LockOnTarget = entity;
            }
                

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

        #endregion
    }
}