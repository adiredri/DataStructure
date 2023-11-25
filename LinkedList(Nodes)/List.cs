using System;
using System.Collections.Generic;
using System.Text;

namespace Lists
{
    // Adir Edri

    // List Class

    class List<T>
    {
        private Node<T> first;
        public List()
        {
            first = null;
        }
        public Node<T> GetFirst()
        {
            return first;
        }
        public void SetFirst(Node<T> first)
        {
            this.first = first;
        }
        public bool IsEmpty()
        {
            return first == null;
        }
        public Node<T> Insert(Node<T> pos, T x)
        {
            Node<T> temp = new Node<T>(x);
            if (pos == null)
            {
                temp.SetNext(first);
                first = temp;
            }
            else
            {
                temp.SetNext(pos.GetNext());
                pos.SetNext(temp);
            }
            return temp;
        }
        public Node<T> Remove(Node<T> pos)
        {
            if (first == pos)
                first = pos.GetNext();
            else
            {
                Node<T> ptr = this.GetFirst();
                while (ptr.GetNext() != pos)
                    ptr = ptr.GetNext();
                ptr.SetNext(pos.GetNext());
                pos = pos.GetNext();
            }

            return pos;
        }
        public override string ToString()
        {
            Node<T> ptr = first;
            string str = "";
            while (ptr != null)
            {
                str += ptr.ToString();
                str += ",";
                ptr = ptr.GetNext();
            }
            return str;
        }
    }
}
