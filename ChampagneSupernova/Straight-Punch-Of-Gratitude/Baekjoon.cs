using ChampagneSupernova.Library.Data_Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingTest.Baekjoon
{
    public class Day250407
    {
        public static void Problem2346()
        {
            var count = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var dequeue = new Deque<int[]>();
            var answer = "";
            for (int i = 0; i < count; i++)
            {
                var dir = items[i];
                if (dir > 0)
                    dir--;
                dequeue.EnqueueFirst(new int[] { i, dir });
            }

            while (dequeue.Count > 0)
            {
                var item = dequeue.DequeueLast();
                answer += $"{item[0] + 1} ";

                dequeue.Rotate(item[1]);
            }

            Console.WriteLine(answer);
        }
    }

    public class Day241204
    {
        public static void Problem4779()
        {
            var sb = new System.Text.StringBuilder();
            var answer = new System.Text.StringBuilder();
            while (true)
            {
                try
                {
                    var length = (int)Math.Pow(3, int.Parse(Console.ReadLine()));
                    sb.Append("".PadRight(length, '-'));
                    bit(0, length - 1, length);
                    answer.AppendLine(sb.ToString());
                    sb.Clear();
                }
                catch (Exception)
                {
                    break;
                }
            }
            Console.WriteLine(answer);

            void bit(int start, int end, int count)
            {
                if (count == 1)
                    return;

                var value = count / 3;
                sb.Replace('-', ' ', start + value, value);

                bit(start, start + value - 1, value);
                bit(end - value + 1, end, value);
            }
        }
    }

    public class Day241203
    {
        public static void Porlbem28279()
        {
            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            var n = int.Parse(Console.ReadLine());
            var list = new LinkedList<int>();

            for (int i = 0; i < n; i++)
            {
                var nx = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                switch (nx[0])
                {
                    case 1:
                        list.AddFirst(nx[1]);
                        break;
                    case 2:
                        list.AddLast(nx[1]);
                        break;
                    case 3:
                        sw.WriteLine($"{(list.Count > 0 ? list.First.Value : -1)}");
                        if (list.Count > 0)
                            list.RemoveFirst();
                        break;
                    case 4:
                        sw.WriteLine($"{(list.Count > 0 ? list.Last.Value : -1)}");
                        if (list.Count > 0)
                            list.RemoveLast();
                        break;
                    case 5:
                        sw.WriteLine($"{list.Count}");
                        break;
                    case 6:
                        sw.WriteLine($"{(list.Count == 0 ? 1 : 0)}");
                        break;
                    case 7:
                        sw.WriteLine($"{(list.Count > 0 ? list.First.Value : -1)}");
                        break;
                    case 8:
                    default:
                        sw.WriteLine($"{(list.Count > 0 ? list.Last.Value : -1)}");
                        break;
                }
            }
        }
    }

    public class Day241202
    {
        public static void Problem11866()
        {
            var nk = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var answer = new List<int>(nk[0]);
            var stack = new Queue<int>();
            for (int i = 1; i <= nk[0]; i++)
            {
                stack.Enqueue(i);
            }

            while (stack.Count > 0)
            {
                for (int i = 0; i < nk[1] - 1; i++)
                {
                    stack.Enqueue(stack.Dequeue());
                }
                answer.Add(stack.Dequeue());
            }

            Console.WriteLine($"<{string.Join(",", answer)}>");
        }

        public static void Problem2164()
        {
            var count = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            for (int i = 1; i <= count; i++)
            {
                queue.Enqueue(i);
            }

            while (queue.Count > 1)
            {
                queue.Dequeue();
                queue.Enqueue(queue.Dequeue());
            }

            Console.WriteLine(queue.Dequeue());
        }
    }

    public class Day241129
    {
        public static void Problem18258()
        {
            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            var count = int.Parse(Console.ReadLine());
            var queue = new Queue<int>();
            var lastItem = 0;

            for (int i = 0; i < count; i++)
            {
                var nx = Console.ReadLine().Split();
                if (nx[0] == "push")
                {
                    queue.Enqueue(int.Parse(nx[1]));
                    lastItem = int.Parse(nx[1]);
                }
                else if (nx[0] == "pop")
                    sw.WriteLine(queue.TryDequeue(out var result) == false ? -1 : result);
                else if (nx[0] == "front")
                    sw.WriteLine(queue.TryPeek(out var result) == false ? -1 : result);
                else if (nx[0] == "size")
                    sw.WriteLine(queue.Count);
                else if (nx[0] == "empty")
                    sw.WriteLine(queue.Count == 0 ? 1 : 0);
                else if (nx[0] == "back")
                    sw.WriteLine(queue.Count == 0 ? -1 : lastItem);
            }
        }

        public static void Problem12789()
        {
            var goal = int.Parse(Console.ReadLine());
            var students = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var stack = new Stack<int>();
            var currentQueue = 1;
            var arrPivot = 0;

            while (currentQueue <= goal)
            {
                if (arrPivot < goal && students[arrPivot] == currentQueue)
                {
                    arrPivot++;
                    currentQueue++;
                }
                else if (stack.TryPeek(out var item) == true && item == currentQueue)
                {
                    stack.Pop();
                    currentQueue++;
                }
                else if (arrPivot < goal)
                {
                    stack.Push(students[arrPivot]);
                    arrPivot++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(currentQueue - 1 == goal ? "Nice" : "Sad");
        }
    }

    public class Day241128
    {
        public static void Problem4949()
        {
            var stack = new Stack<char>();

            while (true)
            {
                var text = Console.ReadLine();
                if (text == ".")
                    break;

                var isLineSuccess = true;
                for (int i = 0; i < text.Length; i++)
                {
                    var t = text[i];
                    if (t == '.')
                    {
                        if (stack.Count == 0 && isLineSuccess == true)
                            Console.WriteLine("yes");
                        else
                            Console.WriteLine("no");

                        isLineSuccess = true;
                        stack.Clear();
                    }
                    else if (t == '(' || t == '[')
                    {
                        stack.Push(t);
                    }
                    else if (t == ')' || t == ']')
                    {
                        var target = t == ')' ? '(' : '[';
                        if (stack.TryPop(out var result) == false || result != target)
                        {
                            isLineSuccess = false;
                        }
                    }
                }
            }
        }

        public static void Problem10773()
        {
            var stack = new Stack<int>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var value = int.Parse(Console.ReadLine());
                if (value == 0)
                    stack.Pop();
                else
                    stack.Push(value);
            }

            var result = 0;
            while (stack.Count > 0)
            {
                result += stack.Pop();
            }

            Console.WriteLine(result);
        }
    }

    public class Day241127
    {
        public static void Problem27278()
        {
            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            var stack = new Stack<int>();
            var count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var nx = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

                switch (nx[0])
                {
                    case 1:
                        One(nx[1]);
                        break;
                    case 2:
                        Two();
                        break;
                    case 3:
                        Three();
                        break;
                    case 4:
                        Four();
                        break;
                    case 5:
                    default:
                        Five();
                        break;
                }
            }

            void One(int value)
            {
                stack.Push(value);
            }

            void Two()
            {
                if (stack.TryPop(out int value) == false)
                    value = -1;

                sw.WriteLine(value);
            }

            void Three()
            {
                sw.WriteLine(stack.Count);
            }

            void Four()
            {
                var output = 0;
                if (stack.Count == 0)
                    output = 1;

                sw.WriteLine(output);
            }

            void Five()
            {
                if (stack.TryPeek(out int value) == false)
                    value = -1;

                sw.WriteLine(value);
            }
        }

        public static void Problem13909()
        {
            var n = int.Parse(Console.ReadLine());
            var result = 0;
            for (int i = 1; i * i <= n; i++)
            {
                result++;
            }

            Console.WriteLine(result);
        }
    }

    public class Day241126
    {
        public static void Problem17103()
        {
            var t = int.Parse(Console.ReadLine());
            var numbers = new bool[1000001];
            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == false)
                    continue;

                for (int num = i + i; num < numbers.Length; num += i)
                {
                    numbers[num] = true;
                }
            }

            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var count = 0;

                for (int j = 2; j <= n * 0.5f; j++)
                {
                    if (numbers[j] == false && numbers[n - j] == false)
                        count++;
                }

                Console.WriteLine(count);
            }
        }

        public static void Problem4948()
        {
            var numbers = new bool[123456 * 2 + 1];
            numbers[1] = true;

            for (int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] == true)
                    continue;

                var targetNumber = i;
                while (true)
                {
                    targetNumber += i;
                    if (targetNumber >= numbers.Length)
                        break;

                    numbers[targetNumber] = true;
                }
            }

            while (true)
            {
                var input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;
                var goal = input * 2;
                var answer = 0;

                for (int i = input + 1; i <= goal; i++)
                {
                    if (numbers[i] == false)
                        answer++;
                }

                Console.WriteLine(answer);
            }
        }
    }

    public class Day241125
    {
        public static void Problem1929()
        {
            var mn = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var numbers = new bool[mn[1] + 1];
            numbers[1] = true;

            for (int i = 2; i <= mn[1]; i++)
            {
                if (numbers[i] == true)
                    continue;

                var targetNumber = i;
                while (true)
                {
                    targetNumber += i;
                    if (targetNumber > mn[1])
                        break;

                    numbers[targetNumber] = true;
                }
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            for (int i = mn[0]; i <= mn[1]; i++)
            {
                if (numbers[i] == false)
                    sw.WriteLine(i);
            }
        }

        public static void Problem4134()
        {
            var c = int.Parse(Console.ReadLine());
            var input = new long[c];
            for (int i = 0; i < c; i++)
            {
                input[i] = long.Parse(Console.ReadLine());
            }

            for (int i = 0; i < c; i++)
            {
                if (input[i] < 2)
                    input[i] = 2;

                var targetNum = Math.Sqrt(input[i]);

                for (int j = 2; j <= targetNum; j++)
                {
                    if (input[i] % j == 0)
                    {
                        input[i]++;
                        targetNum = Math.Sqrt(input[i]);
                        j = 1;
                    }
                }
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var item in input)
            {
                sw.WriteLine(item);
            }
        }
    }

    public static class Day241031
    {
        public static void Problem15652()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sb = new StringBuilder();

            for (int i = 1; i <= arr[0]; i++)
            {
                asd(1, i, $"{i}");
            }
            Console.WriteLine(sb.ToString());

            void asd(int index, int last, string text)
            {
                if (index == arr[1])
                {
                    sb.AppendLine(text);
                    return;
                }

                for (int i = last; i <= arr[0]; i++)
                {
                    asd(index + 1, i, $"{text} {i}");
                }
            }
        }

        public static void Problem15651()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sb = new StringBuilder();

            for (int i = 1; i <= arr[0]; i++)
            {
                asd(1, $"{i}");
            }
            Console.WriteLine(sb.ToString());

            void asd(int index, string text)
            {
                if (index == arr[1])
                {
                    sb.AppendLine(text);
                    return;
                }

                for (int i = 1; i <= arr[0]; i++)
                {
                    asd(index + 1, $"{text} {i}");
                }
            }
        }

        public static void Problem15650()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var sb = new StringBuilder();

            for (int i = 1; i <= arr[0]; i++)
            {
                asd(1, i, $"{i}");
            }
            Console.WriteLine(sb.ToString());

            void asd(int index, int last, string text)
            {
                if (index == arr[1])
                {
                    sb.AppendLine(text);
                    return;
                }

                for (int i = last + 1; i <= arr[0]; i++)
                {
                    asd(index + 1, i, $"{text} {i}");
                }
            }
        }
    }

    public static class Day241030
    {
        public static void Problem2447()
        {
            var num = int.Parse(Console.ReadLine());

            var texts = new string[num];
            for (int i = 0; i < texts.Length; i++)
            {
                texts[i] = "*".PadRight(num, '*');
            }

            Remove(0, 0, num);

            void Remove(int minX, int minY, int range)
            {
                int removeAmount = range / 3;
                int removeX = minX + removeAmount;
                int removeY = minY + removeAmount;

                for (int i = 0; i < removeAmount; i++)
                {

                    texts[removeY + i] = texts[removeY + i].Remove(removeX, removeAmount);
                    texts[removeY + i] = texts[removeY + i].Insert(removeX, " ".PadRight(removeAmount));
                }

                if (removeAmount != 1)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            if (y == 1 && x == 1)
                                continue;

                            Remove(minX + removeAmount * x, minY + removeAmount * y, removeAmount);
                        }
                    }
                }
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var item in texts)
            {
                sw.WriteLine(item);
            }
        }

        public static void Problem20920()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var texts = new string[arr[0]];
            for (int i = 0; i < arr[0]; i++)
            {
                texts[i] = Console.ReadLine();
            }

            var dic = new Dictionary<string, int>();
            var list = new List<string>();
            for (int i = 0; i < arr[0]; i++)
            {
                if (texts[i].Length < arr[1])
                    continue;

                if (dic.TryAdd(texts[i], 1) == false)
                    dic[texts[i]]++;
                else
                    list.Add(texts[i]);
            }

            list.Sort((a, b) =>
            {
                var result = dic[b] - dic[a];
                if (result == 0)
                    result = b.Length - a.Length;
                if (result == 0)
                    result = a.CompareTo(b);

                return result;
            });


            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var item in list)
            {
                sw.WriteLine(item);
            }
        }
    }

    public static class Day241029
    {
        public static void Problem2108()
        {
            var count = int.Parse(Console.ReadLine());
            var arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);

            int sum = 0;
            var dic = new Dictionary<int, int>();
            var waiting = new int[] { int.MaxValue, int.MaxValue };
            var maxCount = 0;

            for (int i = 0; i < count; i++)
            {
                if (dic.ContainsKey(arr[i]) == false)
                    dic.Add(arr[i], 1);
                else
                    dic[arr[i]]++;

                if (maxCount == dic[arr[i]])
                {
                    var number = arr[i];
                    for (int j = 0; j < 2; j++)
                    {
                        if (waiting[j] > number)
                        {
                            var temp = waiting[j];
                            waiting[j] = number;
                            number = temp;
                        }
                    }
                }
                else if (maxCount < dic[arr[i]])
                {
                    maxCount = dic[arr[i]];
                    waiting[0] = arr[i];
                    waiting[1] = int.MaxValue;
                }

                sum += arr[i];
            }

            Console.WriteLine((int)(Math.Round((double)sum / count, MidpointRounding.AwayFromZero)));
            Console.WriteLine(arr[count / 2]);
            Console.WriteLine(waiting[1] == int.MaxValue ? waiting[0] : waiting[1]);
            Console.WriteLine(arr[count - 1] - arr[0]);
        }

        public static void Problem26069()
        {
            var count = int.Parse(Console.ReadLine());
            var hash = new HashSet<string>() { "ChongChong" };

            for (int i = 0; i < count; i++)
            {
                var log = Console.ReadLine().Split();

                for (int j = 0; j < 2; j++)
                {
                    if (hash.Contains(log[j]) == true)
                        hash.Add(log[1 - j]);
                }
            }

            Console.WriteLine(hash.Count);
        }
    }

    public static class Day241028
    {
        public static void Problem2485()
        {
            var count = int.Parse(Console.ReadLine());
            var trees = new int[count];
            for (int i = 0; i < count; i++)
            {
                trees[i] = int.Parse(Console.ReadLine());
            }

            var minDistance = trees[1] - trees[0];
            var distance = new int[count];

            for (int i = 1; i < count; i++)
            {
                var dis = trees[i] - trees[i - 1];
                distance[i] = dis;
                minDistance = LCD(minDistance, dis);
            }

            var result = 0;

            for (int i = 1; i < count; i++)
            {
                result += (distance[i] - minDistance) / minDistance;
            }

            Console.WriteLine(result);

            static int LCD(int max, int min)
            {
                while (max % min != 0)
                {
                    var temp = max;
                    max = min;
                    min = temp % min;
                }

                return min;
            }
        }

        public static void Problem1735()
        {
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var (n0, n1) = arr1[1] > arr2[1] ? (arr1[1], arr2[1]) : (arr1[1], arr2[1]);

            var parents = arr1[1] * arr2[1] / LCD(n0, n1);
            var child = arr1[0] * (parents / arr1[1]) + arr2[0] * (parents / arr2[1]);

            (n0, n1) = parents > child ? (parents, child) : (child, parents);

            var lcd = LCD(n0, n1);
            Console.WriteLine($"{child / lcd} {parents / lcd}");

            static int LCD(int max, int min)
            {
                while (max % min != 0)
                {
                    var temp = max;
                    max = min;
                    min = temp % min;
                }

                return min;
            }
        }

        public static void Problem25192()
        {
            var logs = int.Parse(Console.ReadLine());
            var greetingUser = new HashSet<string>();
            var answer = 0;

            for (int i = 0; i < logs; i++)
            {
                var log = Console.ReadLine();
                if (log == "ENTER")
                    greetingUser.Clear();
                else if (greetingUser.Add(log) == true)
                    answer++;
            }

            Console.WriteLine(answer);
        }

        public static void Porblem1037()
        {
            var count = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(arr);

            Console.WriteLine(arr[0] * arr[arr.Length - 1]);
        }
    }

    public static class Day241025
    {
        public static void Problem1026()
        {
            var asd = int.Parse(Console.ReadLine());
            var aArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var bArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(aArr);
            Array.Sort(bArr, (a, b) => { return b.CompareTo(a); });
            var sum = 0;
            for (int i = 0; i < asd; i++)
            {
                sum += aArr[i] * bArr[i];
            }

            Console.WriteLine(sum);
        }

        public static void Problem1541()
        {
            var arr = Console.ReadLine().Split('-');
            int sum = 0;
            var pluses = Array.ConvertAll(arr[0].Split('+'), int.Parse);

            for (int i = 0; i < pluses.Length; i++)
            {
                sum += pluses[i];
            }

            for (int i = 1; i < arr.Length; i++)
            {
                var nums = Array.ConvertAll(arr[i].Split('+'), int.Parse);

                for (int j = 0; j < nums.Length; j++)
                {
                    sum -= nums[j];
                }
            }

            Console.WriteLine(sum);

        }

        public static void Problem1931()
        {
            var asd = int.Parse(Console.ReadLine());
            var arr = new List<long[]>(asd);
            var result = 0;
            long time = 0;

            for (int i = 0; i < asd; i++)
            {
                arr.Add(Array.ConvertAll(Console.ReadLine().Split(), long.Parse));
            }
            arr.Sort((x, y) =>
            {
                var a = x[1].CompareTo(y[1]);
                if (a == 0)
                {
                    a = x[0].CompareTo(y[0]);
                }
                return a;
            });

            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i][0] >= time)
                {
                    time = arr[i][1];
                    result++;
                }
            }

            Console.WriteLine(result);

        }

        public static void Problem11047()
        {
            var inputs = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var values = new int[inputs[0]];
            var coin = 0;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = int.Parse(Console.ReadLine());
            }

            for (int i = values.Length - 1; i >= 0; i--)
            {
                if (values[i] > inputs[1])
                    continue;


                coin += inputs[1] / values[i];
                inputs[1] = inputs[1] % values[i];

                if (inputs[1] == 0)
                    break;
            }

            Console.WriteLine(coin);

        }

        public static void Problem11399()
        {
            var inputCase = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Array.Sort(arr);
            var sum = 0;
            var beforeTime = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += beforeTime + arr[i];
                beforeTime += arr[i];
            }
            Console.WriteLine(sum);
        }

        public static void Problem4673()
        {
            var numbers = new int[10001];

            for (int i = 1; i <= 10000; i++)
            {
                var count = i.ToString().Length;
                var sum = i;
                var number = i;
                for (int j = 0; j < count; j++)
                {
                    sum += number % 10;
                    number /= 10;
                }

                if (sum <= 10000)
                {
                    numbers[sum] = 1;
                }
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            for (int i = 1; i <= 10000; i++)
            {
                if (numbers[i] == 0)
                {
                    sw.WriteLine(i);
                }
            }
        }

        public static void Problem9012()
        {
            var inputCase = int.Parse(Console.ReadLine());
            var stack = new Queue<int>();
            var sb = new StringBuilder();

            for (int i = 0; i < inputCase; i++)
            {
                var text = Console.ReadLine();
                var isResult = "YES";
                stack.Clear();
                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] == '(')
                    {
                        stack.Enqueue(j);
                    }
                    else
                    {
                        if (stack.TryDequeue(out var a) == false)
                        {
                            isResult = "NO";
                            break;
                        }
                    }
                }

                sb.AppendLine(stack.Count == 0 ? isResult : "NO");
            }
            Console.WriteLine(sb);
        }

        public static void Problem2156()
        {
            var count = int.Parse(Console.ReadLine());
            var scores = new int[count + 3];
            for (int i = 1; i <= count; i++)
            {
                scores[i] = int.Parse(Console.ReadLine());
            }

            var dp = new int[count + 3];
            dp[1] = scores[1];
            dp[2] = scores[2] + dp[1];
            dp[3] = Math.Max(scores[3] + dp[1], dp[2]);
            dp[3] = Math.Max(dp[3], scores[2] + scores[3]);
            var result = int.MinValue;

            for (int i = 0; i < 4; i++)
            {
                result = Math.Max(result, dp[i]);
            }

            for (int i = 4; i <= count; i++)
            {
                dp[i] = Math.Max(dp[i - 3] + scores[i - 1] + scores[i], dp[i - 2] + scores[i]);
                dp[i] = Math.Max(dp[i], dp[i - 1]);
                result = Math.Max(result, dp[i]);
            }

            Console.WriteLine(result);

        }

        public static void Problem2748()
        {
            var count = int.Parse(Console.ReadLine());
            var dp1 = new long[count + 3];
            dp1[1] = 1;
            dp1[2] = 1;

            for (int i = 3; i <= count; i++)
            {
                dp1[i] = dp1[i - 1] + dp1[i - 2];
            }

            Console.WriteLine(dp1[count]);
        }

        public static void Problem11727()
        {
            var count = int.Parse(Console.ReadLine());
            var dp1 = new int[count + 3];
            dp1[1] = 1;
            dp1[2] = 3;
            for (int i = 3; i <= count; i++)
            {
                dp1[i] = (dp1[i - 1] + dp1[i - 2] * 2) % 10007;
            }
            Console.WriteLine(dp1[count]);
        }

        public static void Problem9461()
        {
            var count = int.Parse(Console.ReadLine());
            var dp = new List<long>() { 1, 1, 1, 2, 2, 3, 4, 5, 7, 9 };
            var sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                var number = int.Parse(Console.ReadLine());

                var index = dp.Count - 1;
                while (number > dp.Count)
                {
                    dp.Add(dp[index] + dp[index - 4]);
                    index++;
                }

                sb.AppendLine(dp[number - 1].ToString());
            }

            Console.WriteLine(sb);
        }

        public static void Problem1912()
        {
            var count = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var dp = new int[count];
            var result = arr[0];
            dp[0] = arr[0];

            for (int i = 1; i < count; i++)
            {
                dp[i] = arr[i] + dp[i - 1];
                if (dp[i] < arr[i])
                {
                    dp[i] = arr[i];
                }

                result = Math.Max(dp[i], result);
            }

            Console.WriteLine(result);

        }
    }

    public static class Day241024
    {
        public static void Problem1932()
        {
            var count = int.Parse(Console.ReadLine()) - 1;
            var values = new List<int[]>(); //  y x
            var dp = new int[count + 1, count + 1]; // y x

            for (int i = 0; i <= count; i++)
            {
                values.Add(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));
            }

            dp[0, 0] = values[0][0];

            for (int y = 1; y <= count; y++)
            {
                for (int x = 0; x <= y; x++)
                {
                    if (x == 0)
                        dp[y, x] = dp[y - 1, x] + values[y][x];
                    else if (x == y)
                        dp[y, x] = dp[y - 1, x - 1] + values[y][x];
                    else
                        dp[y, x] = Math.Max(dp[y - 1, x - 1], dp[y - 1, x]) + values[y][x];
                }
            }
            var result = int.MinValue;
            for (int i = 0; i < count; i++)
            {
                result = Math.Max(result, dp[count, i]);
            }

            Console.WriteLine(result);



            void asd(int y, int x, int sum)
            {
                if (y == count)
                {
                    result = Math.Max(sum, result);
                    return;
                }

                var nextY = y + 1;
                var rightX = x + 1;
                if (x < count && dp[nextY, rightX] < sum + values[nextY][rightX])
                {
                    dp[nextY, rightX] = sum + values[nextY][rightX];
                    asd(nextY, rightX, dp[nextY, rightX]);
                }

                if (dp[nextY, x] < sum + values[nextY][x])
                {
                    dp[nextY, x] = sum + values[nextY][x];
                    asd(nextY, x, dp[nextY, x]);
                }
            }
        }

        public static void Problem1149()
        {
            var count = int.Parse(Console.ReadLine());
            var values = new List<int[]>();
            var dp = new int[count, 3];

            for (int i = 0; i < count; i++)
            {
                values.Add(Array.ConvertAll(Console.ReadLine().Split(), int.Parse));
            }
            dp[0, 0] = values[0][0];
            dp[0, 1] = values[0][1];
            dp[0, 2] = values[0][2];


            for (int i = 1; i < count; i++)
            {
                dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + values[i][0];
                dp[i, 1] = Math.Min(dp[i - 1, 2], dp[i - 1, 0]) + values[i][1];
                dp[i, 2] = Math.Min(dp[i - 1, 1], dp[i - 1, 0]) + values[i][2];
            }

            var best = int.MaxValue;
            for (int i = 0; i < 3; i++)
            {
                best = Math.Min(dp[count - 1, i], best);
            }

            Console.WriteLine(best);

        }

        public static void Problem2579()
        {
            var floor = int.Parse(Console.ReadLine());
            var scores = new int[floor + 1];
            var maxScore = 0;
            var dic = new Dictionary<int, int[]>();
            for (int i = 1; i <= floor; i++)
            {
                scores[i] = int.Parse(Console.ReadLine());
            }

            asd(0, 0, -1);
            Console.WriteLine(maxScore);

            void asd(int sum, int index, int combo)
            {
                if (floor < index)
                    return;

                sum += scores[index];

                if (floor == index)
                {
                    maxScore = Math.Max(maxScore, sum);
                    return;
                }

                if (dic.ContainsKey(index) == false)
                {
                    dic.Add(index, [combo, sum]);
                }
                else
                {
                    if (dic[index][combo] >= sum)
                        return;
                    else
                    {
                        dic[index][combo] = sum;
                    }
                }


                if (combo < 1)
                {
                    asd(sum, index + 1, combo + 1);
                }

                asd(sum, index + 2, 0);
            }
        }
    }

    public static class Day241023
    {
        public static void Problem15649()
        {
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var hashset = new HashSet<int>();
            var sb = new StringBuilder();

            for (int i = 1; i <= arr[0]; i++)
            {
                hashset.Add(i);
                asd(i.ToString(), 1);
                hashset.Remove(i);
            }

            void asd(string text, int count)
            {
                if (count == arr[1])
                {
                    sb.AppendLine(text);
                    return;
                }

                for (int i = 1; i <= arr[0]; i++)
                {
                    if (hashset.Contains(i) == true)
                        continue;

                    hashset.Add(i);
                    asd($"{text} {i}", count + 1);
                    hashset.Remove(i);
                }
            }

            Console.WriteLine(sb);
        }

        public static void Problem1927()
        {
            var count = int.Parse(Console.ReadLine());
            var heap = new int[count + 1];
            var size = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                var input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    sb.AppendLine(size == 0 ? 0.ToString() : Dequeue().ToString());
                }
                else
                {
                    Enqueue(input);
                }
            }

            Console.WriteLine(sb);

            void Enqueue(int number)
            {
                size++;
                var i = size;
                while (i > 1 && number < heap[i >> 1])
                {
                    heap[i] = heap[i >> 1];
                    i >>= 1;
                }

                heap[i] = number;
            }

            int Dequeue()
            {
                var output = heap[1];
                heap[1] = heap[size];
                heap[size] = 0;
                var startIndex = 1;
                var leftIndex = 2;
                int child;
                size--;

                while (leftIndex <= size)
                {
                    if (leftIndex == size)
                    {
                        child = leftIndex;
                    }
                    else
                    {
                        int rightIndex = leftIndex + 1;
                        child = heap[leftIndex] < heap[rightIndex] ? leftIndex : rightIndex;
                    }

                    if (heap[startIndex] > heap[child])
                    {
                        var value = heap[startIndex];
                        heap[startIndex] = heap[child];
                        heap[child] = value;
                        startIndex = child;
                        leftIndex = child << 1;
                    }
                    else
                    {
                        break;
                    }
                }

                return output;
            }
        }

        public static void Problem2775()
        {
            var count = int.Parse(Console.ReadLine());
            var asd = new int[16, 15];
            for (int y = 0; y < 15; y++)
            {
                asd[1, y] = 1;
            }
            for (int x = 1; x < 16; x++)
            {
                asd[x, 0] = x;
            }

            for (int x = 2; x < 16; x++)
            {
                for (int y = 1; y < 15; y++)
                {
                    asd[x, y] = asd[x - 1, y] + asd[x, y - 1];
                }
            }

            for (int j = 0; j < count; j++)
            {
                int k = int.Parse(Console.ReadLine()); // 층
                int n = int.Parse(Console.ReadLine()); // 호
                Console.WriteLine(asd[n, k]);
            }
        }

        public static void Problem11726()
        {
            var n = int.Parse(Console.ReadLine());
            var asded = new int[n + 2];

            asded[1] = 1;
            asded[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                asded[i] = (asded[i - 1] + asded[i - 2]) % 10007;
            }

            Console.WriteLine(asded[n]);
        }

        public static void Problem9095()
        {
            var n = int.Parse(Console.ReadLine());
            var count = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                count = 0;
                var number = int.Parse(Console.ReadLine());
                asd(0, number);
                sb.AppendLine(count.ToString());
            }

            Console.WriteLine(sb);

            void asd(int sum, int target)
            {
                if (sum > target)
                    return;
                if (sum == target)
                {
                    count++;
                    return;
                }

                asd(sum + 1, target);
                asd(sum + 2, target);
                asd(sum + 3, target);
            }
        }

        public static void Problem1463()
        {
            var n = int.Parse(Console.ReadLine());
            var minValue = int.MaxValue;
            var memo = new int[n + 1];
            for (int i = 0; i <= n; i++)
            {
                memo[i] = -1;
            }

            numbe(n, 0);
            Console.WriteLine(minValue);

            void numbe(int n, int count)
            {
                if (minValue < count)
                    return;
                if (memo[n] < count && memo[n] != -1)
                    return;

                if (n == 1)
                {
                    minValue = Math.Min(minValue, count);
                    return;
                }

                memo[n] = count;
                if (n % 3 == 0)
                    numbe(n / 3, count + 1);
                if (n % 2 == 0)
                    numbe(n / 2, count + 1);

                numbe(n - 1, count + 1);
            }
        }

        public static void Problem11053()
        {
            var index = int.Parse(Console.ReadLine());
            var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var dp = new int[index];
            var best = int.MinValue;

            for (int i = 0; i < index; i++)
            {
                dp[i] = 1;

                for (int j = 0; j < i; j++)
                {
                    if (arr[j] < arr[i])
                    {
                        dp[i] = dp[j] + 1;
                    }
                }

                best = Math.Max(best, dp[i]);
            }

            Console.WriteLine(best);
        }

        public static void Problem24416()
        {
            var number = int.Parse(Console.ReadLine());

            var c1 = 0;
            var c2 = 0;
            fib(number);
            fib2(number);

            Console.WriteLine(c1 + " " + c2);

            int fib(int n)
            {
                if (n == 1 || n == 2)
                {
                    c1++;
                    return 1;
                }

                return (fib(n - 1) + fib(n - 2));
            }

            int fib2(int n)
            {
                for (int i = 3; i <= n; i++)
                {
                    c2++;
                }
                return 1;
            }
        }

    }


    public static class Day241022
    {
        public static void Problem24060()
        {
            var terms = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var nums = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var temp = new int[nums.Length];
            var count = 0;
            var result = -1;
            S(nums, temp, 0, nums.Length - 1);
            Console.WriteLine(result);

            void S(int[] ints, int[] temp, int left, int right)
            {
                if (left < right && result == -1)
                {
                    var mid = (left + right) / 2;
                    S(ints, temp, left, mid);
                    S(ints, temp, mid + 1, right);
                    SS(ints, temp, left, mid + 1, right);
                }
            }

            void SS(int[] ints, int[] temp, int left, int mid, int right)
            {
                var l = left;
                var m = mid;
                var r = right;
                var index = l;

                while (index <= r)
                {
                    count++;
                    if (m > right || l < mid && ints[l] <= ints[m])
                        temp[index++] = ints[l++];
                    else
                        temp[index++] = ints[m++];

                    if (count == terms[1])
                        result = temp[index - 1];
                }

                for (int i = left; i <= right; i++)
                    ints[i] = temp[i];
            }
        }
    }

    public static class Day241021
    {
        public static void Problem25501()
        {
            var number = int.Parse(Console.ReadLine());
            var results = new string[number];
            var count = 0;

            for (int i = 0; i < number; i++)
            {
                count = 0;
                var text = Console.ReadLine();
                results[i] = $"{c(text, 0, text.Length - 1)} {count}";
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var a in results)
            {
                sw.WriteLine(a);
            }

            int c(string text, int a, int b)
            {
                count++;
                if (a >= b)
                    return 1;
                else if (text[a] != text[b])
                    return 0;

                return c(text, a + 1, b - 1);
            }
        }

        public static void Problem10870()
        {
            var number = int.Parse(Console.ReadLine());

            if (number == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(zz(0, 1, number, 1));

            int zz(int num1, int num2, int index, int i)
            {
                if (index == i)
                {
                    return num2;
                }
                else
                {
                    return zz(num2, num1 + num2, index, i + 1);
                }

            }
        }

        public static void Problem27433()
        {
            var number = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(1, number));

            long Factorial(long amount, long index)
            {
                if (index == 0)
                    return amount;
                else
                    return Factorial(amount * index, index - 1);
            }
        }

        public static void Problem1010()
        {
            var count = int.Parse(Console.ReadLine());
            var results = new long[count];

            for (int i = 0; i < count; i++)
            {
                var s = Console.ReadLine().Split();
                int n = int.Parse(s[0]);
                int m = int.Parse(s[1]);

                int a = 1;
                int b = 1;

                for (int j = 0; j < m - n; j++)
                {
                    a *= m - j;
                    b *= 1 + j;

                    var num = GCDWithEuclidean(a, b);
                    if (num != 1)
                    {
                        a /= num;
                        b /= num;
                    }
                }

                results[i] = a / b;
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var a in results)
            {
                sw.WriteLine(a);
            }

            int GCDWithEuclidean(int n0, int n1)
            {
                while (n0 % n1 != 0)
                {
                    var temp = n0;
                    n0 = n1;
                    n1 = temp % n1;
                }

                return n1;
            }
        }

        public static void Problem11050()
        {
            string[] s = Console.ReadLine().Split();
            int n = int.Parse(s[0]);
            int k = int.Parse(s[1]);

            long a = 1;
            long b = 1;

            for (int i = 0; i < k; i++)
            {
                a *= n - i;
                b *= k - i;
            }

            Console.WriteLine(a / b);
        }
    }

    public static class Day241019
    {

        public static void Problem10872()
        {
            var num = int.Parse(Console.ReadLine());
            long result = 1;
            for (int i = 1; i <= num; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);
        }

        public static void Problem24723()
        {
            var num = int.Parse(Console.ReadLine());
            var result = 1;
            for (int i = 0; i < num; i++)
            {
                result *= 2;
            }

            Console.WriteLine(result);
        }

        public static void Problem15439()
        {
            var nums = int.Parse(Console.ReadLine());
            Console.WriteLine(nums * (nums - 1));
        }
    }


    public static class Day241010
    {
        public static void Problem13241()
        {
            var nums = Array.ConvertAll(Console.ReadLine().Split(), long.Parse);
            var (n0, n1) = nums[0] > nums[1] ? (nums[0], nums[1]) : (nums[1], nums[0]);

            while (n0 % n1 != 0)
            {
                var temp = n0;
                n0 = n1;
                n1 = temp % n1;
            }

            Console.WriteLine(nums[0] * nums[1] / n1);
        }
    }

    public static class Day241009
    {
        public static void Problem1934()
        {
            var inputCount = int.Parse(Console.ReadLine());
            var results = new int[inputCount];
            for (int i = 0; i < inputCount; i++)
            {
                var arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
                var count = 1;
                var result = 1;

                while (count < arr[0])
                {
                    count++;
                    if (arr[0] % count == 0 && arr[1] % count == 0)
                    {
                        arr[0] /= count;
                        arr[1] /= count;

                        result *= count;
                        count = 1;
                    }
                }

                results[i] = result * arr[0] * arr[1];
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var a in results)
            {
                sw.WriteLine(a);
            }
        }
    }

    public static class Day241008
    {
        public static void Problem1769()
        {
            Console.ReadLine();
            var arr1 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToHashSet();
            var arr2 = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToHashSet();
            var count = arr1.Count + arr2.Count;
            foreach (var item in arr1)
            {
                if (arr2.Contains(item) == true)
                {
                    count -= 2;
                }
            }

            Console.WriteLine(count);
        }

        public static void Problem11478()
        {
            var text = Console.ReadLine();
            var arr = new HashSet<string>();
            for (int i = 1; i <= text.Length; i++)
            {
                for (int j = 0; j <= text.Length - i; j++)
                {
                    arr.Add(text.Substring(j, i));
                }
            }

            Console.WriteLine(arr.Count);
        }
    }

    public static class Day241007
    {
        public static void Problem1764()
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var hashSet = new HashSet<string>();
            var arr = new List<string>();
            for (int i = 0; i < nm[0]; i++)
            {
                hashSet.Add(Console.ReadLine());
            }

            for (int i = 0; i < nm[1]; i++)
            {
                var name = Console.ReadLine();
                if (hashSet.Contains(name) == true)
                    arr.Add(name);
            }
            arr.Sort();

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            sw.WriteLine(arr.Count);
            foreach (var a in arr)
            {
                sw.WriteLine(a);
            }
        }

        public static void Problem10816()
        {
            Console.ReadLine();
            var nArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.ReadLine();
            var mArr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            var dic = new Dictionary<int, int>();
            for (int i = 0; i < nArr.Length; i++)
            {
                if (dic.TryAdd(nArr[i], 1) == false)
                    dic[nArr[i]]++;
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var a in mArr)
            {
                dic.TryGetValue(a, out var value);
                sw.Write($"{value} ");
            }
        }
    }

    public static class Day241006
    {
        public static void Problem1620()
        {
            var nm = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var col = new Dictionary<string, int>();
            var arr = new string[nm[0] + 1];
            for (int i = 0; i < nm[0]; i++)
            {
                var name = Console.ReadLine();
                var num = i + 1;
                col.Add(name, num);
                arr[num] = name;
            }

            var results = new string[nm[1]];
            for (int i = 0; i < nm[1]; i++)
            {
                var text = Console.ReadLine();
                if (int.TryParse(text, out var result) == true)
                    results[i] = arr[result];
                else
                    results[i] = (col[text].ToString());
            }

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var a in results)
            {
                sw.WriteLine(a);
            }
        }
    }

    public static class Day241005
    {
        public static void Problem7785()
        {
            var n = int.Parse(Console.ReadLine());
            var check = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                var contains = check.Contains(data[0]);
                if (data[1] == "enter" && contains == false)
                    check.Add(data[0]);
                else if (contains == true)
                    check.Remove(data[0]);
            }

            var arr = check.ToArray();
            Array.Sort(arr);

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sw.WriteLine(arr[i]);
            }
        }

        public static void Problem14425()
        {
            var counts = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            var s = new HashSet<string>();

            for (int i = 0; i < counts[0]; i++)
            {
                s.Add(Console.ReadLine());
            }

            var result = 0;
            for (int i = 0; i < counts[1]; i++)
            {
                if (s.Contains(Console.ReadLine()) == true)
                    result++;
            }
            Console.WriteLine(result);
        }

        public static void Problem10815()
        {
            var count = int.Parse(Console.ReadLine());
            var n = Array.ConvertAll(Console.ReadLine().Split(), int.Parse).ToHashSet();
            count = int.Parse(Console.ReadLine());
            var m = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            using var sw = new System.IO.StreamWriter(Console.OpenStandardOutput());
            foreach (var i in m)
            {
                sw.Write(n.Contains(i) == true ? "1 " : "0 ");
            }
        }
    }

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
