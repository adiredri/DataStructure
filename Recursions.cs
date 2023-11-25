using System;

namespace Recursion
{

    // Adir Edri

    // Recursion Methods - Time & place complexity.

    class Program
    {
        public static void Print(int[] a)       //  temp function
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + ", ");
            Console.WriteLine();
        }


        /*

        Question 1 -

        Write a recursive static method that accepts as a parameter a positive integer n and returns a new number by reversing the order of the digits. 
        For example: if the number is 1749 then the number 9471 will be returned.
        Pay attention not to print but to reverse the number.

        */

        public static int reverse(int n)    //  Q1
        {
            return reverse(n, 0);

        }
        public static int reverse(int n, int x)             
        {
            if (n > 10)
                return (reverse(n / 10, (x + n % 10) * 10));
            else
                return x + n;
        }


        /*
         
        Question 2 -

        Write a recursive static method that accepts as a parameter a one-dimensional array of integers 
        and returns true if the array is sorted in ascending order and false otherwise.

        */


        public static bool Order(int[] a)    //   Q2
        {
            return Sidra(a, 0);
        }
        private static bool Sidra(int[] a, int i)   
        {
            if (i == a.Length - 1)
                return true;
            else if (a[i] >= a[i + 1])
                return false;
            return Sidra(a, i + 1);
        }


        /*

        Question 3 -

        Write a recursive static method that accepts a character string s and and returns the number of occurrences of the character c in the string s.
        For example:
        The method howManyChar("Moshe Cohn",'m') will return the value 0.
        The method howManyChar("Moshe Cohn",'M') will return the value 1.
        The method howManyChar("Moshe Cohn",'o') will return the value 2.

        */

        public static int howManyChar(string s, char c)     //  Q3
        {
            if (s.Length == 0)
                return 0;
            else if (s[0] == c)
                return 1 + howManyChar(s.Substring(1), c);
            else
                return howManyChar(s.Substring(1), c);
        }

        /*
         
         Question 4 - 

         Write a recursive method that counts the occurrences of the characters 'start' and 'end' in the string 'str' 
         and returns the total number of occurrences of 'start' before each occurrence of 'end'.

        */

        public static int What(string str, char start, char end)  //  Q4
        {
            int c = 0, temp = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == start)
                    temp += 1;
                else if (str[i] == end)
                    c += temp;
            }
            return c;
        }

        /*

        Question 5 - 

        Write a recursive method that will return index 'i' in the array, so that the sum of elements 0 to 'i' is equal to the sum of elements i+1 until the end of the array. 
        If there is no such index, the method returns -1. Write the method with minimal complications.

        */

        public static int f1(int[] a)   //  Q5
        { 
            int sum = 0, x = 0;
            for (int i = 0; i < a.Length; i++)
                sum += a[i];
            for (int i = 0; i < a.Length - 1; i++)
            {
                x += a[i];
                sum -= a[i];
                if (sum == x)
                    return i;
            }
                return -1;
        }

        /*

        Question 6 - 
        
        Write a recursive method that copies to array b all the numbers from array a without repetitions,
        and returns how many different numbers there are in array a.

        */

        public static int sod(int[] a, int[] b)  //  Q6
        {
            int c = 0;
            for (int i = 0; i < a.Length - 1; i++)
                if (a[i] != a[i + 1])
                    b[c++] = a[i];
            b[c++] = a[a.Length - 1];
            Print(b);
            return c;
        }

        /*

        Question 7 - 

        Write a recursive method that ensures that all the members of the first array appear to the members of the second array and vice versa.

        */

        public static bool what(int[] arr, int[] other)   //  Q7
        {
            if (arr.Length != other.Length)
                return false;
            // Quicksort(arr, 0, arr.Length);
            // Quicksort(other, 0, other.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != other[i])
                    return false;
            }
            return true;
        }



        /*

        Question 8 - 

        Write a recursive method that is performed on an array of numbers, and it will return a number that represents the total amount
        of pairs of identical values found at adjacent nodes in the array. Write the method with minimal complications

        */

        public static int what(int[] a)   //  Q8
        {
            int c = 1;
            // quicksort(a,0,a.lentgh);
            for (int i = 0; i < a.Length -1; i++)
                if (a[i] == a[i + 1])
                    return c;
            c++;
            return c;
        }

        /*

        Question 9 - 

        The what method accepts an array of integers, and returns a number that represents the length of the range in the longest multiple array, 
        when the sum of the numbers in the range is divisible by 3. Write the method with minimal complications. 

        */


        public static bool Range(int[] a, int num)   //  Q9 - Time complexity =  O(N^2), place complexity =  O(1)
        {
            int low = 0, high = 0, sum = 0;
            while (high < a.Length)
            {
                if (sum < num)
                {
                    sum += a[high];
                    high++;
                }
                else if (sum > num)
                {
                    sum -= a[low];
                    low++;
                }
                else   // sum == num
                {
                    Console.WriteLine("Between {0} and {1}", low, high - 1);
                    return true;
                }
            }
            Console.WriteLine("No");
            return false;
        }

        static void Main(string[] args)
        {

            //  Q1

            /*
            Console.WriteLine("Enter you number: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Your Upside down number : {0}" , reverse(n));
            */


            //  Q2

            /*
            int[] a = new int[5];
            Console.WriteLine("Enter a new array");
            for (int i = 0; i < a.Length; i++)
                a[i] = int.Parse(Console.ReadLine());
            Console.WriteLine(Order(a));
            */


            //  Q3

            /*
            Console.WriteLine("Enter your char");
            char c = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter your string: ");
            string s = Console.ReadLine();
            Console.WriteLine("In this string the char ({0}) appears {1} times",c, howManyChar(s,c));
            */

            // Q4

            /*
            string str = "bbababbaab";
            Console.WriteLine(What(str,'a','b'));
            */

            // Q5

            /*
            a[0] = 21;
            a[1] = 10;
            a[2] = 2;
            a[3] = 9;
            Console.WriteLine(f1(a));
            */

            // Q6

            /*
            a[0] = 1;
            a[1] = 1;
            a[2] = 2;
            a[3] = 2;
            a[4] = 2;
            Print(a);
            Console.WriteLine(sod(a,b));
            */

            // Q7

            /*
            a[0] = 1;
            a[1] = 1;
            a[2] = 2;
            a[3] = 2;
            a[4] = 2;

            b[0] = 1;
            b[1] = 2;
            b[2] = 1;
            b[3] = 2;
            b[4] = 2;

            Print(a);
            Print(b);
            Console.WriteLine(what(a,b));
            */

            // Q8

            /*
            a[0] = 1;
            a[1] = 1;
            a[2] = 2;
            a[3] = 2;
            a[4] = 2;
            Print(a);
            Console.WriteLine(what(a));
            */

            //  Q9

            /*  
            int[] array = { 1, 4, 7, 3, 9, 2 };
            Console.WriteLine(Range(array, 10));

            int[] a = new int[5];
            int[] b = new int[5];
            */

        }
    }
}
