using System;
using System.Diagnostics;

namespace Library.DesignPattern
{
    public class Builder : Singleton<Builder>
    {
        private readonly ObjectPooling<Stopwatch> _pooling;
        private Stopwatch _new;

        private event Action<Stopwatch> Generated;
        private event Action<Stopwatch> Destroyed;

        public Builder()
        {
            Func<Stopwatch> generate = () => { return new(); };
            Action<Stopwatch> reset = (item) => { item.Reset(); };
            _pooling = new(generate, reset);
        }

        public void Ready()
        {
            _new = _pooling.Dequeue();
        }

        public Builder SetName(string name)
        {
            return this;
        }

        public Stopwatch Generate()
        {
            Generated?.Invoke(_new);
            return _new;
        }

        public void Clean(Stopwatch human)
        {
            Destroyed?.Invoke(human);
        }
    }
}
