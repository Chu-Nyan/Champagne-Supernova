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
    }
}
