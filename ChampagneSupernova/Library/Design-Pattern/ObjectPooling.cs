using System;
using System.Collections.Generic;

namespace Library.DesignPattern
{
    public class ObjectPooling<T> where T : class, IPoolable
    {
        private readonly Queue<T> _queue;
        private readonly Func<T> _onNewGenerated;

        public ObjectPooling(Func<T> generate)
        {
            _queue = new Queue<T>();
            _onNewGenerated = generate;
        }

        public T GetNew()
        {
            if (_queue.TryDequeue(out var item) == false)
                item = _onNewGenerated();
            else
                item.Init();

            return item;
        }
    }

    public interface IPoolable 
    {
        public void Init();
    }
}
