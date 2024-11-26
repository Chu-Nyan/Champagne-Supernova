namespace Library
{
    public static class NotMath
    {
        public static int GCDWithEuclidean(int n0, int n1)
        {
            while (n0 % n1 != 0)
            {
                var temp = n0;
                n0 = n1;
                n1 = temp % n1;
            }

            return n1;
        }

        public static int LCM(int n0, int n1)
        {
            return n0 * n1 / GCDWithEuclidean(n0, n1);
        }

        public static bool[] GetPrimeNumber()
        {
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

            return numbers;
        }
    }
}
