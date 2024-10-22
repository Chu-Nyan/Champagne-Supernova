using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace asd
{
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
