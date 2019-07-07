namespace GameFramework
{
    using GameCore.AI;
    using GameUtils;

    public class AIFactory : Singleton<AIFactory>
    {


        #region Singleton_APIs
        private AIFactory() { }

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