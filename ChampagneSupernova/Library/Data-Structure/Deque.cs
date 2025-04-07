namespace ChampagneSupernova.Library.Data_Structure
{
    public class Deque<T>
    {
        private T[] _arr;
        private int _count;
        private int _capacity;
        private int _lastPoint;
        private int _firstPoint;

        public int Count
        {
            get => _count;
        }

        public Deque(int count = 4)
        {
            if (count < 4)
                count = 4;

            _arr = new T[count];
            _capacity = count;
            _lastPoint = 0;
            _firstPoint = count - 1;
            _count = 0;
        }

        public void EnqueueLast(T item)
        {
            if (_count == _capacity)
                ResizeArray();

            _count++;
            _arr[_lastPoint] = item;
            _lastPoint = NextIndex(_capacity, _lastPoint, 1);
        }

        public void EnqueueFirst(T item)
        {
            if (_count == _capacity)
                ResizeArray();

            _count++;
            _arr[_firstPoint] = item;
            _firstPoint = NextIndex(_capacity, _firstPoint, -1);
        }

        public T DequeueLast()
        {
            _lastPoint = NextIndex(_capacity, _lastPoint, -1);
            var item = _arr[_lastPoint];
            _arr[_lastPoint] = default;
            _count--;
            return item;
        }

        public T DequeueFirst()
        {
            _firstPoint = NextIndex(_capacity, _firstPoint, +1);
            var item = _arr[_firstPoint];
            _arr[_firstPoint] = default;
            _count--;
            return item;
        }

        public T PeekLast()
        {
            return _arr[_lastPoint];
        }

        public T PeekFirst()
        {
            return _arr[_firstPoint];
        }

        public void Rotate(int dic)
        {
            if (_count <= 1 || dic == 0)
                return;

            dic %= _count;

            if (dic > 0)
            {
                for (int i = 0; i < dic; i++)
                {
                    var item = DequeueLast();
                    EnqueueFirst(item);
                }
            }
            else if (dic < 0)
            {
                for (int i = 0; i < -dic; i++)
                {
                    var item = DequeueFirst();
                    EnqueueLast(item);
                }
            }
        }

        private void ResizeArray()
        {
            var newCapacity = _capacity * 2;
            var newItem = new T[newCapacity];
            for (int i = 0; i < _count; i++)
            {
                var index = NextIndex(_capacity, _firstPoint, i + 1);
                newItem[i] = _arr[index];
            }

            _arr = newItem;
            _capacity = newCapacity;
            _firstPoint = _capacity - 1;
            _lastPoint = _count;
        }

        private static int NextIndex(int capacity, int index, int dir)
        {
            var next = (index + dir) % capacity;
            if (next < 0)
                next += capacity;
            return next;
        }
    }
}
