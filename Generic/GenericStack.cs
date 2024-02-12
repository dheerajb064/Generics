using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class GenericStack<T>
    {
        private T[] items;
        private int top;

        public GenericStack(int size)
        {
            items = new T[size];
            top = -1;
        }

        public void Push(T item = default(T))
        {
            if (!typeof(T).IsValueType)
            {
                throw new InvalidOperationException("Cannot insert no value types");
            }
            if(top == items.Length - 1)
            {
                Console.WriteLine("Stack is full");
                return;
            }
            top++;
            items[top] = item;
        }

        public T Pop()
        {
            if(IsEmpty())
            {
                throw new InvalidOperationException("Stack is Empty");
            }
            T item = items[top];
            top--;
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T item = items[top];
            return item;
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

    }
}
