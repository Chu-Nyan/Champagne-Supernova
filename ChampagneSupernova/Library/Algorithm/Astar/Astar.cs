using Library.DataStructure;
using System;
using System.Collections.Generic;

namespace ChampagneSupernova.Library.Algorithm.Astar
{
    public class Astar
    {
        private const int MoveStarightCost = 10;
        private const int MoveDiagonalCost = 14;
        private const int Weight = 1;

        private readonly PriorityQueue<Node> _openList;
        private readonly HashSet<Node> _closeList;
        private Node _current;
        private Node _bestNode;
        private int _minH;

        public Astar()
        {
            _openList = new PriorityQueue<Node>(256);
            _closeList = new HashSet<Node>(256);
        }

        public void ChangePathNodeNonAlloc(Node[,] nodes, Vector2 start, Vector2 goal, List<Node> path)
        {
            if (goal.x >= 0 || goal.y >= 0 || goal.x < nodes.GetLength(0) || goal.y < nodes.GetLength(1))
            {
                FindPath(nodes, start, goal);
                var goalNode = _current.Position == goal ? _current : _bestNode; // 길찾기 실패했을 때 가장 유력한 노드로 이동
                ConnectMovementPath(goalNode, path);
                ResetPathNodeData();
            }
        }

        private void FindPath(Node[,] nodes, Vector2 start, Vector2 goal)
        {
            _minH = int.MaxValue;
            _openList.Enqueue(nodes[start.x, start.y]);

            while (_openList.Count > 0 && _closeList.Count < 256)
            {
                _current = _openList.Dequeue();
                _closeList.Add(_current);
                if (_current.Position != goal)
                    AddAroundPathNode(nodes, goal, _current);
                else // _current.Position == goal
                    break;
            }
        }

        private void AddAroundPathNode(Node[,] nodes, Vector2 goal, Node target)
        {
            int centerX = target.Position.x;
            int centerY = target.Position.y;

            int leftX = centerX - 1;
            int rightX = centerX + 1;
            int bottomY = centerY - 1;
            int topY = centerY + 1;

            TryAddPathNode(nodes, goal, leftX, centerY, MoveStarightCost);        // 4
            TryAddPathNode(nodes, goal, rightX, centerY, MoveStarightCost);       // 6
            TryAddPathNode(nodes, goal, centerX, bottomY, MoveStarightCost);      // 2
            TryAddPathNode(nodes, goal, centerX, topY, MoveStarightCost);         // 8

            // 대각선 이동 체크
            TryAddPathNode(nodes, goal, leftX, bottomY, MoveDiagonalCost);        // 1
            TryAddPathNode(nodes, goal, leftX, topY, MoveDiagonalCost);           // 7 
            TryAddPathNode(nodes, goal, rightX, bottomY, MoveDiagonalCost);       // 3
            TryAddPathNode(nodes, goal, rightX, topY, MoveDiagonalCost);          // 9
        }

        private void TryAddPathNode(Node[,] nodes, Vector2 goal, int x, int y, int moveCost)
        {
            if (x < 0 || y < 0 || x >= nodes.GetLength(0) || y >= nodes.GetLength(1)) return;

            var node = nodes[x, y];
            if (_closeList.Contains(node) || node.IsBlocked) return;

            // 대각선 이동 가능 체크
            if (moveCost == MoveDiagonalCost)
            {
                var currentPos = _current.Position;
                var conorPos = node.Position - currentPos;

                if (nodes[currentPos.x + conorPos.x, currentPos.y].IsBlocked
                 || nodes[currentPos.x, currentPos.y + conorPos.y].IsBlocked)
                {
                    return;
                }
            }
            //

            if (_openList.Contains(node) == false)
                AddNewNodeToOpenList(node, goal, moveCost);
            else if (moveCost + _current.AstarData.G + node.AstarData.H < node.AstarData.F)
                RefreshNode(node, moveCost);
        }

        private void AddNewNodeToOpenList(Node node, Vector2 goal, int moveCost)
        {
            node.AstarData.H = CalculateHeuristic(node.Position, goal);
            RefreshNode(node, moveCost);
            _openList.Enqueue(node);
            if (node.AstarData.H < _minH)
            {
                _bestNode = node;
                _minH = node.AstarData.H;
            }
        }

        private void RefreshNode(Node node, int moveCost)
        {
            node.AstarData.BeforeNode = _current;
            var data = node.AstarData;
            int g = moveCost + _current.AstarData.G;
            int h = data.H;
            int f = data.G + h;
            node.AstarData = new(_current, data.QueueIndex, g, h, f);
        }

        private void ConnectMovementPath(Node node, List<Node> path)
        {
            path.Clear();
            path.Add(node);
            var count = 0;
            while (node.AstarData.BeforeNode != null && count < 1000)
            {
                count++;
                node = node.AstarData.BeforeNode;
                path.Add(node);
            }
            path.Reverse();
        }

        private void ResetPathNodeData()
        {
            foreach (var node in _closeList)
            {
                node.ResetPriorityData();
            }
            _closeList.Clear();
            _openList.Clear();
        }

        private int CalculateHeuristic(Vector2 start, Vector2 end)
        {
            // 맨허튼 거리 계산
            int disX = Math.Abs(start.x - end.x);
            int disY = Math.Abs(start.y - end.y);
            return disX + disY << Weight;
        }
    }
}
