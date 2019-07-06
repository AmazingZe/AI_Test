namespace GameFramework
{
    using GameRuntime;
    using GameUtils;

    public sealed class EntityFactory : Singleton<EntityFactory>
    {
        #region Properties

        #endregion

        public void AddChar(CharParam param)
        {
            param.SetAI();
        }


        #region Singleton
        private EntityFactory() { }
        public override void OnInit()
        {
            
        }
        protected override void _OnRelease()
        {

            base._OnRelease();
        }
        #endregion
    }
}