using System;

namespace ChampagneSupernova
{
    public static class PerformanceTester
    {
        private const int DefaultLoop = 10000;
        private const int AvgLoop = 100;

        public static void Start(Action method, int loop = DefaultLoop)
        {
            // TO DO : 절사 평균 값도 추가할 것

            long allTick = 0;
            for (int i = 0; i < AvgLoop; i++)
            {
                long loopTick = Test(method, loop);
                allTick += loopTick;
            }
            TimeSpan span = new(allTick / AvgLoop);
            long avgMs = span.Microseconds;

            Console.WriteLine($"Count : {loop} | Avg : {avgMs}ms");
        }

        private static long Test(Action method, int loop)
        {
            long startTick = DateTime.UtcNow.Ticks;
            for (int i = 0; i < loop; i++)
            {
                method.Invoke();
            }
            long endTick = DateTime.UtcNow.Ticks;

            return endTick - startTick;
        }
    }
}
