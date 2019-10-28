namespace GamePlay
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameUtils;

    public class PathInterpolator
    {
        private List<Vector3> m_Path;

        private float m_CurDistance;
        private float m_DistanceToSegmentStart;
        private float m_CurSegmentLen;
        private int m_SegmentIndex;

        private float m_TotalDistance;

        public void Init(List<Vector3> path, Vector3 curPos)
        {
            SetPath(path);
            MoveToCloestPoint(curPos);
        }

        private void SetPath(List<Vector3> path)
        {
            m_Path = path;

            int count = m_Path.Count;
            Vector3 prev = m_Path[0];
            for (int i = 1; i < count; i++)
            {
                Vector3 cur = m_Path[i];
                m_TotalDistance += (cur - prev).magnitude;
                prev = cur;
            }

            m_SegmentIndex = 0;
            m_DistanceToSegmentStart = 0;
            m_CurDistance = 0;
        }
        public void MoveToCloestPoint(Vector3 point)
        {
            int count = m_Path.Count;

            float bestDis = float.PositiveInfinity;
            float bestFactor = 0;
            int bestIndex = 0;
            for (int i = 0; i < count - 1; i++)
            {
                Vector3 from = m_Path[i];
                Vector3 to = m_Path[i + 1];
                float factor = VectorMath.ClosestPointOnSegmentFactor(from, to, point);
                Vector3 pointOnSeg = Vector3.Lerp(from, to, factor);

                float distance = (pointOnSeg - point).sqrMagnitude;
                if (bestDis > distance)
                {
                    bestDis = distance;
                    bestFactor = factor;
                    bestIndex = i;
                }
            }

            MoveToSegment(bestIndex, bestFactor);
        }

        public float Distance
        {
            get { return m_CurDistance; }
            set
            {
                m_CurDistance = value;
                while (m_CurDistance < m_DistanceToSegmentStart && m_SegmentIndex > 0)
                    PrevSegment();
                while (m_CurDistance > m_CurSegmentLen + m_DistanceToSegmentStart && m_SegmentIndex < m_Path.Count - 1)
                    NextSegment();
            }
        }
        public Vector3 Tagent
        {
            get { return (m_Path[m_SegmentIndex + 1] - m_Path[m_SegmentIndex]).normalized; }
        }
        public Vector3 Position
        {
            get
            {
                float len = m_CurDistance - m_DistanceToSegmentStart;
                float factor = len / m_CurSegmentLen;

                return Vector3.Lerp(m_Path[m_SegmentIndex], m_Path[m_SegmentIndex + 1], factor);
            }
        }

        private void MoveToSegment(int segmentIndex, float factor)
        {
            while (m_SegmentIndex < segmentIndex)
                NextSegment();
            while (m_SegmentIndex > segmentIndex)
                PrevSegment();

            m_CurDistance = m_DistanceToSegmentStart + Mathf.Clamp01(factor) * m_CurSegmentLen;
        }

        private void PrevSegment()
        {
            m_SegmentIndex--;

            m_CurSegmentLen = (m_Path[m_SegmentIndex + 1] - m_Path[m_SegmentIndex]).magnitude;
            m_DistanceToSegmentStart -= m_CurSegmentLen;
        }
        private void NextSegment()
        {
            m_SegmentIndex++;

            m_CurSegmentLen = (m_Path[m_SegmentIndex + 1] - m_Path[m_SegmentIndex]).magnitude;
            m_DistanceToSegmentStart += m_CurSegmentLen;
        }
    }
}