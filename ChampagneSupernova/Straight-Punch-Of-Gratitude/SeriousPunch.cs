using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Programmers
{
    public class Day241024
    {
        public static int solution42587(int[] priorities, int location)
        {
            var aa = priorities.ToArray();
            Array.Sort(aa, (a, b) => { return b.CompareTo(a); });
            var queue = new Queue<int>();
            var order = new Queue<int>();
            var index = -1;
            for (int i = 0; i < priorities.Length; i++)
            {
                if (priorities[i] == aa[0] && index == -1)
                {
                    index = i - 1;
                }
                queue.Enqueue(priorities[i]);
                order.Enqueue(i);
            }

            for (int i = 0; i < index; i++)
            {
                queue.Enqueue(queue.Dequeue());
                order.Enqueue(order.Dequeue());
            }

            var best = 0;
            var result = 0;
            while (true)
            {
                var item = queue.Dequeue();

                if (item == aa[best])
                {
                    best++;
                    result++;
                    var i = order.Dequeue();

                    if (location == i)
                    {
                        Console.WriteLine(result);
                        return result;
                    }
                }
                else
                {
                    queue.Enqueue(item);
                    order.Enqueue(order.Dequeue());
                }
            }
        }

        public static bool solution12909(string s)
        {
            var stack = new Queue<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Enqueue(s[i]);
                }
                else
                {
                    if (stack.TryDequeue(out var z) == false)
                    {
                        return false;
                    }

                }
            }

            return stack.Count == 0;
        }

        public static int[] solution42586(int[] progresses, int[] speeds)
        {
            var queue = new Queue<int>();
            var answer = new List<int>();
            for (int i = 0; i < progresses.Length; i++)
            {
                queue.Enqueue((int)Math.Ceiling((100 - progresses[i]) / (double)speeds[i]));
            }

            while (queue.Count > 0)
            {
                var day = queue.Dequeue();
                var count = 1;
                while (queue.Count > 0)
                {
                    if (queue.Peek() <= day)
                    {
                        queue.Dequeue();
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }

                answer.Add(count);
            }

            return answer.ToArray();
        }

        public static int solution42747(int[] citations)
        {
            var h = int.MaxValue;
            var index = 0;
            Array.Sort(citations, (x, y) =>
            {
                return y.CompareTo(x);
            });

            for (int i = 0; i < citations.Length; i++)
            {
                if (i >= citations[i])
                {
                    break;
                }
                else
                {
                    index++;
                }
            }

            return index;
        }

        public static string solution42746(int[] numbers)
        {
            Array.Sort(numbers, (x, y) =>
            {
                return -$"{x}{y}".CompareTo($"{y}{x}");
            });

            var sb = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
            {
                sb.Append(numbers[i]);
            }

            return sb[0] == '0' ? "0" : sb.ToString();
        }
    }


    class Result
    {

        public class Solution
        {
            public string solution(string number, int k)
            {
                var sb = new StringBuilder(number);
                var index9 = 0;
                while (k > 0)
                {
                    for (int i = index9; i < sb.Length; i++)
                    {
                        if (i == sb.Length - 1)
                        {
                            sb = sb.Remove(i, 1);
                        }
                        else if (sb[i] == '9')
                        {
                            index9 = i;
                            continue;
                        }
                        else if (sb[i] < sb[i + 1])
                        {
                            sb = sb.Remove(i, 1);
                            break;
                        }
                    }

                    k--;
                }

                return sb.ToString();
            }
        }
    }

    public class SeriousPunch241021
    {
        public int solution(int n, int[,] computers)
        {
            int answer = 0;
            var hash = new HashSet<int>();
            for (int i = 0; i < n; i++)
            {
                if (hash.Contains(i) == false) // << 백트래킹
                {
                    answer++;
                    a(i, n, hash, computers);
                }
            }

            return answer;
        }

        void a(int index, int amount, HashSet<int> set, int[,] computers)
        {
            for (int i = 0; i < amount; i++)
            {
                if (computers[index, i] == 0 || index == i) // << 백트래킹
                    continue;

                if (set.Contains(i) == false)
                {
                    set.Add(i);
                    a(i, amount, set, computers);
                    set.Add(i);
                }
            }
        }
    }
}