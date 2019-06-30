namespace GameFramework
{
    using System;
    using System.Collections.Generic;

    using GameUtils;

    public class EntityManager : Singleton<EntityManager>
    {
        #region Properties
        private Dictionary<int, EntityData> m_EntityDatas;
        #endregion

        #region Public_API
        public static void Update(float targetTime) { Instance._Update(targetTime); }
        public static EntityData GetEntityDataWithID(int id) { return Instance._GetEntityDataWithID(id); }
        public static void Create() { Instance._Create(); }
        #endregion

        private EntityData _GetEntityDataWithID(int id)
        {
            EntityData retMe;

            if (m_EntityDatas.TryGetValue(id, out retMe))
                return retMe;

            return null;
        }

        private void _Create()
        {

        }

        #region Singleton_API
        private EntityManager() { }
        public override void OnInit()
        {
            m_EntityDatas = new Dictionary<int, EntityData>();
        }
        protected override void _OnRelease()
        {
            base._OnRelease();
        }
        #endregion

        private void _Update(float targetTime)
        {

        }
    }


}