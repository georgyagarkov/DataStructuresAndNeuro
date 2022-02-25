using System.Collections.Generic;

namespace Queue
{
    public class Queue<T>
    {
        private List<T> _items = new List<T>();
        public int Count { get { return _items.Count; } }

        public void Enqueue(T data)
        {
            if(data == null)throw new ArgumentNullException(nameof(data));
            _items.Add(data);
        }

        public T Dequeue()
        {
            var item = GetItem();
            _items.Remove(item);
            return item;
        }

        private T GetItem()
        {
            var item = _items.FirstOrDefault();
            if(item == null)throw new NullReferenceException(nameof(item));
            return item;
        }
        public T peek()
        {
            return GetItem();
        }
    }
}