namespace ChampagneSupernova.Library.Algorithm.Astar
{
    public struct AstarData<T>
    {
        public T BeforeNode;
        public int QueueIndex;

        public int G;
        public int H;
        public int F;

        public AstarData(int g, int h, int f)
        {
            BeforeNode = default;
            QueueIndex = 0;
            G = g;
            H = h;
            F = f;
        }

        public AstarData(T beforeNode, int queueIndex, int g, int h, int f)
        {
            BeforeNode = beforeNode;
            QueueIndex = queueIndex;
            G = g;
            H = h;
            F = f;
        }

        public void ResetPriorityData()
        {
            BeforeNode = default;
            QueueIndex = 0;
            G = 0;
            H = 0;
            F = 0;
        }
    }
}
