namespace GameCore.ETQ
{
    using UnityEngine;

    using System.Collections.Generic;

    using GameFramework;

    public class QuadTree
    {
        struct Node
        {
            public byte count;
            public int child00;
            public MoveAgent agentLink;

            public void Add(MoveAgent agent)
            {
                count++;
                agent.next = agentLink;
                agentLink = agent;
            }
            public void Distribute(Node[] nodes, Rect rect)
            {
                Vector2 center = rect.center;

                while (agentLink != null)
                {
                    Vector3 pos = agentLink.SimPos;
                    var nextAgent = agentLink.next;
                    int offset = child00 +
                                 (pos.x < center.x ? 0 : 1) +
                                 (pos.z < center.y ? 2 : 0);
                    agentLink.next = nodes[offset].agentLink;
                    nodes[offset].agentLink = agentLink;

                    agentLink = nextAgent;
                }
            }
        }
        struct QuadtreeQuery
        {
            public Vector3 pos;

        }

        #region Properties
        private Node[] m_Nodes = new Node[GameConst.DicitionaryInitNum];
        private int filledNodes = 0;
        private int m_LeafSize;
        private Rect m_Rect;
        #endregion

        public QuadTree SetRect(Rect rect)
        {
            m_Rect = rect;
            return this;
        }

        public void Insert(MoveAgent agent)
        {
            int i = 0;
            Rect bound = m_Rect;

            while (true)
            {
                var node = m_Nodes[i];
                if (node.child00 == i)
                {
                    if(node.count < m_LeafSize)
                    {
                        node.Add(agent);
                        break;
                    }
                    else
                    {
                        node.child00 = Grow();
                        node.Distribute(m_Nodes, bound);
                    }
                }

                if (node.child00 != i)
                {
                    int offset = 0;
                    Vector2 center = bound.center;
                    Vector3 pos = agent.SimPos;

                    if (pos.x < center.x)
                    {
                        if (pos.z < center.y)
                        {
                            offset += 2;
                            bound = Rect.MinMaxRect(bound.xMin, center.y, center.x, bound.yMax);
                        }
                        else
                        {
                            offset += 0;
                            bound = Rect.MinMaxRect(bound.xMin, bound.yMin, center.x, center.y);
                        }
                    }
                    else
                    {
                        if (pos.z < center.y)
                        {
                            offset += 3;
                            bound = Rect.MinMaxRect(center.x, bound.yMin, bound.xMax, center.y);
                        }
                        else
                        {
                            offset += 1;
                            bound = Rect.MinMaxRect(center.x, center.y, bound.xMax, bound.yMax);
                        }
                    }

                    i = i + offset;
                }
            }
        }

        public void Query(MoveAgent agent, )
        {

        }
        public void QueryCircle()
        {

        }
        public void QueryRectangle()
        {

        }

        public void Clear()
        {
            m_Nodes = new Node[0];
            filledNodes = 0;
        }

        private int Grow()
        {
            if (filledNodes + 4 > m_Nodes.Length)
            {
                int len = m_Nodes.Length;
                var newNodes = new Node[len * 2];
                for (int i = 0; i < filledNodes; i++)
                    newNodes[i] = m_Nodes[i];
                m_Nodes = newNodes;
            }

            for (int i = 0; i < 4; i++)
            {
                var node = new Node();
                node.child00 = filledNodes;
                m_Nodes[filledNodes++] = node;
            }

            return filledNodes - 4;
        }
    }
}