
namespace Map
{
    public class Item<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Item() { }

        public Item(TKey key, TValue value)
        {
            if(key == null)throw new ArgumentNullException("key");
            if(value == null)throw new ArgumentNullException("value");
            Key = key;
            Value = value;
        }
        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
