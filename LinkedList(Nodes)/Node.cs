using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{

    // Adir Edri

    // Node Class

    class Node<T>
    {
        private T value;
        private Node<T> next;
        public Node(T value)
        {
            this.value = value;
            this.next = null;
        }
        public Node(T value, Node<T> next)
        {
            this.value = value;
            this.next = next;
        }
        public Node<T> GetNext()
        {
            return next;
        }
        public T GetInfo()
        {
            return value;
        }
        public void SetInfo(T value)
        {
            this.value = value;
        }
        public void SetNext(Node<T> next)
        {
            this.next = next;
        }
        public override string ToString()
        {
            return value.ToString() + " ";
        }
    }
}
