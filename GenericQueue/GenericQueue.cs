using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericQueue
{
    public class GenericQueue<T> where T : class
    {
        private List<T> items;

        public GenericQueue()
        {
            items = new List<T>();
        }

        public void Enqueue(T item = default(T))
        {
            items.Add(item);
        }

        public T Dequeue()
        {
            if(items.Count == 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }

    }
}
