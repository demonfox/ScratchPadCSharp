using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPadCSharp
{
    public class Node
    {
        public int value;
        public Node left = null;
        public Node right = null;
        public Node(int v)
        {
            value = v;
        }
    }

    public class ValidateBinarySearchTree
    {
        public static bool Validate(Node root, int lowerBound, int upperBound)
        {
            if (root == null)
                return true;

            if (root.value < lowerBound || root.value > upperBound)
                return false;

            return Validate(root.left, lowerBound, root.value) && Validate(root.right, root.value, upperBound);
        }

        //public static void Main()
        //{
        //    TestCase1();
        //    TestCase2();
        //    TestCase3();
        //    TestCase4();
        //}

        private static void TestCase1()
        {
            //       9
            //    5      15
            //  4   7  13
            Node n1 = new Node(9);
            Node n2 = new Node(5);
            Node n3 = new Node(15);
            Node n4 = new Node(4);
            Node n5 = new Node(7);
            Node n6 = new Node(13);

            n1.left = n2; n1.right = n3;
            n2.left = n4; n2.right = n5;
            n3.left = n6;
            Console.WriteLine("TestCase1: " + Validate(n1, int.MinValue, int.MaxValue));
        }

        private static void TestCase2()
        {
            //        9
            //    5      15
            //  3   4   13
            Node n1 = new Node(9);
            Node n2 = new Node(5);
            Node n3 = new Node(15);
            Node n4 = new Node(3);
            Node n5 = new Node(4);
            Node n6 = new Node(13);

            n1.left = n2; n1.right = n3;
            n2.left = n4; n2.right = n5;
            n3.left = n6;
            Console.WriteLine("TestCase2: " + Validate(n1, int.MinValue, int.MaxValue));
        }

        private static void TestCase3()
        {
            //        9
            //          7
            Node n1 = new Node(9);
            Node n2 = new Node(7);

            n1.right = n2;
            Console.WriteLine("TestCase3: " + Validate(n1, int.MinValue, int.MaxValue));
        }

        private static void TestCase4()
        {
            //        9
            //    5        15
            //  3   10   13
            Node n1 = new Node(9);
            Node n2 = new Node(5);
            Node n3 = new Node(15);
            Node n4 = new Node(3);
            Node n5 = new Node(10);
            Node n6 = new Node(13);

            n1.left = n2; n1.right = n3;
            n2.left = n4; n2.right = n5;
            n3.left = n6;
            Console.WriteLine("TestCase4: " + Validate(n1, int.MinValue, int.MaxValue));
        }
    }
}
