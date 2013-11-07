using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class Tree
    {
        public class Node
        {
            public int value;
            public Node left;
            public Node right;

            public Node(int value)
            {
                this.value = value;
            }
        }

        public enum Child { NONE, LEFT, RIGHT };

        public class PrintNode
        {
            public int val;
            public int row;
            public int column;
            public Child childType;
            public PrintNode parent;
        }

        public Node Root { get; set; }

        public Tree()
        {
            Root = new Node(0);
        }

        public void Insert(int val)
        {
            Node newNode = new Node(val);
            ShiftNode(Root, newNode);
        }

        private void ShiftNode(Node cur, Node newNode)
        {
            if (cur.value > newNode.value)
            {
                if (cur.left == null)
                {
                    cur.left = newNode;
                }
                else
                {
                    ShiftNode(cur.left, newNode);
                }
            }
            else
            {
                if (cur.right == null)
                {
                    cur.right = newNode;
                }
                else
                {
                    ShiftNode(cur.right, newNode);
                }
            }
        }

        #region Breadth-first

        public void LevelOrder(Node start)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.value + ", ");
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }                
            }
        }

        #endregion Breadth-first

        public void PreetyPrint()
        {
            var printList = new List<PrintNode>();
            var queue = new Queue<Node>();
            var parentNode = new PrintNode { val = Root.value, row = 1, childType = Child.NONE };
            queue.Enqueue(Root);
            printList.Add(parentNode);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();                
                if (cur.left != null)
                {
                    var leftChild = new PrintNode { val = cur.left.value, childType = Child.LEFT, parent = printList.First(x => x.val == cur.value) };
                    leftChild.row = leftChild.parent.row + 1;
                    queue.Enqueue(cur.left);
                    printList.Add(leftChild);
                }
                if (cur.right != null)
                {
                    var rightChild = new PrintNode { val = cur.right.value, childType = Child.RIGHT, parent = printList.First(x => x.val == cur.value) };
                    rightChild.row = rightChild.parent.row + 1;
                    queue.Enqueue(cur.right);
                    printList.Add(rightChild);
                }                
            }
            var levelCount = printList.Max(x => x.row);
            int maxColumn = (int)Math.Pow(2, levelCount) - 1;
            int level = 1;
            int curColumn = 0;
            foreach (var node in printList)
            {
                if (node.row > level)
                {
                    Console.WriteLine();
                    ++level;
                    curColumn = 0;
                }
                if (level == 1)
                {
                    node.column = maxColumn / 2 + 1;
                }
                else
                {
                    int diff = (int)Math.Pow(2, levelCount - node.row);
                    if (node.childType == Child.LEFT)
                    {
                        diff = -diff;
                    }
                    node.column = node.parent.column + diff;
                }

                for (; curColumn < node.column-1; ++curColumn)
                {
                    Console.Write("  ");
                }
                Console.Write(string.Format("{0:00}",node.val));
                ++curColumn;
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Root.value = 2;
            tree.Root.left = new Tree.Node(7);
            tree.Root.right = new Tree.Node(5);
            tree.Root.left.left = new Tree.Node(2);
            tree.Root.left.right = new Tree.Node(6);
            tree.Root.left.right.left = new Tree.Node(5);
            tree.Root.left.right.right = new Tree.Node(11);
            tree.Root.right.right = new Tree.Node(9);
            tree.Root.right.right.left = new Tree.Node(4);

            //tree.Insert(7);
            //tree.Insert(5);
            //tree.Insert(3);
            //tree.Insert(6);
            //tree.Insert(8);
            //tree.Insert(11);
            //tree.Insert(4);

            tree.PreetyPrint();
        }
    }
}
