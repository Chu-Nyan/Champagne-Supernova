using System.Collections.Generic;

// 빛의 경로 사이클, https://school.programmers.co.kr/learn/courses/30/lessons/86052
namespace LightPathCycle
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
