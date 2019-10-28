namespace GamePlay
{
    using UnityEngine;
    using System.Collections.Generic;


    public abstract class ILMEntity
    {
        public abstract float Radius { get; }

        public abstract float CurSpeed { get; }
        public float DesiredSpeed;

        public abstract Vector3 CurDirection { get; }
        public Vector3 DesiredDir;

        public abstract void AddNavBeh(INavBehaviour beh);
        public abstract void RemoveNavBeh(INavBehaviour beh);

        public abstract void Update();

        public abstract void SetPath(List<Vector3> path);
    }
}