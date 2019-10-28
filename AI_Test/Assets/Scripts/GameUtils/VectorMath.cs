namespace GameUtils
{
    using UnityEngine;

    public static class VectorMath
    {
        public static float ClosestPointOnSegmentFactor(Vector3 from, Vector3 to, Vector3 point)
        {
            var segment = to - from;
            var dir = point - from;

            return Vector3.Dot(dir, segment) / segment.magnitude;
        }
    }
}