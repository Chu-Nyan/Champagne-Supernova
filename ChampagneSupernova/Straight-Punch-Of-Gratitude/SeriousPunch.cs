using System.Collections.Generic;

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
