using System;
using System.Collections.Generic;
using System.Text;

// 백준 1단계 입출력과 사칙연산, https://www.acmicpc.net/step/1
namespace CodingTest.Baekjoon.Level1
{
    public class Arithmetic
    {
        public void HelloWorld()
        {
            Console.WriteLine("Hello World!");
        }

        public void APlusB()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA + numberB);
        }

        public void AMinusB()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA - numberB);
        }

        public void AMultiplyB()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA * numberB);
        }

        public void ADivideB()
        {
            string input = Console.ReadLine();
            double numberA = double.Parse(input.Substring(0, 1));
            double numberB = double.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA / numberB);
        }

        public void AllArithmetic()
        {
            string input = Console.ReadLine();
            int spaceIndex = input.IndexOf(' ');
            int numberA = int.Parse(input.Substring(0, spaceIndex));
            int numberB = int.Parse(input.Substring(spaceIndex + 1, input.Length - spaceIndex - 1));

            Console.WriteLine(numberA + numberB);
            Console.WriteLine(numberA - numberB);
            Console.WriteLine(numberA * numberB);
            Console.WriteLine(numberA / numberB);
            Console.WriteLine(numberA % numberB);
        }
    }
}

// 하노이의 탑, https://school.programmers.co.kr/learn/courses/30/lessons/12946\
namespace CodingTest.TowerOfHanoi
{
    public class Solution
    {
        private int _index;

        public int[,] solution(int n)
        {
            _index = 0;
            int[,] answer = new int[((int)Math.Pow(2, n) - 1), 2];
            Hanoi(n, 1, 3, 2, answer);
            return answer;
        }

        private void Hanoi(int n, int start, int end, int mid, int[,] answer)
        {
            if (n == 1)
            {
                answer[_index, 0] = start;
                answer[_index, 1] = end;
                _index++;
            }
            else
            {
                Hanoi(n - 1, start, mid, end, answer);
                answer[_index, 0] = start;
                answer[_index, 1] = end;
                _index++;
                Hanoi(n - 1, mid, end, start, answer);
            }
        }
    }
}

// 디펜스 게임, https://school.programmers.co.kr/learn/courses/30/lessons/142085
namespace CodingTest.DefenceGame
{
    public class Solution
    {
        public int solution(int n, int k, int[] enemy)
        {
            int wave = 0;
            Queueue clear = new Queueue();
            while (n >= 0 && wave < enemy.Length)
            {
                n -= enemy[wave];
                clear.Enqueue(enemy[wave]);
                if (n < 0 && k != 0 && clear.Count > 0)
                {
                    while (n < 0 && k > 0)
                    {
                        n += clear.Dequeue();
                        k--;
                    }
                }

                if (n >= 0)
                    wave++;
            }

            return wave;
        }
    }

    public class Queueue
    {
        private List<int> _values = new List<int>() { int.MinValue };
        public int Count = 0;

        public void Enqueue(int value)
        {
            Count++;
            _values.Add(value);
            int index = Count;

            while (index > 1)
            {
                int parent = index >> 1;
                if (_values[parent] > value)
                    break;

                SwapArray(index, parent);
                index = parent;
            }
        }

        public int Dequeue()
        {
            int dequeue = _values[1];
            _values[1] = _values[Count];
            _values.RemoveAt(Count);
            Count--;

            int index = 1;
            while (Count > 0)
            {
                int leftChild = index << 1;
                int rightChild = leftChild + 1;
                int next = index;

                if (leftChild <= Count && _values[leftChild] > _values[next])
                    next = leftChild;
                if (rightChild <= Count && _values[rightChild] > _values[next])
                    next = rightChild;
                if (next == index)
                    break;

                SwapArray(index, next);
                index = next;
            }

            return dequeue;
        }

        public void SwapArray(int index1, int index2)
        {
            int temp = _values[index1];
            _values[index1] = _values[index2];
            _values[index2] = temp;
        }
    }
}

// 광물 캐기, https://school.programmers.co.kr/learn/courses/30/lessons/172927
namespace CodingTest.Mining
{
    public class Solution
    {
        private readonly int[,] Fatigues = new int[,] { { 1, 1, 1 }, { 5, 1, 1 }, { 25, 5, 1 } };

        public int solution(int[] picks, string[] minerals)
        {
            List<Mine> ints = new List<Mine>();
            int maxMineingCount = Math.Min((picks[0] + picks[1] + picks[2]) * 5, minerals.Length);
            for (int i = 0; i < maxMineingCount; i++)
            {
                int maxCount = 5 + i < minerals.Length ? 5 + i : minerals.Length;
                var mine = new Mine();
                for (int j = i; j < maxCount; j++)
                {
                    switch (minerals[j])
                    {
                        case "diamond":
                            mine.Value += 25;
                            mine.Dia++;
                            break;
                        case "iron":
                            mine.Value += 5;
                            mine.Iron++;
                            break;
                        case "stone":
                            mine.Value += 1;
                            mine.Stone++;
                            break;
                    }
                }
                ints.Add(mine);
                i += 4;
            }
            ints.Sort();
            ints.Reverse();

            int answer = 0;
            int check = 0;
            for (int pick = 0; pick < 3; pick++)
            {
                for (int i = 0; i < picks[pick]; i++)
                {
                    if (maxMineingCount <= check * 5)
                        break;

                    var mine = ints[check];
                    answer += Fatigues[pick, 0] * mine.Dia;
                    answer += Fatigues[pick, 1] * mine.Iron;
                    answer += Fatigues[pick, 2] * mine.Stone;
                    check++;
                }
            }

            return answer;
        }
    }

    public struct Mine : IComparable<Mine>
    {
        public int Value;
        public int Dia;
        public int Iron;
        public int Stone;

        public int CompareTo(Mine other)
        {
            if (Value < other.Value)
                return -1;
            else
                return +1;
        }
    }
}

// 멀쩡한 사각형, https://school.programmers.co.kr/learn/courses/30/lessons/62048
namespace CodingTest.ActivationSquare
{
    public class Solution
    {
        // 유클리드 호제법 
        // int.max * int.max < long.max == true
        // 자료형 우선 순위 
        public long solution(int w, int h)
        {
            long a = w;
            long b = h;
            long c;

            while (b != 0)
            {
                c = a % b;
                a = b;
                b = c;
            }

            long gcd = a;
            long empty = ((w / gcd) + (h / gcd) - 1) * gcd;
            return ((long)w * h) - empty;
        }
    }
}

// 점찍기, https://school.programmers.co.kr/learn/courses/30/lessons/140107
namespace CodingTest.ToDot
{
    // x^2 + y^2 = c^2 : 유클리드 거리

    public class Solution
    {
        public long solution(int k, int d)
        {
            long answer = 0;
            long maxLength = (long)d * d;
            for (long i = 0; i <= d; i += k)
            {
                long squareY = i * i;
                long maxX = (long)Math.Sqrt(maxLength - squareY);
                answer += (maxX / k) + 1;
            }

            return answer;
        }
    }
}

//우박수열 정적분, https://school.programmers.co.kr/learn/courses/30/lessons/134239
namespace CodingTest.HailSequenceDefiniteIntegral
{
    public class Solution
    {
        List<double> _extents = new List<double>();
        public double[] solution(int k, int[,] ranges)
        {
            _extents.Clear();
            _extents.Add(0);

            while (k > 1)
            {
                double beforeHeight = k;
                if (k % 2 == 0)
                    k /= 2;
                else
                    k = (k * 3) + 1;

                double extent = (beforeHeight + k) / 2;
                extent += _extents[_extents.Count - 1];
                _extents.Add(extent);
            }

            int length = ranges.GetLength(0);
            double[] answer = new double[length];
            for (int i = 0; i < length; i++)
            {
                int startIndex = ranges[i, 0];
                int endIndex = _extents.Count - 1 + ranges[i, 1];

                answer[i] = startIndex <= endIndex ? _extents[endIndex] - _extents[startIndex] : -1.0f;
            }
            return answer;
        }
    }
}

// 과제 진행하기, https://school.programmers.co.kr/learn/courses/30/lessons/176962
namespace CodingTest.HomworkProgress
{
    public class Solution
    {
        private Plan[] _tempArray;
        private List<string> answers = new List<string>();
        private Stack<Plan> remainStack = new Stack<Plan>();

        public string[] solution(string[,] plans)
        {
            int count = plans.GetLength(0);
            _tempArray = new Plan[count];
            List<Plan> originalPlans = new List<Plan>(count);
            for (int i = 0; i < count; i++)
            {
                string name = plans[i, 0];
                int min = int.Parse(plans[i, 1].Substring(3, 2));
                int hour = int.Parse(plans[i, 1].Substring(0, 2));
                int remain = int.Parse(plans[i, 2]);
                originalPlans.Add(new Plan(name, (hour * 60) + min, remain));
            }
            MergeSort(originalPlans, 0, count - 1);

            while (originalPlans.Count > 0)
            {
                for (int i = 0; i < originalPlans.Count; i++)
                {
                    int nextIndex = i + 1;
                    int gap = 0;
                    if (nextIndex >= originalPlans.Count)
                    {
                        nextIndex = 0;
                        gap += 2400;
                    }
                    gap += originalPlans[nextIndex].Start - originalPlans[i].Start;

                    i -= PushRemainTime(originalPlans, i, gap);
                    if (i < 0)
                        i = -1;
                }
            }

            return answers.ToArray();
        }

        public int PushRemainTime(List<Plan> arr, int index, int remain)
        {
            if (remainStack.Contains(arr[index]) == false)
                remainStack.Push(arr[index]);

            int remove = 0;
            while (remain > 0 && remainStack.Count != 0)
            {
                var item = remainStack.Peek();
                item.Remain -= remain;
                remain = item.Remain <= 0 ? -item.Remain : 0;
                if (item.Remain <= 0)
                {
                    answers.Add(item.Name);
                    arr.Remove(item);
                    remove++;
                    remainStack.Pop();
                }
            }

            return remove;
        }

        public void MergeSort(List<Plan> arr, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);
            Sort(arr, left, mid + 1, right);
        }

        private void Sort(List<Plan> arr, int left, int mid, int right)
        {
            int l = left;
            int m = mid;
            int r = right;

            int index = l;
            while (index <= r)
            {
                if (m > right || l < mid && arr[l].Start <= arr[m].Start)
                    _tempArray[index++] = arr[l++];
                else
                    _tempArray[index++] = arr[m++];
            }

            for (int i = left; i <= right; i++)
            {
                arr[i] = _tempArray[i];
            }
        }
    }

    public class Plan
    {
        public string Name;
        public int Start;
        public int Remain;

        public Plan(string name, int start, int remain)
        {
            Name = name;
            Start = start;
            Remain = remain;
        }
    }
}

// 두 원 사이의 정수 쌍, https://school.programmers.co.kr/learn/courses/30/lessons/181187
// Fail Case : 1조는 long으로 표현이 불가능하지만 double로는 부동 소수점이기에 가능하다.
// 2진수로 표현하는 게 아닌 부호, 가수와 지수로 표현하기 떄문이다.
// 가수 -> 근접값 지수 -> 소수점의 위치
namespace CodingTest.PairOfIntegersBetweenTwoCircles
{
    class Solution
    {
        public long solution(int r1, int r2)
        {
            long answer = 0;
            double r22 = Math.Pow(r2, 2);
            double r21 = Math.Pow(r1, 2);

            for (int i = 1; i <= r2; i++)
            {
                double pow = Math.Pow(i, 2);
                double y2 = Math.Sqrt(r22 - pow);
                double y1 = Math.Sqrt(r21 - pow);
                answer += ((long)y2 - (long)Math.Ceiling(y1) + 1);
            }
            answer *= 4;

            return answer;
        }
    }
}

// 이모티콘 할인 행사, https://school.programmers.co.kr/learn/courses/30/lessons/150368
namespace CodingTest.EmoticonDiscountEvent
{
    public class Solution
    {
        private readonly int[] SaleCase = new int[] { 10, 20, 30, 40 };
        private int[] _emoticons;
        private int[,] _users;
        int[,] _salesInfo;
        int bestSub;
        int bestMoney;

        public int[] solution(int[,] users, int[] emoticons)
        {
            _emoticons = emoticons;
            _users = users;
            _salesInfo = new int[emoticons.Length, 4];
            Check(0, new int[emoticons.Length]);
            return new int[] { bestSub, bestMoney };
        }

        public void Check(int emoticonNum, int[] currentSale)
        {
            for (int i = 0; i < SaleCase.Length; i++)
            {
                if (_salesInfo[emoticonNum, i] == 0)
                {
                    int value = _emoticons[emoticonNum] * (100 - SaleCase[i]) / 100;
                    _salesInfo[emoticonNum, i] = value;
                }
                currentSale[emoticonNum] = SaleCase[i];

                if (emoticonNum + 1 < _emoticons.Length)
                    Check(emoticonNum + 1, currentSale);
                else
                    BuyOrSub(currentSale);
            }
        }

        public void BuyOrSub(int[] currentSale)
        {
            int totalSub = 0;
            int totalMoney = 0;
            for (int i = 0; i < _users.GetLength(0); i++)
            {
                var targetSale = _users[i, 0];
                var money = _users[i, 1];
                int buyEmoticon = 0;

                for (int j = 0; j < currentSale.Length; j++)
                {
                    if (targetSale > currentSale[j])
                        continue;

                    int index = currentSale[j] / 10 - 1;
                    buyEmoticon += _salesInfo[j, index];
                }

                if (buyEmoticon >= money)
                    totalSub++;
                else
                    totalMoney += buyEmoticon;
            }

            MaxValue(totalSub, totalMoney);
        }

        public void MaxValue(int sub, int money)
        {
            if (bestSub < sub)
            {
                bestSub = sub;
                bestMoney = money;
            }
            else if (bestSub == sub && bestMoney < money)
            {
                bestMoney = money;
            }
        }
    }
}

// 혼자 놀기의 달인, https://school.programmers.co.kr/learn/courses/30/lessons/131130
// Fail Case : 순위가 갱신되면 더 낮은 순위들은 밀어내기를 해야함
namespace CodingTest.MasterOfSinglePlay
{
    public class Solution
    {
        // 0. cards =  i + 1번 상자에 담긴 카드
        // 1. 모든 카드는 하나만 존재하기에 분리된 그룹을 이룬다.
        // 2. 최종 값만 구하면 되기 떄문에 카드의 그룹에서 순서에 상관없이 뽑아도 된다
        // 3.cards의 1번 부터 루프를 돌고 이미 돈 카드는 제거
        // 4. 다음 상자가 열려 있을 때 끝나고 가장 큰 값임 (중복이 없기에)
        // 4-1. 끝난 상자값의 count만 비교하면 됨
        // 5. 가장 큰 연결된 노드 2개를 곱하여서 리턴

        HashSet<int> _checkCard;
        int[] _cards;
        int[] _bestValue;

        public int solution(int[] cards)
        {
            _checkCard = new HashSet<int>();
            _bestValue = new int[2];
            _cards = cards;

            for (int i = 0; i < cards.Length; i++)
            {
                int loopCount = LoopCheck(i, 0);
                if (loopCount != 0)
                    DoubleMax(loopCount);
            }

            return _bestValue[0] * _bestValue[1];
        }

        public int LoopCheck(int index, int count)
        {
            if (_checkCard.Contains(index) == true)
                return count;

            count++;
            _checkCard.Add(index);
            return LoopCheck(_cards[index] - 1, count);
        }

        public void DoubleMax(int value)
        {
            if (value > _bestValue[1])
            {
                if (value <= _bestValue[0])
                {
                    _bestValue[1] = value;
                }
                else
                {
                    _bestValue[1] = _bestValue[0];
                    _bestValue[0] = value;
                }
            }
        }
    }
}

// 요격 시스템, https://school.programmers.co.kr/learn/courses/30/lessons/181188
// 병합 정렬, 탐욕법
namespace CodingTest.InterceptionSystem
{
    public class Solution
    {
        private int[,] _sortList;

        public int solution(int[,] targets)
        {
            _sortList = new int[targets.GetLength(0), targets.GetLength(1)];
            MergeSort(targets, 0, targets.GetLength(0) - 1);
            double endNumber = double.MaxValue;
            int count = 1;
            for (int i = 0; i < targets.GetLength(0); i++)
            {
                if (targets[i, 0] < endNumber - 0.5f)
                    endNumber = Math.Min(endNumber, targets[i, 1]);
                else
                {
                    count++;
                    endNumber = targets[i, 1];
                }
            }

            return count;
        }

        public void MergeSort(int[,] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (right + left) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid + 1, right);
            }
        }

        private void Merge(int[,] arr, int left, int mid, int right)
        {
            int l = left;
            int m = mid;
            int r = right;

            int index = l;
            while (index <= r)
            {
                if (m > right || l < mid && arr[l, 0] <= arr[m, 0])
                {
                    _sortList[index, 0] = arr[l, 0];
                    _sortList[index, 1] = arr[l, 1];
                    l++;
                }
                else
                {
                    _sortList[index, 0] = arr[m, 0];
                    _sortList[index, 1] = arr[m, 1];
                    m++;
                }
                index++;
            }

            for (int i = left; i <= right; i++)
            {
                arr[i, 0] = _sortList[i, 0];
                arr[i, 1] = _sortList[i, 1];
            }
        }
    }
}

// 혼자서 하는 틱택토, https://school.programmers.co.kr/learn/courses/30/lessons/160585
namespace CodingTest.StandAloneTicTacTok
{
    public enum Player { None, P1, P2, }

    public class Solution
    {
        public Player[,] boards = new Player[3, 3];
        public int p1Count = 0;
        public int p2Count = 0;
        public Player winner;

        public int solution(string[] board)
        {
            for (int i = 0; i < 9; i++)
            {
                int x = i % 3;
                int y = i / 3;

                if (board[y][x] == 'O')
                {
                    boards[y, x] = Player.P1;
                    p1Count++;
                }
                else if (board[y][x] == 'X')
                {
                    boards[y, x] = Player.P2;
                    p2Count++;
                }
                else
                {
                    boards[y, x] = Player.None;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (CheckSame(boards[i, 0], boards[i, 1]) && CheckSame(boards[i, 0], boards[i, 2]))
                {
                    if (winner != boards[i, 0] && winner != Player.None)
                        return 0;

                    winner = boards[i, 0];
                }
                if (CheckSame(boards[0, i], boards[1, i]) && CheckSame(boards[0, i], boards[2, i]))
                {
                    if (winner != boards[0, i] && winner != Player.None)
                        return 0;

                    winner = boards[0, i];
                }
            }

            if ((CheckSame(boards[0, 0], boards[1, 1]) && CheckSame(boards[0, 0], boards[2, 2])) ||
                (CheckSame(boards[0, 2], boards[1, 1]) && CheckSame(boards[0, 2], boards[2, 0])))
            {
                if (winner != boards[1, 1] && winner != Player.None)
                    return 0;

                winner = boards[1, 1];
            }

            if (p1Count - p2Count != 0 && p1Count - p2Count != 1)
                return 0;
            if (winner != Player.None)
                return Check(winner);

            return 1;
        }

        public int Check(Player winner)
        {
            if (winner == Player.P1 && p1Count - p2Count != 1)
                return 0;
            if (winner == Player.P2 && p1Count - p2Count != 0)
                return 0;

            return 1;
        }

        public bool CheckSame(Player a, Player b)
        {
            if (a == Player.None || b == Player.None)
                return false;
            else if (a == b)
                return true;
            else
                return false;
        }
    }
}

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
