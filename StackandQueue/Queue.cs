using System;
using System.Collections.Generic;
using System.Text;

namespace StackQueue
{

    // Adir Edri

    // Queue Class

    public class Queue<T>
    {
        private const int MAXVECTOR = 100;
        private const int EMPTY = -1;
        private T[] vectorInt;
        private int front;
        private int rear;
        public Queue()
        {
            vectorInt = new T[MAXVECTOR];
            front = 0;
            rear = EMPTY;
        }
        public void insert(T x)
        {
            vectorInt[++rear] = x;
        }
        public bool IsEmpty()
        {
            bool result = false;
            if (rear < front) result = true;
            return result;
        }
        public T remove()
        {
            T result;
            result = vectorInt[front++];
            return result;
        }
        public T Head()
        {
            return vectorInt[front];
        }
    }
}