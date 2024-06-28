using System;
using System.IO;
using System.Reflection;

namespace ChampagneSupernova
{
    public static class PerformanceTester
    {
        private const string LogName = "PerformanceLog";
        private const int DefaultLoop = 10000;
        private const int AvgLoop = 1000;

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

            string log = $"{method.GetMethodInfo().Name} | Count : {loop} | Avg : {avgMs}ms";
            SaveLog(method.GetMethodInfo().Name, log);
            Console.WriteLine(log);
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

        private static void SaveLog(string name, string text)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fileName = $"{LogName}.txt";
            string filePath = Path.Combine(currentDirectory, fileName);
            StreamWriter sw = new StreamWriter(filePath, true, System.Text.Encoding.UTF8);
            sw.WriteLine(name);
            sw.WriteLine(text);
            sw.WriteLine();
            sw.Close();
        }
    }
}
