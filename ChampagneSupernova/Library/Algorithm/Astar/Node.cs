using Library.DataStructure;

namespace ChampagneSupernova.Library.Algorithm.Astar
{
    public class Node : IPrioritizable
    {
        // TODO : 우선 순위 큐 데이터 분리

        public AstarData<Node> AstarData;
        public Vector2 Position;

        private bool _isBlocked;
        private int _index;
        private int _priority;

        public bool IsBlocked
        {
            get => _isBlocked;
            set => _isBlocked = value;
        }

        public int QueueIndex
        {
            get => _index;
            set => _index = value;
        }

        public int Priority
        {
            get => _priority;
            set => _priority = value;
        }

        public void ResetPriorityData()
        {
            AstarData.ResetPriorityData();
        }
    }
}
