namespace GamePlay
{
    using System.Collections.Generic;

    using GameUtils;

    public class EntityMgr : Singleton<EntityMgr>
    {
        public static Dictionary<int, string> _charFbxPathDic = new Dictionary<int, string>
        {
            { (int)CharType.Test, "Prefabs/Character/TestBot.prefab"},
        };

        #region Singleton
        private EntityMgr() { }
        public override void Init()
        {
            
        }
        public override void Release()
        {
            
        }
        #endregion
        
    }
}