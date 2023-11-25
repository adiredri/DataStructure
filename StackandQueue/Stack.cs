using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueue
{

    // Adir Edri

    // Stack Class

    class Stack<T>
    {
        public const int Size = 100;
        private T[] data;
        private int sp;

        public Stack()
        {
            data = new T[Size];
            sp = -1;
        }
        public bool isEmpty()
        {
            return (sp == -1);
        }
        public void Push(T x)
        {
            if (Size - 1 == sp)
                Console.WriteLine("Stack is full");
            else
                data[++sp] = x;
        }
        public T Top()
        {
            return data[sp];
        }
        public T Pop()
        {
            return data[sp--];
        }
    }
}