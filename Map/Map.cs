namespace Map
{
    public class Map<TKey,TValue>
    {
        private List<Item<TKey, TValue>> _items = new List<Item<TKey,TValue>>();
        public int Count => _items.Count;
        public IReadOnlyList<TKey> Keys => (IReadOnlyList<TKey>)(_items.Select(i => i.Key).ToList());
        public void Add(Item<TKey,TValue> item)
        {
            if(item == null)throw new ArgumentNullException("item");

            if (_items.Any(i => i.Key.Equals(item.Key)))
            {
                throw new ArgumentException($"Словарь уже содержит значение с ключом {item.Key}.", nameof(item));
            }
            _items.Add(item);
        }
        public void Update(TKey key, TValue newValue)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (newValue == null)
            {
                throw new ArgumentNullException(nameof(newValue));
            }
            if (!_items.Any(i => i.Key.Equals(key)))
            {
                throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));
            }
            var item = _items.SingleOrDefault(i => i.Key.Equals(key));
            if (item != null)
            {
                item.Value = newValue;
            }
        }
        public void Remove(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var item = _items.SingleOrDefault(i => i.Key.Equals(key));
            if (item != null)
            {
                _items.Remove(item);
            }
        }
        public void Add(TKey key, TValue value)
        {
            if(key == null)throw new ArgumentNullException("key");
            if(value == null)throw new ArgumentNullException("value");
            if(_items.Any(i=>i.Key.Equals(key))) throw new ArgumentException($"Словарь уже содержит значение с ключом {key}.", nameof(key));
            var item = new Item<TKey, TValue>(key,value);
            _items.Add(item);
        }
        public TValue Get(TKey key)
        {
            if (key == null)throw new ArgumentNullException(nameof(key));
            var item = _items.SingleOrDefault(i => i.Key.Equals(key)) ?? throw new ArgumentException($"Словарь не содержит значение с ключом {key}.", nameof(key));
            return item.Value;
        }
    }
}