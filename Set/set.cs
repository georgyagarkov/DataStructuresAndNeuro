namespace Set
{
    public class Set<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            _items.Add(item);
        }
        // continue soon
    }
}