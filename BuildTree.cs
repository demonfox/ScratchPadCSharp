using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPad
{
    //public class Node
    //{
    //    public int value;
    //    public Node left = null;
    //    public Node right = null;
    //    public Node(int v)
    //    {
    //        value = v;
    //    }
    //}

    class Tree
    {
        private const int SCREEN_WIDTH = 64;
        private Node root = null;

        public void InitTree()
        {
            Node n1 = new Node(9);
            Node n2 = new Node(5);
            Node n3 = new Node(15);
            Node n4 = new Node(3);
            Node n5 = new Node(10);
            Node n6 = new Node(13);

            n1.left = n2; n1.right = n3;
            n2.left = n4; n2.right = n5;
            n3.left = n6;

            root = n1;
        }

        public void BuildTree(int[] vals)
        {
            if (vals.Length == 0)
                return;

            BuildTreeHelper(vals, ref root, 0, vals.Length-1);
        }

        private void BuildTreeHelper(int[] vals, ref Node curr, int start, int end)
        {
            if (start > end || start >= vals.Length)
            {
                curr = null;
                return;
            }

            int midNodeIndex = (start + end) / 2; 
            curr = new Node(vals[midNodeIndex]);
            BuildTreeHelper(vals, ref curr.left, start, midNodeIndex - 1);
            BuildTreeHelper(vals, ref curr.right, midNodeIndex + 1, end);
        }

        public void PrintVTree()
        {
            if (root != null)
            {
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);
                PrintHelper(q, 0);
            }
        }

        public void FindLevelLinkList()
        {
            ArrayList result = new ArrayList();

            FindLevelLinkListHelper(root, 0, result);

            foreach (object o in result)
            {
                List<Node> currList = (List<Node>)o;
                foreach (Node n in currList)
                {
                    Console.Write("{0} ", n.value);
                }
                Console.WriteLine();
            }
        }
        
        private void FindLevelLinkListHelper(Node curr, int level, ArrayList result)
        {
            if (curr == null)
                return;

            if (level > result.Count - 1)
                result.Add(new List<Node>());

            List<Node> currList = (List<Node>)result[level];
            currList.Add(curr);

            FindLevelLinkListHelper(curr.left, level + 1, result);
            FindLevelLinkListHelper(curr.right, level + 1, result);
        }

        private void PrintHelper(Queue<Node> q, int depth)
        {
            int indentSize = SCREEN_WIDTH / (1 << depth);
            for (int i = 0; i < (1 << depth); i++)
            {
                if (q.Count > 0)
                {
                    Node n = q.Dequeue();
                    String indent = new String(' ', indentSize);
                    Console.Write(indent);
                    Console.Write(n.value);
                    Console.Write(indent);
                    if (n.left != null)
                        q.Enqueue(n.left);
                    if (n.right != null)
                        q.Enqueue(n.right);
                }
                else
                {
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine();
            PrintHelper(q, depth + 1);
        }
    }
}
