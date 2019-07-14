namespace GameFramework
{
    using GameUtils;

    public class CharEntity : Entity
    {
        public static CharEntity Create(int id, CharType type)
        {
            var retMe = Pool<CharEntity>.Allocate();

            retMe.ID = id;
            retMe.EntityType = EntityType.Char;
            retMe.m_CharType = type;

            return retMe;
        }
        public static void Recycle(ref CharEntity entity)
        {
            Pool<CharEntity>.Recycle(entity);
            entity = null;
        }

        #region Properties
        private CharType m_CharType;
        public CharType CharType { get { return m_CharType; } }


        #endregion

        public override void Recycle()
        {
            base.Recycle();
        }
    }
}