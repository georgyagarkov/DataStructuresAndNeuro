using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedListG<T>:IEnumerable<T>
    {
        private Item<T> head = null;
        private Item<T> tail = null;

        private int count = 0;

        public int Count
        {
            get { return count; }
        }

        public void Printlist()
        {
            var current=head;
            if (current != null)
            {
                while (current != null)
                {
                    Console.Write(current.ToString() + " ");
                    current=current.Next;
                }
                Console.WriteLine();
            }
        }

        public void AppendTail(T data)
        {
            if(data == null)throw new ArgumentNullException(nameof(data)); 
            var NewItem = new Item<T>(data);
            if(head == null)
            {
                head = NewItem;
            }
            else
            {
                tail.Next = NewItem;
                NewItem.Previous = tail;
            }
            tail = NewItem;
            count++;
        }

        public void PopBack()
        {
            if (count == 0) throw new InvalidOperationException("List is empty");
            else if (count == 1) { head = null; tail = null; }
            else
            {
                tail = tail.Previous;
                tail.Next.Previous = null;
                tail.Next = null;
            }
            count--;
        }
        public void PopFront()
        {
            if (count == 0) throw new InvalidOperationException("List is empty");
            else if (count == 1) { head = null; tail = null; }
            else
            {
                head= head.Next;
                head.Previous.Next = null;
                head.Previous = null;
            }
            count--;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Delete(T data)
        {
            if(head == null)throw new ArgumentNullException(nameof (data));

            var current = head;
            while(current != null)
            {
                if (current.Data.Equals(data))
                {
                    if(current.Previous == null)
                    {
                        head=head.Next;
                        head.Previous.Next= null;
                        head.Previous = null;
                    }
                    else if(current.Next == null)
                    {
                        tail=tail.Previous;
                        tail.Next.Previous= null;
                        tail.Next = null;
                    }
                    else
                    {
                        current.Previous.Next = current.Next;
                        current.Next.Previous = current.Previous;
                        current.Next = null;
                        current.Previous = null;
                    }
                    count -- ;
                    break;
                }
                current = current.Next;
            }


        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Data;
            }
            current = current.Next;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}