namespace GamePlay
{
    using UnityEngine;

    using GameInterface;

    public class Entity
    {
        public Entity() { }

        private IAvatar m_Avatar;

        #region Animation

        #endregion

        #region Locomotion
        public virtual void MoveTo(Vector3 des)
        {

        }
        #endregion

        #region StateMachine
        private IStateMachine m_StatemMachine;
        #endregion
    }
}
