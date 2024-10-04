using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 백준 13단계, 정렬
namespace CodingTest.Baekjon.Level13
{
    public static class Day241004
    {
        public static void Problem18870()
        {
            var count = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var arrSort = arr.Distinct().ToArray();
            Array.Sort(arrSort);

            var cashing = new Dictionary<int, int>();

            for (int i = 0; i < arrSort.Length; i++)
            {
                cashing.Add(arrSort[i], i);
            }

            var sb = new StringBuilder();
            foreach (var num in arr)
            {
                sb.Append($"{cashing[num]} ");
            }
            Console.WriteLine(sb);
        }

        public static void Problem10989()
        {
            var count = int.Parse(Console.ReadLine());
            var arr = new int[10001];
            for (int i = 0; i < count; i++)
            {
                var number = int.Parse(Console.ReadLine());
                arr[number]++;
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i]; j++)
                {
                    sw.WriteLine(i);
                }
            }

        }
    }

    public static class Day241002
    {
        public static void Problem10814()
        {
            var count = int.Parse(Console.ReadLine());
            var members = new Tuple<int, string, int>[count];
            for (int i = 0; i < count; i++)
            {
                var arr = Console.ReadLine().Split(" ");
                members[i] = new(int.Parse(arr[0]), arr[1], i);
            }

            Array.Sort(members, (a, b) =>
            {
                var result = a.Item1 - b.Item1;
                return result != 0 ? result : result = a.Item3 - b.Item3;
            });

            var sb = new StringBuilder();
            foreach (var mem in members)
            {
                sb.AppendLine($"{mem.Item1} {mem.Item2}");
            }
            Console.WriteLine(sb);
        }
    }

    public static class Day241001
    {
        public static void Problem1181()
        {
            var arr = new string[int.Parse(Console.ReadLine())];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Console.ReadLine();
            }

            arr = arr.Distinct().ToArray();
            Array.Sort(arr, (x, y) =>
            {
                if (x.Length > y.Length)
                    return 1;
                else if (x.Length < y.Length)
                    return -1;

                var result = x.CompareTo(y);
                return result != 0 ? result : x.CompareTo(y);
            });

            var sb = new StringBuilder();
            foreach (var data in arr)
            {
                sb.AppendLine(data);
            }
            Console.WriteLine(sb);

            //var count = int.Parse(Console.ReadLine());
            //var hashset = new HashSet<string>(count);
            //var arr = new List<string>();
            //for (int i = 0; i < count; i++)
            //{
            //    var text = Console.ReadLine();
            //    if (hashset.Add(text) == true)
            //        arr.Add(text);
            //}

            //arr.Sort((x, y) =>
            //{
            //    if (x.Length > y.Length)
            //        return 1;
            //    else if (x.Length < y.Length)
            //        return -1;

            //    var result = x.CompareTo(y);
            //    return result != 0 ? result : x.CompareTo(y);
            //});

            //var sb = new StringBuilder();
            //foreach (var data in arr)
            //{
            //    sb.AppendLine(data);
            //}
            //Console.WriteLine(sb);

        }
    }

    public static class Day240930
    {
        public static void Problem11651()
        {
            var arr = new List<int[]>(int.Parse(Console.ReadLine()));
            for (int i = 0; i < arr.Capacity; i++)
            {
                arr.Add(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));
            }

            arr.Sort((x, y) =>
            {
                var result = x[1].CompareTo(y[1]);
                return result != 0 ? result : x[0].CompareTo(y[0]);
            });

            var sb = new StringBuilder();
            foreach (var data in arr)
            {
                sb.AppendLine($"{data[0]} {data[1]}");
            }
            Console.WriteLine(sb);
        }

        public static void Problem11650()
        {
            var arr = new List<int[]>(int.Parse(Console.ReadLine()));
            for (int i = 0; i < arr.Capacity; i++)
            {
                arr.Add(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));
            }

            arr.Sort((x, y) =>
            {
                var result = x[0].CompareTo(y[0]);
                return result != 0 ? result : x[1].CompareTo(y[1]);
            });


            var sb = new StringBuilder();
            foreach (var data in arr)
            {
                sb.AppendLine($"{data[0]} {data[1]}");
            }
            Console.WriteLine(sb);
        }

        public static void Problem1427()
        {
            var input = Console.ReadLine().ToCharArray();
            Array.Sort(input, (x, y) => y.CompareTo(x));
            Console.WriteLine(input);
        }

        public static void Problem2751()
        {
            var arr = new List<int>(int.Parse(Console.ReadLine()));

            for (int i = 0; i < arr.Capacity; i++)
            {
                arr.Add(int.Parse(Console.ReadLine()));
            }
            arr.Sort();

            var sb = new StringBuilder();
            foreach (var num in arr)
            {
                sb.AppendLine($"{num}");
            }

            Console.WriteLine(sb);
        }
    }

    public static class Day240929
    {
        public static void Problem25305()
        {
            var r = int.Parse(Console.ReadLine().Split()[1]);
            var a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(a);
            Console.WriteLine(a[^r]);
        }

        public static void Problem2587()
        {
            var array = new List<int>(5);
            var sum = 0;

            for (int i = 0; i < 5; i++)
            {
                var number = int.Parse(Console.ReadLine());
                array.Add(number);
                sum += number;
            }

            array.Sort();
            Console.WriteLine(sum / 5);
            Console.WriteLine(array[2]);
        }

        public static void Problem2750()
        {
            var array = new List<int>(int.Parse(Console.ReadLine()));

            for (int i = 0; i < array.Capacity; i++)
            {
                array.Add(int.Parse(Console.ReadLine()));
            }
            array.Sort();

            foreach (var num in array)
            {
                Console.WriteLine(num);
            }
        }
    }
}
// 백준 12단계, 브루트 포스
namespace CodingTest.Baekjon.Level12
{
    public static class Day240927
    {
        public static void Problem2839()
        {
            var n = int.Parse(Console.ReadLine());
            var result = -1;

            for (int i = n / 5; i >= 0; i--)
            {
                var remain = n - (5 * i);
                if (remain % 3 == 0)
                {
                    result = i + (remain / 3);
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }

    public static class Day240926
    {
        public static void Problem1436()
        {
            var targetCount = int.Parse(Console.ReadLine());
            var count = 0;
            var num = 665;
            while (count != targetCount)
            {
                num++;
                var text = num.ToString();
                for (int i = 0; i < text.Length - 2; i++)
                {
                    if (text[i] == '6' && text[i + 1] == '6' && text[i + 2] == '6')
                    {
                        count++;
                        break;
                    }
                }
            }

            Console.WriteLine(num);
        }
    }

    public static class Day240925
    {
        public static void Problem1018()
        {
            var nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var strings = new string[nums[0]];
            var min = int.MaxValue;

            for (int i = 0; i < nums[0]; i++)
            {
                strings[i] = Console.ReadLine();
            }

            for (int y = 0; y < nums[0] - 7; y++)
            {
                for (int x = 0; x < nums[1] - 7; x++)
                {
                    var value = Check(x, y);

                    if (min > value)
                        min = value;
                }
            }

            Console.WriteLine(min);

            int Check(int x, int y)
            {
                var startW = 0;
                for (int yy = y; yy < y + 8; yy++)
                {
                    for (int xx = x; xx < x + 8; xx++)
                    {
                        var wb = (yy + xx) % 2;
                        if ((wb == 0 && strings[yy][xx] != 'W') || (wb == 1 && strings[yy][xx] != 'B'))
                            startW++;
                    }
                }

                return startW > 32 ? 64 - startW : startW;
            }
        }
    }

    public static class Day240924
    {
        public static void Problem19532()
        {
            var nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            for (int x = -999; x < 1000; x++)
            {
                for (int y = -999; y < 1000; y++)
                {
                    if (nums[0] * x + nums[1] * y == nums[2] && nums[3] * x + nums[4] * y == nums[5])
                    {
                        Console.WriteLine($"{x} {y}");
                        return;
                    }
                }
            }
        }
    }

    public static class Day240923
    {
        public static void Problem2231()
        {
            var num = int.Parse(Console.ReadLine());
            var result = 0;

            for (int i = num - (9 * num.ToString().Length); i < num; i++)
            {
                if (i > 0)
                {
                    var remain = i;
                    var sum = i;
                    while (remain > 0)
                    {
                        sum += remain % 10;
                        remain /= 10;
                    }

                    if (sum == num)
                    {
                        result = i;
                        break;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }

    public static class Day240922
    {
        public static void Problem2798()
        {
            var input = Console.ReadLine().Split();
            var cards = Array.ConvertAll(Console.ReadLine().Split(), int.Parse); ;
            var targetScore = int.Parse(input[1]);

            Console.WriteLine(Loop(0, 0, 0, 0));

            int Loop(int index, int sum, int count, int bestScore)
            {
                if (count < 3)
                {
                    for (int i = index; i < cards.Length - (2 - count); i++)
                    {
                        var temp = Loop(i + 1, sum + cards[i], count + 1, bestScore);

                        if (temp <= targetScore && bestScore < temp)
                            bestScore = temp;
                    }
                }
                else if (sum <= targetScore && bestScore < sum)
                {
                    bestScore = sum;
                }

                return bestScore;
            }
        }
    }
}

// 백준 11단계, 시간 복잡도
namespace CodingTest.Baekjon.Level11
{
    public static class Day240919
    {
        public static void Problem24313()
        {
            var input = Console.ReadLine().Split();
            var a1 = int.Parse(input[0]);
            var a0 = int.Parse(input[1]);
            var c = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var fn = a1 * n + a0;

            if (fn <= n * c)
                Console.WriteLine(1);
            else
                Console.WriteLine(0);
        }
    }

    public static class Day240918
    {
        public static void Problem24267()
        {
            var n = long.Parse(Console.ReadLine());
            Console.WriteLine((n - 2) * (n - 1) * n / 6);
            Console.WriteLine(3);
        }

        public static void Problem24266()
        {
            var num = long.Parse(Console.ReadLine());
            Console.WriteLine(num * num * num);
            Console.WriteLine(3);
        }

        public static void Problem24265()
        {
            var num = int.Parse(Console.ReadLine());
            long count = 0;
            for (int i = 1; i < num; i++)
            {
                count += num - i;
            }

            Console.WriteLine(count);
            Console.WriteLine(2);
        }

        public static void Problem24264()
        {
            var num = long.Parse(Console.ReadLine());
            Console.WriteLine(num * num);
            Console.WriteLine(2);
        }

        public static void Problem24263()
        {
            var num = Console.ReadLine();
            Console.WriteLine(num);
            Console.WriteLine(1);
        }

        public static void Problem24262()
        {
            Console.ReadLine();
            Console.WriteLine(1);
            Console.WriteLine(0);
        }
    }
}

// 백준 10단계, 기하: 직사각형과 삼각형
namespace CodingTest.Baekjoon.Level10
{
    public static class Day240913
    {
        public static void Problem14215()
        {
            var numbers = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sum = 0;
            var maxValue = int.MinValue;

            for (int j = 0; j < numbers.Length; j++)
            {
                sum += numbers[j];
                if (maxValue < numbers[j])
                    maxValue = numbers[j];
            }

            var distance = sum - maxValue - maxValue;
            if (distance <= 0)
                sum += distance - 1;

            Console.WriteLine(sum);
        }

        public static void Problem5073()
        {
            while (true)
            {
                var input = Console.ReadLine().Split();
                var numbers = new int[] { int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]) };
                var sum = numbers[0] + numbers[1] + numbers[2];

                if (sum != 0)
                {
                    var length = new HashSet<int>();
                    var maxValue = int.MinValue;
                    for (int j = 0; j < numbers.Length; j++)
                    {
                        length.Add(numbers[j]);
                        if (maxValue < numbers[j])
                            maxValue = numbers[j];
                    }

                    if (sum - maxValue - maxValue <= 0)
                        Console.WriteLine("Invalid");
                    else if (length.Count == 1)
                        Console.WriteLine("Equilateral");
                    else if (length.Count == 2)
                        Console.WriteLine("Isosceles");
                    else if (length.Count == 3)
                        Console.WriteLine("Scalene");
                }
                else
                {
                    break;
                }
            }
        }
    }

    public static class Day240912
    {
        public static void Problem10101()
        {
            var angle = new Dictionary<int, int>();
            var sameAngle = 0;
            var sum = 0;

            for (int i = 0; i < 3; i++)
            {
                var num = int.Parse(Console.ReadLine());
                sum += num;
                if (angle.ContainsKey(num) == true)
                    angle[num]++;
                else
                    angle.Add(num, 1);

                if (sameAngle < angle[num])
                    sameAngle = angle[num];
            }

            if (sum != 180)
                Console.WriteLine("Error");
            else if (sameAngle == 1)
                Console.WriteLine("Scalene");
            else if (sameAngle == 2)
                Console.WriteLine("Isosceles");
            else if (sameAngle == 3)
                Console.WriteLine("Equilateral");
        }

        public static void Problem9063()
        {
            var count = int.Parse(Console.ReadLine());
            var xs = new int[] { int.MaxValue, int.MinValue };
            var ys = new int[] { int.MaxValue, int.MinValue };
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var x = int.Parse(input[0]);
                var y = int.Parse(input[1]);
                if (xs[0] > x)
                    xs[0] = x;
                if (xs[1] < x)
                    xs[1] = x;

                if (ys[0] > y)
                    ys[0] = y;
                if (ys[1] < y)
                    ys[1] = y;
            }

            Console.WriteLine((xs[1] - xs[0]) * (ys[1] - ys[0]));
        }

    }

    public static class Day240911
    {
        public static void Problem3009()
        {
            var xs = new Dictionary<int, bool>();
            var ys = new Dictionary<int, bool>();

            for (int i = 0; i < 3; i++)
            {
                var input = Console.ReadLine().Split(" ");
                var x = int.Parse(input[0]);
                var y = int.Parse(input[1]);

                if (xs.TryAdd(x, false) == false)
                    xs[x] = true;

                if (ys.TryAdd(y, false) == false)
                    ys[y] = true;
            }

            var result = new int[2];
            foreach (var x in xs)
            {
                if (x.Value == false)
                    result[0] = x.Key;
            }

            foreach (var y in ys)
            {
                if (y.Value == false)
                    result[1] = y.Key;
            }

            Console.WriteLine($"{result[0]} {result[1]}");
        }

        public static void Problem15984()
        {
            var a = long.Parse(Console.ReadLine());
            Console.WriteLine(a * 4);
        }

        public static void Problem1085()
        {
            var input = Console.ReadLine().Split(" ");
            var result = int.MaxValue;

            var myX = int.Parse(input[0]);
            var myY = int.Parse(input[1]);
            var bound = new int[] { 0, 0, int.Parse(input[2]), int.Parse(input[3]) };

            for (int i = 0; i < bound.Length; i++)
            {
                var target = i % 2 == 0 ? myX : myY;
                var num = Math.Abs(bound[i] - target);

                if (result > num)
                    result = num;
            }

            Console.WriteLine(result);
        }

        public static void Problem27323()
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            Console.WriteLine(a * b);
        }
    }
}
// 백준 9단계, 배수와 소수
namespace CodingTest.Baekjoon.Level9
{
    public static class Day240910
    {
        public static void Problem11653()
        {
            var input = int.Parse(Console.ReadLine());
            if (input == 1)
                return;

            var number = input;

            while (number != 1)
            {
                for (int i = 2; i <= number; i++)
                {
                    if (number % i == 0)
                    {
                        number /= i;
                        Console.WriteLine(i);
                        break;
                    }
                }
            }
        }

        public static void Problem2581()
        {
            var min = int.Parse(Console.ReadLine());
            var max = int.Parse(Console.ReadLine());

            var sum = 0;
            var minNumber = int.MaxValue;

            for (int i = min; i <= max; i++)
            {
                var count = 0;
                for (int j = 1; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        count++;

                        if (count != 1)
                            break;
                    }
                }

                if (count == 1)
                {
                    sum += i;
                    if (minNumber > i)
                        minNumber = i;
                }
            }

            if (sum == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(sum);
                Console.WriteLine(minNumber);
            }
        }
    }

    public static class Day240909
    {
        public static void Problem1978()
        {
            Console.ReadLine();
            var data = Console.ReadLine().Split(" ");
            var result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                int number = int.Parse(data[i]);
                var count = 0;
                for (int j = 1; j < number; j++)
                {
                    if (number % j == 0)
                    {
                        count++;

                        if (count != 1)
                            break;
                    }
                }

                if (count == 1)
                {
                    result++;
                }
            }
            Console.WriteLine(result);
        }

        public static void Problem9506()
        {
            var list = new List<int>();
            while (true)
            {
                var number = int.Parse(Console.ReadLine());
                if (number == -1)
                    break;

                list.Clear();
                var count = number * 0.5f;
                var result = new StringBuilder($"{number} = ");
                var sum = 0;

                for (int i = 1; i <= count; i++)
                {
                    var amount = number % i;
                    if (amount == 0)
                    {
                        sum += i;
                        list.Add(i);
                    }
                }

                if (sum == number)
                {
                    var lastNum = list.Count - 1;
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i == lastNum)
                        {
                            result.Append(list[i]);
                        }
                        else
                        {
                            result.Append($"{list[i]} + ");
                        }
                    }
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine($"{number} is NOT perfect.");
                }
            }
        }
    }

    public static class Day240906
    {
        public static void Problem2501()
        {
            var texts = Console.ReadLine().Split(" ");
            var number = int.Parse(texts[0]);
            var targetCount = int.Parse(texts[1]);
            var count = 0;
            var target = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                    if (count == targetCount)
                    {
                        target = i;
                        break;
                    }
                }
            }

            Console.WriteLine(target);
        }

        public static void Problem5086()
        {
            var texts = new List<string>();
            while (true)
            {
                var text = Console.ReadLine().Split(" ");
                var left = int.Parse(text[0]);
                var right = int.Parse(text[1]);
                if (left != 0 && right != 0)
                {
                    if (left % right == 0)
                        texts.Add("multiple");
                    else if (right % left == 0)
                        texts.Add("factor");
                    else
                        texts.Add("neither");
                }
                else
                {
                    break;
                }
            }

            foreach (var text in texts)
            {
                Console.WriteLine(text);
            }

        }
    }
}

// 백준 8단계 일반 수학 1
namespace CodingTest.Baekjoon.Level8
{
    public static class Day240905
    {
        public static void Problem2869()
        {
            var text = Console.ReadLine().Split(" ");
            var move = int.Parse(text[0]);
            var fall = int.Parse(text[1]);
            var target = int.Parse(text[2]);

            var day = (target - move) / (move - fall) + 1;
            if ((target - move) % (move - fall) != 0)
                day++;

            Console.WriteLine(day);
        }

        public static void Problem1193()
        {
            var target = int.Parse(Console.ReadLine());

            var count = 1;
            var index = 1;
            while (count < target)
            {
                index++;
                count += index;
            }

            target = count - target;
            var child = index - target;
            var mother = 1 + target;

            if (index % 2 == 1)
                Console.WriteLine($"{mother}/{child}");
            else
                Console.WriteLine($"{child}/{mother}");
        }

        public static void Problem2292()
        {
            var target = int.Parse(Console.ReadLine());
            var maxNumber = 1;
            var count = 1;
            while (target > maxNumber)
            {
                maxNumber += (count * 6);
                count++;
            }

            Console.WriteLine(count);
        }
    }

    public static class Day240904
    {
        public static void Problem2720()
        {
            var coins = new int[] { 25, 10, 5, 1 };
            var count = int.Parse(Console.ReadLine());
            var changes = new string[count];

            for (int i = 0; i < count; i++)
            {
                var change = int.Parse(Console.ReadLine());
                for (int j = 0; j < coins.Length; j++)
                {
                    changes[i] += $"{change / coins[j]} ";
                    change = change % coins[j];
                }
            }

            for (int i = 0; i < changes.Length; i++)
            {
                Console.WriteLine(changes[i]);
            }
        }

        public static void Problem2903()
        {
            var count = int.Parse(Console.ReadLine());
            var start = 2;
            for (int i = 0; i < count; i++)
            {
                start += start - 1;
            }
            Console.WriteLine(start * start);
        }
    }

    public static class Day240903
    {
        public static void Problem2745()
        {
            var text = Console.ReadLine().Split(" ");
            var numBase = int.Parse(text[1]);

            int result = 0;
            int count = 0;
            int remain = 0;
            for (int i = text[0].Length - 1; i >= 0; i--)
            {
                int before;
                if (text[0][i] >= 'A')
                    before = text[0][i] - 65 + 10 + remain;
                else
                    before = int.Parse(text[0][i].ToString()) + remain;

                result += before * (int)Math.Pow(numBase, count);
                count++;
            }

            Console.WriteLine(result);
        }

        public static void Problem11005()
        {
            var input = Console.ReadLine().Split(" ");
            var numBase = int.Parse(input[1]);

            var result = new StringBuilder();
            int remain = int.Parse(input[0]);

            while (remain > 0)
            {
                var num = (remain % numBase);
                remain = remain / numBase;
                if (num > 9)
                    result.Insert(0, (char)(65 - 10 + num));
                else
                    result.Insert(0, num);
            }

            Console.WriteLine(result);
        }
    }
}
// 백준 7단계 행렬
namespace CodingTest.Baekjoon.Level7
{
    public static class Day240902
    {
        public static void Problem2563()
        {
            var paper = new bool[101, 101];
            var count = int.Parse(Console.ReadLine());
            var result = 0;
            for (int i = 0; i < count; i++)
            {
                var pos = Console.ReadLine().Split(" ");
                var startX = int.Parse(pos[0]);
                var startY = int.Parse(pos[1]);
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (paper[startX + x, startY + y] == false)
                        {
                            result++;
                            paper[startX + x, startY + y] = true;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }

    public static class Day240829
    {
        public static void Problem10798()
        {
            var texts = new string[5];
            string answer = "";
            for (int i = 0; i < 5; i++)
            {
                texts[i] = Console.ReadLine();
            }

            var index = 0;
            while (index < 15)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (index < texts[i].Length)
                    {
                        answer += texts[i][index];
                    }
                }
                index++;
            }

            Console.WriteLine(answer);
        }
    }

    public static class Day240828
    {
        public static void Problem2566()
        {
            int maxValue = int.MinValue;
            int x = 0;
            int y = 0;

            for (int i = 0; i < 9; i++)
            {
                var array = Console.ReadLine().Split(" ");
                for (int j = 0; j < 9; j++)
                {
                    int arrayNum = int.Parse(array[j]);
                    if (maxValue < arrayNum)
                    {
                        maxValue = arrayNum;
                        x = i;
                        y = j;
                    }
                }
            }

            Console.WriteLine(maxValue);
            Console.WriteLine($"{x + 1} {y + 1}");
        }
    }

    public static class Day240827
    {
        public static void Problem2738()
        {
            var text = Console.ReadLine().Split(' ');
            int[,] ints = new int[int.Parse(text[0]), int.Parse(text[1])];

            var count = ints.GetLength(0) * 2;
            for (int i = 0; i < count; i++)
            {
                var index = i % ints.GetLength(0);
                var array = Console.ReadLine().Split(' ');
                for (int j = 0; j < array.Length; j++)
                {
                    ints[index, j] += int.Parse(array[j]);
                }
            }

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    Console.Write(ints[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

// 백준 6단계 심화 1,
namespace CodingTest.Baekjoon.Level6
{
    public static class Day240823
    {
        public static void Problem25206()
        {
            var grades = new Dictionary<string, float>
            {
                { "A+", 4.5f }, { "A0", 4.0f }, { "B+", 3.5f }, { "B0", 3.0f },
                { "C+", 2.5f }, { "C0", 2.0f }, { "D+", 1.5f }, { "D0", 1.0f }, { "F", 0.0f }
            };

            var scoreScale = 0f;
            var onlyScore = 0f;

            for (int i = 0; i < 20; i++)
            {
                var text = Console.ReadLine().Split(' ');
                if (text[2] != "P")
                {
                    var score = float.Parse(text[1]);
                    onlyScore += score;
                    scoreScale += score * grades[text[2]];
                }
            }

            Console.WriteLine(scoreScale / onlyScore);
        }

        public static void Problem1316()
        {
            var count = int.Parse(Console.ReadLine());
            var checkList = new HashSet<char>();
            var result = 0;
            for (int i = 0; i < count; i++)
            {
                checkList.Clear();
                var text = Console.ReadLine();
                var isLoopText = true;
                for (int j = 0; j < text.Length; j++)
                {
                    var isChecked = checkList.Add(text[j]);
                    if (isChecked == false && text[j - 1] != text[j])
                    {
                        isLoopText = false;
                        break;
                    }
                }

                if (isLoopText == true)
                {
                    result++;
                }
            }

            Console.WriteLine(result);
        }

        public static void Problem2941()
        {
            var croatia = new string[] { "c=", "c-", "dz=", "d-", "lj", "nj", "s=", "z=" };
            var text = new StringBuilder(Console.ReadLine());
            for (int i = 0; i < croatia.Length; i++)
            {
                text.Replace(croatia[i], "0");
            }

            Console.WriteLine(text.Length);
        }

        public static void Problem1157()
        {
            var text = Console.ReadLine().ToUpper();
            var dic = new Dictionary<char, int>();
            var best = '?';
            var maxCount = int.MinValue;

            foreach (char c in text)
            {
                if (dic.TryGetValue(c, out int value) == false)
                    dic.Add(c, 1);
                else
                    dic[c]++;

                if (dic[c] > maxCount)
                {
                    maxCount = dic[c];
                    best = c;
                }
                else if (dic[c] == maxCount)
                {
                    best = '?';
                }
            }

            Console.WriteLine(best);
        }
    }

    public static class Day240820
    {
        public static void Problem10998()
        {
            var text = Console.ReadLine();
            var count = text.Length * 0.5f;
            var result = 1;
            for (int i = 0; i < count; i++)
            {
                if (text[i] != text[text.Length - i - 1])
                {
                    result = 0;
                    break;
                }
            }

            Console.WriteLine(result);
        }

        public static void Problem2444()
        {
            var num = int.Parse(Console.ReadLine());
            var count = 2 * num - 1;
            var texts = new string[count];
            var sb = new StringBuilder();
            for (int i = 0; i < num; i++)
            {
                sb.Clear();
                int left = num - i - 1;
                int right = num + i - 1;
                for (int j = 0; j < count; j++)
                {
                    if (left <= j && j <= right)
                        sb.Append('*');
                    else if (left > j)
                        sb.Append(' ');
                    else
                        break;
                }
                texts[i] = sb.ToString();
            }
            for (int i = num - 1; i >= 0; i--)
            {
                sb.Clear();
                int left = num - i - 1;
                int right = num + i - 1;
                for (int j = 0; j < count; j++)
                {
                    if (left <= j && j <= right)
                        sb.Append('*');
                    else if (left > j)
                        sb.Append(' ');
                    else
                        break;
                }
                texts[count - i - 1] = sb.ToString();
            }

            for (int i = 0; i < texts.Length; i++)
            {
                Console.Write(texts[i]);
                if (i != texts.Length - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        public static void Problem3003()
        {
            var defaultItem = new int[] { 1, 1, 2, 2, 2, 8 };
            var text = Console.ReadLine().Split(' ');
            string result = default;
            for (int i = 0; i < text.Length; i++)
            {
                result += (defaultItem[i] - int.Parse(text[i])).ToString() + " ";
            }
            Console.WriteLine(result);
        }

        public static void Problem52()
        {
            Console.WriteLine("         ,r'\"7");
            Console.WriteLine("r`-_   ,'  ,/");
            Console.WriteLine(" \\. \". L_r'");
            Console.WriteLine("   `~\\/");
            Console.WriteLine("      |");
            Console.WriteLine("      |");
        }
    }
}
// 백준 5단계 문자열,
namespace CodingTest.Baekjoon.Level5
{
    public static class Day240819
    {
        public static void Problem11718()
        {
            while (true)
            {
                var text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                    break;
                Console.WriteLine(text);
            }
        }

        public static void Problem5622()
        {
            var dic = new Dictionary<char, int>()
            {
                {'A', 2 },{'B', 2 },{'C', 2 },
                {'D', 3 },{'E', 3 },{'F', 3 },
                {'G', 4 },{'H', 4 },{'I', 4 },
                {'J', 5 },{'K', 5 },{'L', 5 },
                {'M', 6 },{'N', 6 },{'O', 6 },
                {'P', 7 },{'Q', 7 },{'R', 7 },{'S',7},
                {'T', 8 },{'U', 8 },{'V', 8 },
                {'W', 9 },{'X', 9 },{'Y', 9 },{'Z',9},
            };

            var input = Console.ReadLine();
            int result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += dic[input[i]] + 1;
            }
            Console.WriteLine(result);
        }

        public static void Problem1152()
        {
            var input = Console.ReadLine().Split(' ');
            var count = input.Length;
            if (input[0] == "")
                count--;
            if (input[input.Length - 1] == "")
                count--;
            Console.WriteLine(count);
        }

        public static void Problem2675()
        {
            var count = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var loopCount = int.Parse(input[0]);
                var text = input[1];
                sb.Clear();
                for (int j = 0; j < text.Length; j++)
                {
                    sb.Append(new string(text[j], loopCount));
                }
                Console.WriteLine(sb);
            }
        }

        public static void Problem2908()
        {
            var texts = Console.ReadLine().Split(" ");
            var nums = new int[2];
            for (int i = 0; i < 2; i++)
            {
                var text = texts[i];
                nums[i] = int.Parse($"{text[2]}{text[1]}{text[0]}");
            }

            var max = nums[0] > nums[1] ? nums[0] : nums[1];
            Console.WriteLine(max);
        }
    }

    public static class Day240818
    {
        public static void Problem27866()
        {
            var text = Console.ReadLine();
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(text[number - 1]);
        }

        public static void Problem2743()
        {
            var text = Console.ReadLine();
            Console.WriteLine(text.Length);
        }

        public static void Problem9086()
        {
            var count = int.Parse(Console.ReadLine());
            var texts = new List<string>();
            for (int i = 0; i < count; i++)
            {
                texts.Add(Console.ReadLine());
            }
            foreach (var item in texts)
            {
                Console.WriteLine($"{item[0]}{item[item.Length - 1]}");
            }
        }

        public static void Problem11654()
        {
            var text = Console.ReadLine();
            Console.WriteLine((int)text[0]);
        }

        public static void Problem11720()
        {
            Console.ReadLine();
            var text = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                sum += int.Parse(text[i].ToString());
            }
            Console.WriteLine(sum);
        }

        public static void Problem10809()
        {
            var text = Console.ReadLine();
            var ascllA = 97;
            var answer = new int[26];
            for (int i = 0; i < answer.Length; i++)
            {
                answer[i] = -1;
            }

            for (int i = 0; i < text.Length; i++)
            {
                var code = text[i] - ascllA;
                if (answer[code] == -1)
                {
                    answer[code] = i;
                }
            }
            var sb = new StringBuilder();
            for (int i = 0; i < answer.Length; i++)
            {
                sb.Append(answer[i] + " ");
            }
            Console.WriteLine(sb);
        }
    }
}

// 백준 4단계 1차원 배열,
namespace CodingTest.Baekjoon.Level4
{
    public class Day240628
    {
        public static void Problem1546()
        {
            int count = int.Parse(Console.ReadLine());
            string[] scores = Console.ReadLine().Split(' ');
            float sum = 0;
            int max = int.MinValue;

            for (int i = 0; i < count; i++)
            {
                int score = int.Parse(scores[i]);
                sum += score;
                max = Math.Max(max, score);
            }
            sum = sum / max * 100;

            Console.WriteLine((float)sum / count);
        }

        public static void Problem10811()
        {
            string[] settingInfos = Console.ReadLine().Split(' ');
            int count = int.Parse(settingInfos[1]);
            string[] array = new string[int.Parse(settingInfos[0])];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = $"{i + 1}";
            }

            for (int i = 0; i < count; i++)
            {
                string[] swaps = Console.ReadLine().Split(' ');
                int a = int.Parse(swaps[0]) - 1;
                int b = int.Parse(swaps[1]) - 1;
                Reverse(a, b);
            }

            foreach (string s in array)
            {
                Console.Write($"{s} ");
            }

            void Reverse(int start, int end)
            {
                while (start <= end)
                {
                    var temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;

                    start++;
                    end--;
                }
            }
        }

        public static void Problem3052()
        {
            HashSet<int> array = new HashSet<int>();

            for (int i = 0; i < 10; i++)
            {
                array.Add(int.Parse(Console.ReadLine()) % 42);
            }

            Console.WriteLine(array.Count);
        }

        public static void Problem5597()
        {
            HashSet<int> array = new HashSet<int>(28);
            int find = 0;

            for (int i = 0; i < 28; i++)
            {
                array.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 1; i <= 30; i++)
            {
                if (array.Contains(i) == true)
                    continue;

                Console.WriteLine(i);
                find++;
                if (find >= 2)
                    break;
            }
        }

        public static void Problem10813()
        {
            string[] settingInfos = Console.ReadLine().Split(' ');
            string[] array = new string[int.Parse(settingInfos[0])];
            int count = int.Parse(settingInfos[1]);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = $"{i + 1}";
            }

            for (int i = 0; i < count; i++)
            {
                string[] swaps = Console.ReadLine().Split(' ');
                int a = int.Parse(swaps[0]) - 1;
                int b = int.Parse(swaps[1]) - 1;

                var temp = array[a];
                array[a] = array[b];
                array[b] = temp;
            }

            foreach (string s in array)
            {
                Console.Write($"{s} ");
            }
        }
    }

    public class Day240627
    {
        public static void Problem10810()
        {
            string[] stringArr = Console.ReadLine().Split(' ');
            string[] basket = new string[int.Parse(stringArr[0])];
            int tryIndex = int.Parse(stringArr[1]);

            for (int i = 0; i < tryIndex; i++)
            {
                string[] infoArr = Console.ReadLine().Split(' ');
                int startIndex = int.Parse(infoArr[0]) - 1;
                int endIndex = int.Parse(infoArr[1]) - 1;

                for (int j = startIndex; j <= endIndex; j++)
                {
                    basket[j] = infoArr[2];
                }
            }

            for (int i = 0; i < basket.Length; i++)
            {
                Console.Write($"{basket[i] ?? "0"} ");
            }
        }

        public static void Problem2562()
        {
            int maxIndex = 0;
            int maxValue = int.MinValue;

            for (int i = 0; i < 9; i++)
            {
                int value = int.Parse(Console.ReadLine());
                if (maxValue < value)
                {
                    maxIndex = i;
                    maxValue = value;
                }
            }

            Console.WriteLine(maxValue);
            Console.WriteLine(maxIndex + 1);
        }

        public static void Problem10818()
        {
            int index = int.Parse(Console.ReadLine());
            string[] stringArr = Console.ReadLine().Split(' ');
            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var item in stringArr)
            {
                int num = int.Parse(item);

                if (min > num)
                    min = num;

                if (max < num)
                    max = num;
            }

            Console.WriteLine($"{min} {max}");
        }

        public static void Problem10871()
        {
            string[] infos = Console.ReadLine().Split(' ');
            string[] stringArr = Console.ReadLine().Split(' ');

            int index = int.Parse(infos[0]);
            int target = int.Parse(infos[1]);
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < index; i++)
            {
                if (target <= int.Parse(stringArr[i]))
                    continue;

                result.Append($"{stringArr[i]} ");
            }

            Console.WriteLine(result);
        }

        public static void Problem10807()
        {
            int index = int.Parse(Console.ReadLine());
            string[] stringArr = Console.ReadLine().Split(' ');
            string target = Console.ReadLine();
            int result = 0;

            for (int i = 0; i < index; i++)
            {
                if (stringArr[i] != target)
                    continue;

                result++;
            }

            Console.WriteLine(result);
        }
    }
}

// 백준 3단계 반복문, https://www.acmicpc.net/step/3
namespace CodingTest.Baekjoon.Level3
{
    public class Day240626
    {
        public static void Problem10951()
        {
            int[] ints = new int[2];

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "" || input == default)
                    break;

                string[] strings = input.Split(' ');
                ints[0] = int.Parse(strings[0]);
                ints[1] = int.Parse(strings[1]);

                Console.WriteLine(ints[0] + ints[1]);
            }
        }

        public static void Problem10952()
        {
            int[] ints = new int[2];

            while (true)
            {
                string[] strings = Console.ReadLine().Split(' ');
                if (strings[0] == "0" && strings[1] == "0")
                    break;

                ints[0] = int.Parse(strings[0]);
                ints[1] = int.Parse(strings[1]);

                Console.WriteLine($"{ints[0] + ints[1]}");
            }
        }

        public static void Problem2439()
        {
            int index = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < index; i++)
            {
                sb.Append('*');
                Console.WriteLine(sb.ToString().PadLeft(index));
            }
        }

        public static void Problem2438()
        {
            int index = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < index; i++)
            {
                sb.Append('*');
                Console.WriteLine(sb);
            }
        }

        public static void Problem11022()
        {
            int[] ints = new int[2];
            int index = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                string[] strings = Console.ReadLine().Split(' ');
                ints[0] = int.Parse(strings[0]);
                ints[1] = int.Parse(strings[1]);

                Console.WriteLine($"Case #{i + 1}: {ints[0]} + {ints[1]} = {ints[0] + ints[1]}");
            }
        }

        public static void Problem11021()
        {
            int[] ints = new int[2];
            int index = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                string[] strings = Console.ReadLine().Split(' ');
                ints[0] = int.Parse(strings[0]);
                ints[1] = int.Parse(strings[1]);

                Console.WriteLine($"Case #{i + 1}: {ints[0] + ints[1]}");
            }
        }
    }

    public class Day240625
    {
        public static void Problem1552()
        {
            int index = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                sb.Append($"{Console.ReadLine()} ");
            }
            string[] strings = sb.ToString().Split(' ');
            sb.Clear();

            for (int i = 0; i < index; i++)
            {
                int a = int.Parse(strings[i * 2]);
                int b = int.Parse(strings[i * 2 + 1]);
                sb.AppendLine($"{a + b}");
            }

            Console.WriteLine(sb);
        }

        public static void Problem25314()
        {
            int index = int.Parse(Console.ReadLine()) / 4;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < index; i++)
            {
                sb.Append("long ");
            }
            sb.Append("int");

            Console.WriteLine(sb);
        }

        public static void Problem25304()
        {
            int payment = int.Parse(Console.ReadLine());
            int kind = int.Parse(Console.ReadLine());
            int[] receipts = new int[2];
            int sum = 0;

            for (int i = 0; i < kind; i++)
            {
                var strings = Console.ReadLine().Split(' ');
                receipts[0] = int.Parse(strings[0]);
                receipts[1] = int.Parse(strings[1]);

                sum += receipts[0] * receipts[1];
            }

            if (payment == sum)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        public static void Problem8393()
        {
            int index = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= index; i++)
            {
                sum += i;
            }

            Console.WriteLine(sum);
        }

        public static void Problem10950()
        {
            int[] ints = new int[2];
            int index = int.Parse(Console.ReadLine());

            for (int i = 0; i < index; i++)
            {
                string[] strings = Console.ReadLine().Split(' ');
                ints[0] = int.Parse(strings[0]);
                ints[1] = int.Parse(strings[1]);

                Console.WriteLine(ints[0] + ints[1]);
            }
        }

        public static void Problem2739()
        {
            int a = int.Parse(Console.ReadLine());

            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"{a} * {i} = {a * i}");
            }
        }
    }
}

// 백준 2단계 조건문, https://www.acmicpc.net/step/4
namespace CodingTest.Baekjoon.Level2
{
    public class Day240624
    {
        public static void Problem2480()
        {
            string[] time = Console.ReadLine().Split(' ');
            int one = int.Parse(time[0]);
            int two = int.Parse(time[1]);
            int three = int.Parse(time[2]);
            int reward;

            if (one == two && one == three)
                reward = 10000 + (one * 1000);
            else if (one == two || one == three)
                reward = 1000 + (one * 100);
            else if (two == three)
                reward = 1000 + (two * 100);
            else
            {
                int max = Math.Max(one, two);
                max = Math.Max(max, three);

                reward = max * 100;
            }

            Console.WriteLine(reward);
        }

        public static void Problem2525()
        {
            string[] time = Console.ReadLine().Split(' ');
            int timer = int.Parse(Console.ReadLine());
            int hour = int.Parse(time[0]);
            int min = int.Parse(time[1]);

            int totar = (hour * 60 + min + timer) % 1440;
            Console.WriteLine($"{totar / 60} {totar % 60}");
        }

        public static void Problem2884()
        {
            string[] time = Console.ReadLine().Split(' ');
            int hour = int.Parse(time[0]);
            int min = int.Parse(time[1]);

            min -= 45;
            if (min < 0)
            {
                min = 60 + min;
                hour--;
                if (hour < 0)
                {
                    hour = 24 + hour;
                }
            }

            Console.WriteLine($"{hour} {min}");
        }
    }

    public class Day240621
    {
        public static void Problem14681()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int result;
            if (x > 0)
                result = y > 0 ? 1 : 4;
            else
                result = y > 0 ? 2 : 3;

            Console.WriteLine(result);
        }

        public static void Problem1330()
        {
            string[] input = Console.ReadLine().Split(' ');
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            string compare;
            if (a > b)
                compare = ">";
            else if (a < b)
                compare = "<";
            else
                compare = "==";

            Console.WriteLine(compare);
        }

        public static void Problem9498()
        {
            int input = int.Parse(Console.ReadLine());

            string grade;
            switch (input)
            {
                case >= 90:
                    grade = "A";
                    break;
                case >= 80:
                    grade = "B";
                    break;
                case >= 70:
                    grade = "C";
                    break;
                case >= 60:
                    grade = "D";
                    break;
                default:
                    grade = "F";
                    break;
            }

            Console.WriteLine(grade);
        }

        public static void Problem2753()
        {
            int input = int.Parse(Console.ReadLine());

            string result;
            if (input % 4 == 0 && (input % 100 != 0 || input % 400 == 0))
                result = "1";
            else
                result = "0";

            Console.WriteLine(result);
        }
    }
}

// 백준 1단계 입출력과 사칙연산, https://www.acmicpc.net/step/1
namespace CodingTest.Baekjoon.Level1
{
    public class Day240619
    {
        public static void Problem2557()
        {
            Console.WriteLine("Hello World!");
        }

        public static void Problem1000()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA + numberB);
        }

        public static void Problem1001()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA - numberB);
        }

        public static void Problem10998()
        {
            string input = Console.ReadLine();
            int numberA = int.Parse(input.Substring(0, 1));
            int numberB = int.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA * numberB);
        }

        public static void Problem1008()
        {
            string input = Console.ReadLine();
            double numberA = double.Parse(input.Substring(0, 1));
            double numberB = double.Parse(input.Substring(2, 1));
            Console.WriteLine(numberA / numberB);
        }

        public static void Problem10869()
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

    public class Day240620
    {
        public static void Problem10869()
        {
            string inputID = Console.ReadLine();
            string dup = "??!";
            Console.WriteLine($"{inputID}{dup}");
        }

        public static void Problem18108()
        {
            int BC = int.Parse(Console.ReadLine());
            int ADGap = 543;
            Console.WriteLine(BC - ADGap);
        }

        public static void Problem10430()
        {
            string input = Console.ReadLine();
            int[] numbers = new int[3];
            int findIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int endIndex = input.IndexOf(' ', findIndex);
                if (endIndex != -1)
                {
                    int number = int.Parse(input.Substring(findIndex, endIndex - findIndex));
                    findIndex = endIndex + 1;
                    numbers[i] = number;
                }
                else
                {
                    int number = int.Parse(input.Substring(findIndex, input.Length - findIndex));
                    numbers[i] = number;
                    break;
                }
            }

            Console.WriteLine((numbers[0] + numbers[1]) % numbers[2]);
            Console.WriteLine(((numbers[0] % numbers[2]) + (numbers[1] % numbers[2])) % numbers[2]);
            Console.WriteLine((numbers[0] * numbers[1]) % numbers[2]);
            Console.WriteLine(((numbers[0] % numbers[2]) * (numbers[1] % numbers[2])) % numbers[2]);
        }

        public static void Problem2588()
        {
            int numberA = int.Parse(Console.ReadLine());
            int numberB = int.Parse(Console.ReadLine());

            int placeValue = 1;
            for (int i = 0; i < 3; i++)
            {
                int number = (numberB / placeValue) % 10;
                Console.WriteLine(numberA * number);
                placeValue *= 10;
            }
            Console.WriteLine(numberA * numberB);
        }

        public static void Problem11382()
        {
            string input = Console.ReadLine();
            long answer = 0;
            int findIndex = 0;
            while (true)
            {
                int endIndex = input.IndexOf(' ', findIndex);
                if (endIndex != -1)
                {
                    long number = long.Parse(input.Substring(findIndex, endIndex - findIndex));
                    findIndex = endIndex + 1;
                    answer += number;
                }
                else
                {
                    long number = long.Parse(input.Substring(findIndex, input.Length - findIndex));
                    answer += number;
                    break;
                }
            }

            Console.WriteLine(answer);
        }

        public static void Problem10171()
        {
            Console.WriteLine("\\    /\\");
            Console.WriteLine(" )  ( ')");
            Console.WriteLine("(  /  )");
            Console.WriteLine(" \\(__)|");
        }

        public static void Problem10172()
        {
            Console.WriteLine("|\\_/|");
            Console.WriteLine("|q p|   /}");
            Console.WriteLine("( 0 )\"\"\"\\");
            Console.WriteLine("|\"^\"`    |");
            Console.WriteLine("||_/=\\\\__|");
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
