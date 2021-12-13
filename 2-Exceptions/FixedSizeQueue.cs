namespace Exceptions
{
    // TODO understand the functioning of this class
    public class FixedSizeQueue : IFixedSizeQueue
    {
        private object[] _items;
        private int _firstIndex = 0;
        private int _lastIndex = 0;

        public FixedSizeQueue(uint capacity)
        {
            Capacity = capacity;
            _items = new object[capacity];
        }

        public uint Capacity { get; }

        public uint Count => (uint) (_lastIndex - _firstIndex);

        public object GetFirst()
        {
            if (this.Count == 0) throw  new EmptyQueueException();
            else
            {
                var first = _items[_firstIndex % Capacity];
                _firstIndex++;
                return first;
            }

        }

        public void AddLast(object item)
        {
            if (this.Count == this.Capacity) throw  new FullQueueException();
            else
            {
                _items[_lastIndex % Capacity] = item;
                _lastIndex++;
            }


        }
    }
}
