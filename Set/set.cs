namespace Set
{
    public class Set<T> : IEnumerable<T>
    {
        private List<T> _items = new List<T>();
        public int Count => _items.Count;

        public void Add(T item)
        {
            if (item == null) throw new ArgumentNullException("item");
            if (!_items.Contains(item)) _items.Add(item);
        }

        public void Remoove(T item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (!_items.Contains(item)) throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
            _items.Remove(item);
        }

        public static Set<T> Union(Set<T> set1, Set<T> set2)
        {
            if(set1==null)throw new ArgumentNullException(nameof(set1));
            if(set2==null)throw new ArgumentNullException(nameof(set2));
            var items = new List<T>();
            items.AddRange(new List<T>(set2._items));
            items.AddRange(new List<T>(set1._items));
            var result = new Set<T>();
            result._items=  items.Distinct().ToList();
            return result;
        }

        public static Set<T> Intersection(Set<T> set1, Set<T> set2)
        {
            if (set1 == null) throw new ArgumentNullException(nameof(set1));
            if (set2 == null) throw new ArgumentNullException(nameof(set2));

            var result = new Set<T>();

            if(set1.Count < set2.Count)
            {
                foreach (var item in set1._items) if (set2._items.Contains(item)) result._items.Add(item);
            }
            else
            {
                foreach (var item in set2._items) if(set1._items.Contains(item)) result._items.Add(item);
            }
            return result;
        }
        public static bool Subset(Set<T> set1, Set<T> set2)
        {
            if (set1 == null){throw new ArgumentNullException(nameof(set1));}
            if (set2 == null){throw new ArgumentNullException(nameof(set2));}

            var result = set1._items.All(s => set2._items.Contains(s));
            return result;
        }



    }
}