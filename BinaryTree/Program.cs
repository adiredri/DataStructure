using System;

namespace BinTree
{

    // Adir Edri

    class Program
    {

        /*
         
        Question 1 -

        Given a binary tree containing even and odd numbers:
        A. Write a method that will return the sum of the odd numbers stored in the tree.
        B. Write a method that will return the number of left children in the tree. For tree 2 in the example below 2 will be returned.
        C. Write a method that will return the number of right pointers whose value is equal to NULL. For tree 3 in the example below 2 will be returned.

        */

        //  Q1.A

        public static int SumEiZugi(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.GetInfo() % 2 != 0)
                return SumEiZugi(bt.GetLeft()) + SumEiZugi(bt.GetRight()) + bt.GetInfo();
            return SumEiZugi(bt.GetLeft()) + SumEiZugi(bt.GetRight());
        }

        //  Q1.B

        public static int CountLeftSons(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.GetLeft() != null)
                return CountLeftSons(bt.GetLeft()) + CountLeftSons(bt.GetRight()) + 1;
            return CountLeftSons(bt.GetLeft()) + CountLeftSons(bt.GetRight());
        }

        //  Q1.C

        public static int RightNulls(BinTreeNode<int> bt)
        {
            if (bt == null)
                return 0;
            if (bt.GetRight() == null)
                return RightNulls(bt.GetLeft()) + RightNulls(bt.GetRight()) + 1;
            return RightNulls(bt.GetLeft()) + RightNulls(bt.GetRight());
        }


        /*
         
         Question 2 -

         Build a binary search tree containing positive and negative numbers:
         A. Display the tree using the INORDER scan method.
         B. Write a method that will receive as a parameter a pointer to a binary search tree and some value X. The method will print all the nodes whose value is greater than X.

         */


        //  Q2.1

        public static void Inorder(BinTreeNode<int> root)
        {
            if (root != null)
            {
                Inorder(root.GetLeft());
                Console.WriteLine(root.GetInfo());
                Inorder(root.GetRight());
            }
        }

        //  Q2.2

        public static int BiggerThanX(BinTreeNode<int> bst, int x)
        {
            if (bst == null)
                return 0;
            if (bst.GetInfo() > x)
            {
                Console.WriteLine(bst.GetInfo());
                return BiggerThanX(bst.GetRight(), x) + BiggerThanX(bst.GetLeft(), x);
            }
            return BiggerThanX(bst.GetRight(), x);
        }

        /*
        
         Question 3 -

         Write a method that returns true if for each node in the tree with 0 or 2 children - 
         the left child has a negative value and the right child has a positive value and false otherwise.   
        
         */

        public static bool OppositeNode(BinTreeNode<int> bt)      //   Q3
        {
            if (bt.GetRight() == null && bt.GetLeft() == null)
                return true;
            else if ((bt.GetRight() != null && bt.GetLeft() == null) || (bt.GetRight() == null && bt.GetLeft() != null))
                return false;
            else if ((bt.GetRight().GetInfo() > 0) && (bt.GetLeft().GetInfo() < 0))
                return OppositeNode(bt.GetRight()) && OppositeNode(bt.GetLeft());
            else
                return false;
        }


        static void Main(string[] args)
        {

            //  Q1

            BinTreeNode<int> bt1 = new BinTreeNode<int>(8);
            BinTreeNode<int> bt2 = new BinTreeNode<int>(5);
            BinTreeNode<int> bt3 = new BinTreeNode<int>(12);
            BinTreeNode<int> bt4 = new BinTreeNode<int>(7);
            BinTreeNode<int> bt5 = new BinTreeNode<int>(10);
            BinTreeNode<int> bt6 = new BinTreeNode<int>(14);
            bt1.SetLeft(bt2);
            bt1.SetRight(bt3);
            bt2.SetRight(bt4);
            bt3.SetLeft(bt5);
            bt3.SetRight(bt6);

            Console.WriteLine("************* Q1 *****************");
            Console.WriteLine();
            Console.WriteLine("Your tree by inorder: ");
            Inorder(bt1);
            Console.WriteLine();
            Console.WriteLine("For this tree: ");
            Console.WriteLine("A ---> Sum of ei-zugi numbers is: {0} ", SumEiZugi(bt1));     //  A
            Console.WriteLine("B ---> Count of left sons is: {0} ", CountLeftSons(bt1));     //  B
            Console.WriteLine("C ---> Count of Right's nulls is: {0} ", RightNulls(bt1));    //  C


            //  Q2

            BinTreeNode<int> bst1 = new BinTreeNode<int>(4);
            BinTreeNode<int> bst2 = new BinTreeNode<int>(-12);
            BinTreeNode<int> bst3 = new BinTreeNode<int>(10);
            BinTreeNode<int> bst4 = new BinTreeNode<int>(-8);
            BinTreeNode<int> bst5 = new BinTreeNode<int>(9);
            BinTreeNode<int> bst6 = new BinTreeNode<int>(11);
            bst1.SetLeft(bst2);
            bst1.SetRight(bst3);
            bst2.SetRight(bst4);
            bst3.SetLeft(bst5);
            bst3.SetRight(bst6);

            Console.WriteLine();
            Console.WriteLine("************* Q2 *****************");
            Console.WriteLine();
            Console.WriteLine("A ---> Your tree by inorder: ");     // A
            Inorder(bst1);
            Console.WriteLine();
            Console.WriteLine("Enter your parameter: ");            // B
            int x = int.Parse(Console.ReadLine());  // -- >   Choose parameter 
            Console.WriteLine();
            Console.WriteLine("B ---> The numbers in the tree that bigger than your parameter ({0}) , is: ", x);
            BiggerThanX(bst1, x);


            //  Q3

            // A

            BinTreeNode<int> bt1A = new BinTreeNode<int>(20);

            //  B

            BinTreeNode<int> bt1B = new BinTreeNode<int>(-10);
            BinTreeNode<int> bt2B = new BinTreeNode<int>(-15);
            BinTreeNode<int> bt3B = new BinTreeNode<int>(20);
            BinTreeNode<int> bt4B = new BinTreeNode<int>(-3);
            BinTreeNode<int> bt5B = new BinTreeNode<int>(30);
            bt1B.SetLeft(bt2B);
            bt1B.SetRight(bt3B);
            bt3B.SetLeft(bt4B);
            bt3B.SetRight(bt5B);

            //  C

            BinTreeNode<int> bt1C = new BinTreeNode<int>(-10);
            BinTreeNode<int> bt2C = new BinTreeNode<int>(-20);
            BinTreeNode<int> bt3C = new BinTreeNode<int>(30);
            BinTreeNode<int> bt4C = new BinTreeNode<int>(40);
            bt1C.SetLeft(bt2C);
            bt1C.SetRight(bt3C);
            bt3C.SetRight(bt4C);

            //  D

            BinTreeNode<int> bt1D = new BinTreeNode<int>(30);
            BinTreeNode<int> bt2D = new BinTreeNode<int>(15);
            BinTreeNode<int> bt3D = new BinTreeNode<int>(20);
            bt1D.SetLeft(bt2D);
            bt1D.SetRight(bt3D);

            Console.WriteLine();
            Console.WriteLine("************* Q*****************");
            Console.WriteLine();
            Console.WriteLine("This is the results of the 4 Exampels for Opposite Node: ");
            Console.WriteLine();
            Console.WriteLine("Chart 1 is: {0} ", OppositeNode(bt1A));
            Console.WriteLine("Chart 2 is: {0} ", OppositeNode(bt1B));
            Console.WriteLine("Chart 3 is: {0} ", OppositeNode(bt1C));
            Console.WriteLine("Chart 4 is: {0} ", OppositeNode(bt1D));

        }
    }
}