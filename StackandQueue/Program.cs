using System;

namespace StackQueue
{

    //   Adir Edri

    //   Stack & Queue Questions + Solutions

    class Program
    {
        public static void Print(Stack<char> s)  // temp function
        {
            while (!s.isEmpty())
                Console.Write("{0} ,", s.Pop());
        }


        /*
         
         Question 1 - 

         Given a stack S containing numbers arranged in ascending order. An ascending sequence is a sequence in which each number is greater than or equal to the previous one. 
         For example: 1,3,6,9 is an ascending sequence (so is: 1,3,3,3). The number of sequences in the stack is greater than or equal to 1. 
         For example: ┤1,3,6,7,2,4,1,2,3 (the marking ┤ is for the bottom of the stack) the stack contains ascending sequences (looking from the bottom of the stack to the top of the stack).
         Write a static method that accepts as a parameter a stack as described above and displays as output a new stack containing the sum of members of each of the ascending sequences present in the original stack.

         */

        public static Stack<int> Sequence(Stack<int> s)  // Q1
        {
            Stack<int> s1 = new Stack<int>();
            while (!s.isEmpty())
                s1.Push(s.Pop());
            int x = s1.Pop(), sum = x;
            while (!s1.isEmpty())
            {
                if (s1.Top() >= x)
                {
                    sum += s1.Top();
                    x = s1.Pop();
                }
                else
                {
                    s.Push(sum);
                    //   Console.Write(s.Top() + "  ");     //  --->  open it to present the currently stack.
                    x = s1.Pop();
                    sum = x;
                }
            }
            s.Push(sum);
            //    Console.Write(s.Top() + "  ");    //  --->  open it to present the currently stack.
            return s;
        }


        /*
         
        Question 2 - Given a stack sorted in ascending order whose members are integers. A unique stack is an empty stack or some number does not appear in it more than once. 
        A method must be written that will receive a stack as a parameter and return true if the stack is unique, and false otherwise.
         
        */
        public static bool Unique(Stack<int> s)  // Q2
        {
            if (s.isEmpty())
                return true;
            int x = s.Pop();
            while (!s.isEmpty())
            {
                if (x == s.Top())
                    return false;
                else
                    x = s.Pop();
            }
            return true;
        }

        /*

        Question 3 - 

        Given a stack whose members are integers. A method called Extract must be written, which will receive as a parameter a stack s and return a new stack that consists of pairs of numbers as follows -
        the number in the stack s and another number that contains the amount of identical numbers that are in a row in the stack s. Only the stack interface should be used.
        For example if the stack s contains the numbers (from left to right):   5 5 5 5 5 2 2 2 2 2 2 4 7 7   
        So the new stack that needs to be returned is:   7 2 4 1 2 6 5 5

         */

        public static Stack<int> Extract(Stack<int> s)  //  Q3
        {
            int c = 1, x = s.Pop();
            Stack<int> temp = new Stack<int>();
            while (!s.isEmpty())
            {
                if (x == s.Top())
                    c++;
                else
                {
                    temp.Push(c);
                    temp.Push(x);
                    c = 1;
                }
                x = s.Pop();
            }
            temp.Push(c);
            temp.Push(x);
            while (!temp.isEmpty())
                Console.Write("{0} ,", temp.Pop());
            return temp;

        }

        /*

        Question 4 - 
        
        Given a stack whose elements are positive integers. Write a method that accepts
        stack as a parameter, and returns the last odd number in the stack (the one that is the most at the bottom of the cartridge).
        The original cartridge must be kept at the end of the method.

        */


        public static int Found(Stack<int> s)  // Q4
        {
            int c = 0;
            Stack<int> temp = new Stack<int>();
            while (!s.isEmpty())
            {
                if (s.Top() % 2 != 0)
                    c = s.Top();
                temp.Push(s.Pop());
            }
            while (!temp.isEmpty())
                s.Push(temp.Pop());
            return c;
        }

        // תשפ מועד ב

        /*

        Question 5 -  
        
        Given a non-empty queue of integers containing at most each queue member twice. Write a method that accepts a queue as a parameter, 
        and returns a new queue that contains only the numbers that appeared in the queue twice There is no obligation to maintain the state 
        of the original queue and the order in which the numbers appear in the returned queue is not important.

        */


        public static Queue<int> Doubles(Queue<int> q)  //  Q5
        {
            int x = q.remove();
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                if (x == q.Head())
                    temp.insert(x);
                x = q.remove();
            }
            while (!temp.IsEmpty())
                Console.Write("{0} ,", temp.remove());
            return temp;
        }

        // תשפ מועד א

        /*

        Question 6 - 
        
        Given a stack whose members are integers. Write a method that accepts a stack as a parameter, and returns a new stack. "Block" is defined as a sequence of members 
        (more from one member). For each "block" in the stack there is a member in the new stack, whose value is The product of the member in the "block" the number of times it appears in the "block". 
        The order of the members in the returned stack is not important.

        */


        public static Stack<int> Blocks(Stack<int> s)  //  Q6
        {
            int x = s.Pop(), c = 1;
            Stack<int> temp = new Stack<int>();
            while (!s.isEmpty())
            {
                if (x == s.Top())
                    c++;
                else if (c != 1)
                {
                    temp.Push(x * c);
                    c = 1;
                }
                x = s.Pop();
            }
            if (c != 1)
                temp.Push(x * c);
            while (!temp.isEmpty())
                Console.Write("{0} ,", temp.Pop());
            return temp;
        }

        // תשעט מועד ב

        /*

        Question 7 -
        
        Write a method that accepts as a parameter a stack of integers and returns a new stack that consists of all the elements that are between 
        the first instance of the number -1 and the last instance of the instance -1, 
        assuming that the number -1 appears at least twice. Only interface operations should be used the cartridge.

        */

        public static Stack<int> Show(Stack<int> s)  //  Q7
        {
            int x = s.Pop();
            Stack<int> temp = new Stack<int>();
            while (x != -1)
                x = s.Pop();
            while (!s.isEmpty())
                temp.Push(s.Pop());
            x = temp.Pop();
            while (x != -1)
                x = temp.Pop();
            while (!temp.isEmpty())
                s.Push(temp.Pop());
            while (!s.isEmpty())
                Console.Write("{0} ,", s.Pop());
            return s;
        }


        /*
         
        Question 8 - 

        A queue will be called a ballerina queue if it fulfills the following conditions: the queue is not empty, the number of members in it is even, 
        and for each member in the first half of the queue there is a member with the same value in the second half of the queue, 
        where the order of the members does not have to be parallel between the two halves of the queue.
        Write an external (static) method that accepts as a parameter a queue q whose members are of integer type. 
        If q is a ballerina queue the method will return true, otherwise the operation will return false. It is not important to keep the original queue.

       */

        public static bool Balerina(Queue<int> q)  //  Q8
        {
            int c = 0;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.insert(q.remove());
                c++;
            }
            if (c == 0 || c % 2 != 0)
                return false;
            for (int i = 0; i < c / 2; i++)
                q.insert(temp.remove());
            for (int i = 0; i < c / 2; i++)
            {
                for (int j = i; j < c / 2; i++)
                {
                    if (q.Head() == temp.Head())
                    {
                        q.remove();
                        temp.remove();
                        break;
                    }
                    temp.insert(temp.remove());
                    if (j == (c / 2) - 1)
                        return false;
                }
            }
            return true;
        }

        /*
        
        Question 9 - 

        A "serial" queue is a queue of even length that consists of whole numbers - 
        where in the first half the members are arranged in ascending order and in the second half they are arranged in descending order.

        A. Write a method that accepts a queue and returns true if the queue is serialized, otherwise holds false. In this section, the original order must be kept.

        B. Write a method that accepts a "serial" queue and returns a new queue whose members are ordered as follows: the first member from the serial queue,
        then the last member, the second member from the serial queue, then the member before the last, and so on until the serial queue is emptied. In this section you don't have to keep the original queue.

        */

        public static bool Sidrati1(Queue<int> q)    // Q9A
        {
            int c = 0, x, y;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.insert(q.remove());
                c++;
            }
            if (c == 0 || c % 2 != 0)
                return false;
            for (int i = 0; i < c / 2; i++)
                q.insert(temp.remove());
            x = temp.remove();
            y = q.remove();
            for (int i = 0; i < c / 2 - 1; i++)
            {
                if (x <= temp.Head() || y >= q.Head())
                    return false;
                temp.insert(x);
                q.insert(y);
                x = temp.remove();
                y = q.remove();
            }
            temp.insert(x);
            q.insert(y);
            while (!temp.IsEmpty())
                q.insert(temp.remove());
            /*     while(!q.IsEmpty())
                     Console.Write(" {0} , ", q.remove());*/
            return true;
        }


        public static Queue<int> Sidrati2(Queue<int> q)    // Q9B
        {
            if (!Sidrati1(q))
            {
                Console.WriteLine("Your queue is not sidrati");
                return null;
            }
            int c = 0;
            Queue<int> temp = new Queue<int>();
            while (!q.IsEmpty())
            {
                temp.insert(q.remove());
                c++;
            }
            for (int i = 0; i < c / 2; i++)
                q.insert(temp.remove());
            for (int i = 0; i < c / 2; i++)
            {
                q.insert(q.remove());
                for (int j = i; j < (c / 2) - 1; j++)
                    temp.insert(temp.remove());
                q.insert(temp.remove());
            }
            while (!q.IsEmpty())
                Console.Write(" {0} , ", q.remove());
            return q;
        }

        /*

        Question 10 -

        Given a stack containing numbers arranged as follows: from the bottom of the stack to a certain element in the stack,
        the numbers are arranged in ascending order (the smallest element is at the bottom of the stack), and from that point to the top of the stack,
        the numbers are arranged in descending order. For example: 1,3,6,7,5,4,3,2,1┤ (the marking┤ is for the bottom of the cartridge). 
        Write a static method that accepts as a stack parameter as described above and displays as output the member in which the order of the members 
        has been reversed and the number of the member in which the order of the members has been reversed.

        */

        public static void Who(Stack<int> s)  //  Q10
        {
            int c = 1, x = s.Pop();
            while (!s.isEmpty())
            {
                if (x > s.Top())
                {
                    Console.WriteLine("eivar: {0} , index: {1} ", x, c);
                    break;
                }
                else
                {
                    c++;
                    x = s.Pop();
                }
            }
            if (s.isEmpty())
                Console.WriteLine("there is no eivar");
        }

        /*

        Question 11 -

        Write a Boolean method that will receive as a string parameter, consisting of only the characters A, B and C (no need to check this). 
        The method will check if the string is of the form AnCBn (ie the number A is equal for the number of Bs, all A's at the beginning and all B's at the end) 
        and return "true" if so and "false" otherwise. Must use the stack interface. For example: the words AABCABB, AACB are invalid. The words AACBB, ACB are legal.

        */

        public static bool ACB(string st)  //  Q11
        {
            int c1 = 0, c2 = 0;
            Stack<char> s = new Stack<char>();
            for (int i = 0; i < st.Length; i++)
                s.Push(st[i]);
            while (!s.isEmpty())
            {
                if (s.Top() == 'B')
                {
                    c1++;
                    s.Pop();
                }
                else if (s.Top() == 'C')
                {
                    s.Pop();  // C
                    break;
                }
                else
                    return false;
            }
            while (!s.isEmpty())
            {
                if (s.Top() == 'A')
                {
                    c2++;
                    s.Pop();
                }
                else
                    return false;
            }
            return (c1 == c2);
        }

        static void Main(string[] args)
        {


            // Q11

            /*
            string st = "ACB";
            Console.WriteLine(ACB(st)); 
            */


            // Q10

            /*
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(3);
            stack.Push(6);
            stack.Push(7);
            stack.Push(5);
            stack.Push(4);
            stack.Push(3);
            stack.Push(2);
            stack.Push(1);
            Who(stack);
            */

            //  Q9

            /*
            Queue<int> queue = new Queue<int>();
            queue.insert(-12);
            queue.insert(-1);
            queue.insert(7);
            queue.insert(10);
            queue.insert(40);
            queue.insert(17);
            queue.insert(5);
            queue.insert(3);
            Console.WriteLine(Sidrati1(queue));
            Console.WriteLine(Sidrati2(queue));
            */



            // Q8

            /*
            Queue<int> queue = new Queue<int>();
            queue.insert(4);
            queue.insert(5);
            queue.insert(3);
            queue.insert(3);
            queue.insert(4);
            queue.insert(5);
            Console.WriteLine(Balerina(queue));
            */



            // Q7

            /*
            Stack<int> stack = new Stack<int>();
            stack.Push(2);
            stack.Push(5);
            stack.Push(-1);
            stack.Push(3);
            stack.Push(0);
            stack.Push(-1);
            stack.Push(2);
            stack.Push(-4);
            stack.Push(3);
            stack.Push(-2);
            stack.Push(-1);
            stack.Push(3);
            stack.Push(-5);
            Console.WriteLine(Show(stack));
            */

            // Q6

            /*
            Stack<int> stack = new Stack<int>();
            stack.Push(5);
            stack.Push(5);
            stack.Push(5);
            stack.Push(0);
            stack.Push(0);
            stack.Push(0);
            stack.Push(-4);
            stack.Push(-4);
            Console.WriteLine(Blocks(stack));
            */



            // Q5

            /*
            Queue<int> queue = new Queue<int>();
            queue.insert(4);
            queue.insert(4);
            queue.insert(5);
            queue.insert(6);
            queue.insert(3);
            queue.insert(3);
            Console.WriteLine(Doubles(queue));
            */


            // Q4

            /*
            Stack<int> stack = new Stack<int>();
            stack.Push(4);
            stack.Push(6);
            stack.Push(7);
            stack.Push(5);
            stack.Push(3);
            stack.Push(2);
            Console.WriteLine(Found(stack));
            */


            //   Q3

            /*
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(2);
            stack.Push(3);
            stack.Push(3);
            Extract(stack);
            */


            // Q2

            /*
            Stack<int> stack = new Stack<int>();
            Stack<int> stack2 = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            Console.WriteLine(Unique(stack));
            Console.WriteLine(Unique(stack2));
            */


            // Q1

            /*
            int x;
            Stack<int> s = new Stack<int>();
            Console.WriteLine("Enter the stack (from the last to the first):");
            Console.WriteLine("-|  ");
            x = int.Parse(Console.ReadLine());
            while (x != 0)
            {
                s.Push(x);
                x = int.Parse(Console.ReadLine());
            }
            Console.Write("Your stack: -| ");
            Sequence(s);        
            */


        }
    }
}
