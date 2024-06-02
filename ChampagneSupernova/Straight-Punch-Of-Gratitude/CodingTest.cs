using System;
using System.Collections.Generic;
using System.Text;

// N-Queen, https://school.programmers.co.kr/learn/courses/30/lessons/12952
// 백트래킹 대표 알고리즘 문제
namespace CodingTest.NQueen
{
    public class Solution
    {
        private int _length;
        private int _answer;
        private List<Cell> _cells;

        public int solution(int n)
        {
            _cells = new List<Cell>(n);
            _length = n;
            Start(0);
            return _answer;
        }

        public void Start(int y)
        {
            if (y == _length)
            {
                if (_cells.Count == _length)
                    _answer++;
                return;
            }

            for (int i = 0; i < _length; i++)
            {
                if (Promising(i, y) == false)
                    continue;

                var cell = new Cell(i, y);
                _cells.Add(cell);
                Start(y + 1);
                _cells.Remove(cell);
            }
        }

        public bool Promising(int x, int y)
        {
            for (int i = 0; i < _cells.Count; i++)
            {
                if (x == _cells[i].X
                 || y == _cells[i].Y
                 || Math.Abs(x - _cells[i].X) == Math.Abs(y - _cells[i].Y))
                    return false;
            }

            return true;
        }
    }

    public struct Cell
    {
        public int X;
        public int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}

// 조이스틱, https://school.programmers.co.kr/learn/courses/30/lessons/42860
// 탐욕법
namespace CodingTest.JoyStick
{
    public class Solution
    {
        public int solution(string name)
        {
            JoyStick joyStick = new JoyStick(name);
            int answer = 0;

            joyStick.MoveNext(0, 0);
            for (int i = 0; i < name.Length; i++)
            {
                int right = name[i] - 'A';
                int left = 'A' - name[i] + 26;
                answer += left < right ? left : right;
            }
            answer += joyStick.Min;
            return answer;
        }
    }

    public class JoyStick
    {
        public int Length;
        public int Min = int.MaxValue;
        bool[] bools;

        public JoyStick(string text)
        {
            Length = text.Length;
            bools = new bool[Length];
            for (int i = 0; i < Length; i++)
            {
                bools[i] = text[i] == 'A';
            }
        }

        public void MoveNext(int start, int dis)
        {
            if (dis > Length)
                return;

            for (int i = 0; i < Length; i++)
            {
                if (bools[i] == false)
                    break;

                if (i == Length - 1)
                {
                    Min = Math.Min(Min, dis);
                    return;
                }
            }

            int right = int.MaxValue;
            int left = int.MaxValue;
            int rightIndex = start;
            int leftIndex = start;

            for (int i = 0; i < Length; i++)
            {
                if (bools[i] == false)
                {
                    int tempLeft = (start - i + Length) % Length;
                    int tempRight = (i - start + Length) % Length;

                    if (left > tempLeft)
                    {
                        left = tempLeft;
                        leftIndex = i;
                    }
                    if (right > tempRight)
                    {
                        right = tempRight;
                        rightIndex = i;
                    }
                }
            }

            if (left != int.MaxValue)
            {
                bools[leftIndex] = true;
                MoveNext(leftIndex, dis + left);
                bools[leftIndex] = false;
            }
            if (right != int.MaxValue)
            {
                bools[rightIndex] = true;
                MoveNext(rightIndex, dis + right);
                bools[rightIndex] = false;
            }
        }
    }
}

// 양궁대회, https://school.programmers.co.kr/learn/courses/30/lessons/92342
// 완전 탐색과 백트래킹
namespace CodingTest.ArcheryChampionships
{
    public class Solution
    {
        private readonly int[] LionLose = new int[] { -1 };
        private int[] bestShoots;
        private int[] apeachShoot;
        int diff = 0;

        public int[] solution(int n, int[] info)
        {
            bestShoots = new int[11];
            apeachShoot = info;
            diff = int.MinValue;

            for (int i = 0; i < 11; i++)
            {
                Com(new int[11], i, n);
            }

            return diff <= 0 ? LionLose : bestShoots;
        }

        public void Com(int[] current, int startIndex, int n)
        {
            int shoot = apeachShoot[startIndex] + 1;
            if (n - shoot >= 0)
            {
                n -= shoot;
                current[startIndex] = shoot;

                int newDiff = ScoreValue(current, apeachShoot);
                if (newDiff > diff)
                {
                    diff = newDiff;
                    if (n > 0)
                        current[10] = n;

                    Array.Copy(current, bestShoots, 11);
                    current[10] = 0;
                }
                else if (newDiff == diff)
                {
                    if (n > 0)
                        current[10] = n;

                    if (MinShoot(current, bestShoots))
                    {
                        Array.Copy(current, bestShoots, 11);
                    }
                    current[10] = 0;
                }
            }

            for (int i = startIndex + 1; i < 11; i++)
            {
                if (n == 0)
                    break;

                Com(current, i, n);
                current[i] = 0;
            }
        }

        public static bool MinShoot(int[] newTarget, int[] oldTarget)
        {
            for (int i = oldTarget.Length - 1; i >= 0; i--)
            {
                if (oldTarget[i] > newTarget[i])
                    return false;
                else if (oldTarget[i] < newTarget[i])
                    return true;
            }

            return false;
        }

        public static int ScoreValue(int[] lion, int[] apeach)
        {
            int score = 0;
            for (int i = 0; i < lion.Length; i++)
            {
                if (lion[i] != 0 && lion[i] > apeach[i])
                    score += 10 - i;
                else if (apeach[i] != 0 && lion[i] <= apeach[i])
                    score -= 10 - i;
            }

            return score;
        }
    }
}

//택배 배달과 수거하기, https://school.programmers.co.kr/learn/courses/30/lessons/150369
namespace CodingTest.DeliveryAndCollection
{
    public class Solution
    {
        private int _indexD;
        private int _indexP;
        private int _longDis;

        public long solution(int cap, int n, int[] deliveries, int[] pickups)
        {
            long answer = 0;
            _indexD = n - 1;
            _indexP = _indexD;

            while (_indexD >= 0 || _indexP >= 0)
            {
                _longDis = -1;

                _indexD = GoGo(deliveries, cap, _indexD);
                _indexP = GoGo(pickups, cap, _indexP);

                answer += _longDis + 1;
            }

            return answer * 2;
        }

        public int GoGo(int[] pickups, int remainCap, int index)
        {
            while (index >= 0)
            {
                if (pickups[index] <= 0)
                    index--;
                else if (remainCap == 0)
                    break;
                else
                {
                    if (_longDis < index)
                        _longDis = Math.Max(_longDis, index);

                    int value = pickups[index] - remainCap;
                    if (value <= 0)
                    {
                        remainCap = -value;
                        pickups[index] = 0;
                    }
                    else
                    {
                        remainCap = 0;
                        pickups[index] = value;
                    }
                }
            }

            return index;
        }
    }
}

//교점에 별 만들기, https://school.programmers.co.kr/learn/courses/30/lessons/87377
namespace CodingTest.CreateStarAtIntersection
{
    public class Solution
    {
        public string[] solution(int[,] line)
        {
            Dictionary<long, List<Vector2>> vectors = new Dictionary<long, List<Vector2>>();
            int[] a = new int[3];
            int[] b = new int[3];

            var maxXY = new Vector2(long.MinValue, long.MinValue);
            var minXY = new Vector2(long.MaxValue, long.MaxValue);

            int count = line.GetLength(0);
            for (int i = 0; i < count - 1; i++)
            {
                a[0] = line[i, 0];
                a[1] = line[i, 1];
                a[2] = line[i, 2];

                for (int j = i + 1; j < count; j++)
                {
                    b[0] = line[j, 0];
                    b[1] = line[j, 1];
                    b[2] = line[j, 2];

                    if (Vector2.InregerIntersection(a, b, out var vector2) == false)
                        continue;

                    if (vectors.TryAdd(vector2.Y, new List<Vector2>()) == false) { }

                    vectors[vector2.Y].Add(vector2);

                    maxXY.X = Math.Max(maxXY.X, vector2.X);
                    maxXY.Y = Math.Max(maxXY.Y, vector2.Y);

                    minXY.X = Math.Min(minXY.X, vector2.X);
                    minXY.Y = Math.Min(minXY.Y, vector2.Y);
                }
            }

            string[] answer = new string[maxXY.Y - minXY.Y + 1];
            StringBuilder sb = new StringBuilder();
            long width = maxXY.X - minXY.X + 1;
            for (long i = 0; i < width; i++)
            {
                sb.Append('.');
            }
            string defa = sb.ToString();

            for (long i = minXY.Y; i <= maxXY.Y; i++)
            {
                if (vectors.ContainsKey(i) == true)
                {
                    sb.Clear();
                    var list = vectors[i];
                    foreach (var item in list)
                    {
                        if (sb.Length == 0)
                            sb.Append(defa);

                        sb[(int)(item.X - minXY.X)] = '*';
                    }
                    answer[maxXY.Y - i] = sb.ToString();
                }
                else
                {
                    answer[maxXY.Y - i] = defa;
                }
            }

            return answer;
        }
    }

    public struct Vector2
    {
        public long X;
        public long Y;

        public Vector2(long x, long y)
        {
            X = x;
            Y = y;
        }

        public static bool InregerIntersection(int[] a, int[] b, out Vector2 vector2)
        {
            vector2 = new Vector2();

            decimal a1 = a[0];
            decimal a2 = b[0];

            decimal b1 = a[1];
            decimal b2 = b[1];

            decimal c1 = a[2];
            decimal c2 = b[2];

            decimal determinant = a1 * b2 - a2 * b1;
            if (determinant == 0)
            {
                return false;
            }
            else
            {
                decimal x = (b1 * c2 - b2 * c1) / determinant;
                decimal y = (a2 * c1 - a1 * c2) / determinant;

                if (x % 1 != 0 || y % 1 != 0)
                {
                    return false;
                }
                vector2.X = (long)x;
                vector2.Y = (long)y;
                return true;
            }
        }
    }
}

//당구 연습, https://school.programmers.co.kr/learn/courses/30/lessons/169198
namespace CodingTest.BilliardsPractice
{
    public class Solution
    {
        public int[] solution(int m, int n, int startX, int startY, int[,] balls)
        {
            int[] answer = new int[balls.GetLength(0)];
            List<Vector2> list = new List<Vector2>();

            for (int i = 0; i < balls.GetLength(0); i++)
            {
                Vector2 end = new Vector2(balls[i, 0], balls[i, 1]);
                int minDir = int.MaxValue;

                var right = new Vector2(m + (m - startX), startY);
                var left = new Vector2(-startX, startY);
                var top = new Vector2(startX, n + (n - startY));
                var bottom = new Vector2(startX, -startY);

                list.Add(right);
                list.Add(left);
                list.Add(top);
                list.Add(bottom);

                if (startX == end.X)
                {
                    if (startY > end.Y)
                        list.Remove(bottom);
                    else
                        list.Remove(top);
                }
                else if (startY == end.Y)
                {
                    if (startX > end.X)
                        list.Remove(left);
                    else
                        list.Remove(right);
                }

                foreach (var item in list)
                {
                    int lineC = Vector2.Distance(item, end);
                    if (minDir > lineC)
                        minDir = lineC;
                }
                list.Clear();
                answer[i] = minDir;
            }

            return answer;
        }
    }

    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static int Distance(Vector2 a, Vector2 b)
        {
            int disX = b.X - a.X;
            int disY = b.Y - a.Y;

            return (disX) * (disX) + (disY) * (disY);
        }
    }
}

// 빛의 경로 사이클, https://school.programmers.co.kr/learn/courses/30/lessons/86052
namespace CodingTest.LightPathCycle
{
    public enum Dir { N, E, S, W }

    public class Solution
    {
        private Grid[,] _grids;
        private int _MaxX;
        private int _maxY;

        private Grid _startGrid;
        private Dir _startDir;
        private int _hit = 0;

        public int[] solution(string[] grid)
        {
            _MaxX = grid[0].Length;
            _maxY = grid.Length;
            _grids = new Grid[_maxY, _MaxX];

            Dictionary<char, Dir> charChanger = new Dictionary<char, Dir>();
            charChanger.Add('L', Dir.E);
            charChanger.Add('S', Dir.S);
            charChanger.Add('R', Dir.W);

            List<int> answer = new List<int>();
            bool isAdd = false;

            for (int y = 0; y < grid.Length; y++)
            {
                for (int x = 0; x < grid[y].Length; x++)
                {
                    Dir dir = charChanger[grid[y][x]];
                    _grids[y, x] = new Grid(dir, x, y);
                }
            }

            foreach (var item in _grids)
            {
                for (int i = 0; i < 4; i++)
                {
                    _startGrid = item;
                    _startDir = (Dir)i;
                    _hit = 0;

                    if (FindLoop(_startGrid, _startDir))
                    {
                        answer.Add(_hit);
                        isAdd = true;
                    }
                    else if (isAdd == false)
                    {
                        foreach (var item1 in _grids)
                        {
                            item1.Reset();
                        }
                    }
                }
            }

            answer.Sort();
            return answer.ToArray();
        }

        private bool FindLoop(Grid grid, Dir dir)
        {
            grid.Shoot(dir);
            grid = GetDirGrid(dir, grid);

            if (grid.Hit(dir, out dir))
            {
                _hit++;

                if (_startGrid == grid && _startDir == dir)
                {
                    return true;
                }
                else
                {
                    return FindLoop(grid, dir);
                }
            }
            else
            {
                return false;
            }
        }

        private Grid GetDirGrid(Dir output, Grid pivot)
        {
            int currentX = pivot.Position[0];
            int currentY = pivot.Position[1];

            switch (output)
            {
                case Dir.N:
                    currentY = currentY + 1 < _maxY ? currentY + 1 : 0;
                    break;
                case Dir.E:
                    currentX = currentX + 1 < _MaxX ? currentX + 1 : 0;
                    break;
                case Dir.S:
                    currentY = currentY - 1 >= 0 ? currentY - 1 : _maxY - 1;
                    break;
                case Dir.W:
                    currentX = currentX - 1 >= 0 ? currentX - 1 : _MaxX - 1;
                    break;
            }

            return _grids[currentY, currentX];
        }
    }

    class Grid
    {
        private Dictionary<Dir, bool[]> _passDir;
        private Dir _refraction;
        public int[] Position;

        private const int Input = 0;
        private const int OutPut = 1;

        public Grid(Dir refraction, int x, int y)
        {
            _refraction = refraction;
            Position = new int[] { x, y };
            _passDir = new Dictionary<Dir, bool[]>();
            for (int i = 0; i < 4; i++)
            {
                _passDir.Add((Dir)i, new bool[2]);
            }
        }

        public bool Hit(Dir hitDir, out Dir outDir)
        {
            outDir = 0;

            if (_passDir[hitDir][Input] == true)
                return false;

            int dirNumber = (int)hitDir;
            if (_refraction == Dir.E)
                dirNumber += 1;
            else if (_refraction == Dir.W)
                dirNumber += 3;

            outDir = (Dir)(dirNumber % 4);
            _passDir[hitDir][Input] = true;
            return true;
        }

        public bool Shoot(Dir Dir)
        {
            if (_passDir[Dir][OutPut] == true)
                return false;

            _passDir[Dir][OutPut] = true;
            return true;
        }

        public void Reset()
        {
            foreach (var item in _passDir)
            {
                item.Value[Input] = false;
                item.Value[OutPut] = false;
            }
        }
    }
}

// 유사 칸토어 비트열, https://school.programmers.co.kr/learn/courses/30/lessons/148652
// Note : 반복 되는 패턴을 찾아라
namespace CodingTest.SimilarCantorBitSequence
{
    public class Solution
    {
        public int solution(int n, long l, long r)
        {
            int answer = 0;
            for (long i = l - 1; i < r; i++)
            {
                answer += aaa(i);
            }

            return answer;
        }

        public int aaa(long number)
        {
            if (number % 5 == 2)
                return 0;
            else if (number < 4)
                return 1;
            else
                return aaa(number / 5);
        }
    }
}

// 도넛과 막대 그래프, https://school.programmers.co.kr/learn/courses/30/lessons/258711
namespace CodingTest.DonutAndLeafGraph
{
    public class Solution
    {
        public int[] solution(int[,] edges)
        {
            Dictionary<int, Node> lines = new Dictionary<int, Node>();

            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int Index = edges[i, 0];
                int nextIndex = edges[i, 1];

                if (lines.TryAdd(Index, new Node(Index))) { }

                if (lines.TryGetValue(nextIndex, out Node nextNode) == false)
                {
                    nextNode = new Node(nextIndex);
                    lines.Add(nextIndex, nextNode);
                }

                nextNode.Before++;
                lines[Index].Next++;
            }

            int[] answer = new int[] { 0, 0, 0, 0 };
            foreach (var item in lines)
            {
                var node = item.Value;

                if (node.Before == 0 && node.Next >= 2)
                {
                    answer[0] = node.Index;
                }
                else if (node.Next == 0)
                {
                    answer[2]++;
                }
                else if (node.Next == 2 && node.Before >= 2)
                {
                    answer[3]++;
                }
            }

            answer[1] = lines[answer[0]].Next - answer[2] - answer[3];

            return answer;
        }
    }

    public class Node
    {
        public int Index;
        public int Next;
        public int Before;

        public Node(int index)
        {
            Index = index;
            Next = 0;
            Before = 0;
        }
    }
}
