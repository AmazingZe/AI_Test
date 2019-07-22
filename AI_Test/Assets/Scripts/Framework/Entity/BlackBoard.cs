namespace GameFramework
{
    using UnityEngine;

    using System.Collections.Generic;

    public class BlackBoard
    {
        #region Properties
        public int ID;

        private Dictionary<int, float> m_FloatElements;
        #endregion

        public Vector3 SimPosition;
    }
}