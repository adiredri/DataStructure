using System;

namespace Lists
{

    //   Adir Edri

    //   Lists (Nodes)


    class Program
    {

        // temp functions

        public static int CountNodes(List<int> list)    // count nodes function
        {
            int c = 0;
            for (Node<int> p = list.GetFirst(); p != null; p = p.GetNext())
                c++;
            return c;
        }
        public static void PrintNodes(List<int> list)   // print list function(int)
        {
            for (Node<int> p = list.GetFirst(); p != null; p = p.GetNext())
                Console.Write("{0}, ", p.GetInfo());
        }
        public static void PrintNodes(List<char> list)   // print list function(string)
        {
            for (Node<char> p = list.GetFirst(); p != null; p = p.GetNext())
                Console.Write("{0}, ", p.GetInfo());
        }


        //  ***************************** Questions ***********************************

        /*

        Question 1 - 

        Write a Boolean method that accepts as a parameter a one-way list of integers. The method returns true if the list is a palindrome and false otherwise. 
        You can use auxiliary methods learned in the lecture. A solution must be written in O(N) complexity and a new list must not be created.

        */

        public static bool Polindrom(List<int> list)
        {
            int c = CountNodes(list);
            Node<int> q = null, p = list.GetFirst(), r = p.GetNext();
            if (c % 2 != 0)
            {
                for (int i = 0; i < (c / 2); i++)
                    p = p.GetNext();
                list.Remove(p);
                p = list.GetFirst();
            }
            for (int i = 0; i < c / 2; i++)
            {
                p.SetNext(q);
                q = p;
                p = r;
                if (r != null)
                    r = r.GetNext();
            }
            list.SetFirst(q);
            while (q != null)
            {
                if (q.GetInfo() != p.GetInfo())
                    return false;
                q = q.GetNext();
                p = p.GetNext();
            }
            return true;
        }

        /*
         
        Question 2 - 

        Write a method that receives as a parameter a one-way linked list containing integers.
        The method will return the second largest element in the list(second maximum in the list). 
        Do not change the structure of the list and the content of the sections. for example:
        For the following list 2-7-1-13-2-15-3-22-12-|| list will be returned 15
        For the following list 4-12-1-3-12-5-|| list will be returned 12

        */

        public static int SecondMax(List<int> list)
        {
            Node<int> p = list.GetFirst();
            int max = p.GetInfo(), secmax = p.GetNext().GetInfo();
            if (max < secmax)
            {
                max = secmax;
                secmax = p.GetInfo();
            }
            p = p.GetNext();
            for (; p != null; p = p.GetNext())
            {
                if (max < p.GetInfo())
                {
                    secmax = max;
                    max = p.GetInfo();
                }
                else if (secmax < p.GetInfo())
                    secmax = p.GetInfo();
            }
            return secmax;
        }


        /*
         
        Question 3 -

        Write a static method that will receive as parameters pointers to two one-way linked lists. 
        The method will return a pointer to the member that is the beginning of the longest identical part at the end of the two lists. 
        If the two lists do not have the same end, the method will return NULL. The two lists do not necessarily contain the same number of members. 
        There are no elements that are really common to both lists, only the values are the same. Do not change the lists themselves and do not allocate additional memory to maintain. 
        The solution must be performed directly on the list without using arrays at all and with O(N) complexities. Example:
        List A: 1->2->4->6->8->10->15->null
        List B: 2->4->8->10->15->null
        The returned value will be a pointer to the member that contains the value 8 in list A (or list B). 
        (The longest identical part is the one starting with the member numbered 8, followed by the members numbered 10 and 15, a total of 3 members).

         */


        public static Node<int> FindMaxSuffix(List<int> list1, List<int> list2)
        {
            Node<int> q1 = null, p1 = list1.GetFirst(), r1 = p1.GetNext();
            Node<int> q2 = null, p2 = list2.GetFirst(), r2 = p2.GetNext();
            while (p1 != null)
            {
                p1.SetNext(q1);
                q1 = p1;
                p1 = r1;
                if (r1 != null)
                    r1 = r1.GetNext();
            }
            list1.SetFirst(q1);
            while (p2 != null)
            {
                p2.SetNext(q2);
                q2 = p2;
                p2 = r2;
                if (r2 != null)
                    r2 = r2.GetNext();
            }
            list2.SetFirst(q2);
            if (q1.GetInfo() != q2.GetInfo())
                return null;
            while (q1.GetInfo() == q2.GetInfo())
            {
                if (q1.GetNext().GetInfo() != q2.GetNext().GetInfo())
                    return q1;
                q1 = q1.GetNext();
                q2 = q2.GetNext();
            }
            return q1;
        }

        /*
         
        Question 4 -

        Write a static method that accepts as a parameter a pointer to a one-way linked list, consisting of the numbers 0 and 1 only. 
        The method must build a new list that will contain the series of different sequence lengths that appeared in the input.
        Finally, the method will print the number of times the digit was changed including a corresponding message.
        example:
        For the input: 0 0 1 1 0 0 1 1 1 1 0 1 0 0 1 1 0 0 1 1 1 <-List
        The output is:
        • The lengths of the series: 2 2 2 4 1 1 2 2 2 3 <1-List
        • The number of times the digit changed is: 9
         
        */

        public static void Sequence(List<int> list)
        {
            int c1 = 1, c2 = 0;
            List<int> newList = new List<int>();
            Node<int> p = list.GetFirst(), q = newList.GetFirst();
            for (; p != null; p = p.GetNext())
            {
                if (p.GetInfo() != 0 && p.GetInfo() != 1)
                {
                    Console.WriteLine("The list must have only 0 or 1 numbers");
                    return;
                }
            }
            p = list.GetFirst();
            while (p != null)
            {
                while (p.GetNext() != null && p.GetInfo() == p.GetNext().GetInfo())
                {
                    c1++;
                    p = p.GetNext();
                }
                q = newList.Insert(q, c1);
                c1 = 1;
                c2++;
                p = p.GetNext();
            }
            Console.WriteLine("The Length serie: {0} ", newList);
            Console.WriteLine("Number times of replaceing: {0}", c2 - 1);
        }


        /*

        Question 5 -  
        
        Write a method that will receive as a parameter a one-way linked list (list) containing integers and a number n, and will return the chain after a circular transfer of N links. 
        The link and the list must be used. Let n be greater than zero.

        */

        public static List<int> ShiftElem(List<int> list, int n)
        {
            int c = CountNodes(list);
            Node<int> p = list.GetFirst(), q;
            for (int i = 0; i < c - n - 1; i++)
                p = p.GetNext();
            q = p;
            while (p.GetNext() != null)
                p = p.GetNext();
            p.SetNext(list.GetFirst());
            list.SetFirst(q.GetNext());
            q.SetNext(null);
            return list;
        }


        /*

        Question 6 -

        A list of "ordered sequences" is a list in which an even number is found in all the even places in the list, 
        and an odd number is found in all the odd places in the list. A method must be written that receives as a parameter a one-way linked list 
        and returns true if the list is a list of "ordered sequences" and false otherwise. Only the link interface should be used.

        */

        public static bool OddEven(List<int> list)
        {
            int c = CountNodes(list);
            Node<int> p = list.GetFirst();
            for (int i = 1; i <= c; i++)
            {
                if (i % 2 == 0)
                {
                    if (p.GetInfo() % 2 != 0)
                        return false;
                }
                else if (p.GetInfo() % 2 == 0)
                    return false;
                p = p.GetNext();
            }
            return true;
        }


        /*

        Question 7 -

        Write a method that receives as a parameter a one-way linked list containing positive integers. 
        A "wave" sequence is defined as a sequence of numbers in which the first number is less than the second number, 
        the second number is greater than the third number, the third is less than the fourth, the fourth is greater than the fifth and so on. 
        Find and return the length of the largest "wavy" sequence in a given list. Only the link and list interface should be used. for example:
        For the following list ||→12→22→3→15→2→13→1→7→2 list will be returned 9
        For the following list ||→5→1→3→31→12→4 list 3 will be returned.

        */

        public static int LongGal(List<int> list)
        {
            int c = 1, cmax = 1, count = CountNodes(list);
            Node<int> p = list.GetFirst();
            for (int i = 0; i < count; i++)
            {
                if ((c % 2 != 0 && p.GetInfo() < p.GetNext().GetInfo()) || (c % 2 == 0 && p.GetInfo() > p.GetNext().GetInfo()))
                {
                    c++;
                    p = p.GetNext();
                }
                else
                    c = 1;
                if (cmax < c)
                    cmax = c;
            }
            return cmax;
        }

        /*

        Question 8 - 

        Write a method that receives as a parameter a one-way linked list list containing integers. The method will return a new list containing the last 3 elements in the list. 
        The link and list interface must be used. for example:
        For the following list ||→12→22→3→15→2→13→1→7→2 :list
        The following list will be obtained ||→12→22→3 :list1

        */
        public static List<int> OnlyThree(List<int> list)
        {
            int c = CountNodes(list);
            List<int> newList = new List<int>();
            Node<int> p = list.GetFirst(), q = newList.GetFirst();
            for (int i = 0; i < c - 3; i++)
                p = p.GetNext();
            for (int i = 0; i < 3; i++)
            {
                q = newList.Insert(q, p.GetInfo());
                p = p.GetNext();
            }
            return newList;
        }

        /*

        Question 9 -

        Write a method that receives as a parameter a pointer to a one-way linked list 1list containing integers and some number num. 
        The method will search the list for a sequence of values (or a single value) whose sum is num. 
        If there is no such method the method will return false otherwise the method will return true. For example:
        if the list contains the numbers: list1: ||→4→7→3→1→5 
        and the value of num = 15, then the method will return false.
        and if the value of num = 11, so the method will return true (1+3+7=11).

        */

        public static bool SumOfNum(List<int> list, int n)
        {
            Node<int> p = list.GetFirst(), q = list.GetFirst();
            int c = q.GetInfo();
            while (q != null && p != null)
            {
                if (n == c)
                    return true;
                if (n > c)
                {
                    p = p.GetNext();
                    if (p != null)
                        c += p.GetInfo();
                }
                else if (n < c)
                {
                    c = 0;
                    q = q.GetNext();
                    p = q;
                }
            }
            return false;
        }

        /*

        Question 10 -

        Given a list of integers. We will define a sequence as a collection of adjacent cells that contain the same value. example:
        For the list (from left to right): ||<- 9 <- 2 <- 2 <- 2 <- 5 <- 5 <-list
        There are three sequences: a sequence of two numbers 5, a sequence of three numbers 2 and one sequence of the number 9.
        Write a method that accepts as a parameter a list of integers and returns the maximum sequence length in the list. For example: 
        for the list above, the number 3 will be returned. If there are several sequences of the same length, the method will return the length of one of them.

        */

        public static int maxSequence(List<int> list)
        {
            int max = 1, count = 1;
            Node<int> p = list.GetFirst();
            for (; p.GetNext() != null; p = p.GetNext())
            {
                if (p.GetInfo() == p.GetNext().GetInfo())
                    count++;
                else
                    count = 1;
                if (max < count)
                    max = count;
            }
            return max;
        }

        /*

        Question 11 -

        Write a method that accepts as a parameter a pointer to a one-way linked list containing letters. 
        The method will return a new list containing the sequenced letter in the list and then the number of elements in the sequence. for example:
        The following is the list for: A→A→B→C→C→C→C→B→B→B
        The new list will be received: A→2→B→1→C→4→B→3

        */

        public static List<char> Reduce(List<char> list)
        {
            int c = 1;
            List<char> temp = new List<char>();
            Node<char> p = list.GetFirst(), q = temp.GetFirst();
            for (; p.GetNext() != null; p = p.GetNext())
            {
                if (p.GetInfo() == p.GetNext().GetInfo())
                    c++;
                else
                {
                    q = temp.Insert(q, p.GetInfo());
                    q = temp.Insert(q, ((char)c));
                    c = 1;
                }
            }
            c = Convert.ToChar(c);
            q = temp.Insert(q, p.GetInfo());
            q = temp.Insert(q, Convert.ToChar(c));
            return temp;
        }

        /*

        Question 12 -

        The Numbers method receives a list (list) that contains numbers that are represented by a sequence of digits in base 10,
        and returns a new list (temp) that contains the numbers represented in the list. Write it using the vertices interface.
        */

        public static List<int> Numbers(List<int> list)
        {
            double num = 0; 
            double c = 1;
            List<int> temp = new List<int>();
            Node<int> p = list.GetFirst(), q = temp.GetFirst();
            for (; p != null; p =p.GetNext())
            {
                if (p.GetInfo() != -1)
                {
                    if (num == 0)
                        num += p.GetInfo();
                    else
                    {
                        num += Math.Pow(10, c) * p.GetInfo();
                        c++;
                    }
                }
                else
                {
                    q = temp.Insert(q, (int)num);
                    num = 0;
                    c = 1;
                }
            }
            return temp;
        }

        static void Main(string[] args)
        {

            //   Q1
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 1);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 1);
            Console.WriteLine("Q1   --- >  Palindrom ? : {0}", Polindrom(list));
            */

            //    Q2
            /*
            List<int> list1 = new List<int>();
            Node<int> T2 = list1.Insert(null, 46);
            T2 = list1.Insert(T2, 45);
            T2 = list1.Insert(T2, 12);
            T2 = list1.Insert(T2, 41);
            T2 = list1.Insert(T2, 38);
            T2 = list1.Insert(T2, 32);
            Console.WriteLine("Q2   --- >  The second max in your list is : {0}", SecondMax(list1));
            */

            //    Q3
            /*
            List<int> list2 = new List<int>();
            List<int> list3 = new List<int>(); 
            Node<int> a = list2.Insert(null, 1);
            a = list2.Insert(a, 2);
            a = list2.Insert(a, 4);
            a = list2.Insert(a, 6);
            a = list2.Insert(a, 8);
            a = list2.Insert(a, 10);
            a = list2.Insert(a, 14);
            Node<int> b = list3.Insert(null, 2);
            b = list3.Insert(b, 4);
            b = list3.Insert(b, 8);
            b = list3.Insert(b, 10);
            b = list3.Insert(b, 15);
            Console.WriteLine("Q3   --- >  The num of the start of the both length is: {0}" , FindMaxSuffix(list2, list3));
            */

            //  Q4
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 1);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 1);
            Sequence(list);
            */

            //  Q5
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 7);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 4);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 15);
            T1 = list.Insert(T1, 9);
            T1 = list.Insert(T1, 6);
            int n = 3;
            Console.WriteLine(list);
            Console.WriteLine(ShiftElem(list, n));
            */

            //  Q6
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 7);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 6);
            T1 = list.Insert(T1, 15);
            T1 = list.Insert(T1, 8);
            T1 = list.Insert(T1, 9);
            Console.WriteLine(OddEven(list));
            */

            //   Q7
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 4);
            T1 = list.Insert(T1, 12);
            T1 = list.Insert(T1, 31);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 5);
            Console.WriteLine(LongGal(list));
            */

            //  Q8
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 4);
            T1 = list.Insert(T1, 12);
            T1 = list.Insert(T1, 31);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 5);
            Console.WriteLine(OnlyThree(list));
            */

            //  Q9
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 5);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 7);
            T1 = list.Insert(T1, 4);
            Console.WriteLine("ans for n = 15: {0} ", SumOfNum(list, 15));
            Console.WriteLine("ans for n = 11: {0} ", SumOfNum(list, 11));
            */

            // Q10

            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 2);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 2);
            T1 = list.Insert(T1, 1);
            T1 = list.Insert(T1, 2);
            Console.WriteLine(maxSequence(list));
            */

            // Q11
            /*
            List<char> list = new List<char>();
            Node<char> T1 = list.Insert(null, 'A');
            T1 = list.Insert(T1, 'A');
            T1 = list.Insert(T1, 'B');
            T1 = list.Insert(T1, 'C');
            T1 = list.Insert(T1, 'C');
            T1 = list.Insert(T1, 'C');
            T1 = list.Insert(T1, 'C');
            T1 = list.Insert(T1, 'B');
            T1 = list.Insert(T1, 'B');
            T1 = list.Insert(T1, 'B');
            Console.WriteLine(Reduce(list));
            */

            // Q12
            /*
            List<int> list = new List<int>();
            Node<int> T1 = list.Insert(null, 1);
            T1 = list.Insert(T1, 3);
            T1 = list.Insert(T1, 4);
            T1 = list.Insert(T1, -1);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, 5);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, 0);
            T1 = list.Insert(T1, -1);
            Console.WriteLine(Numbers(list));
            */

        }
    }
}
