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
            public string value;
            public Node left;
            public Node right;

            public Node(string value)
            {
                this.value = value;
            }
        }

        public class PrintNode
        {
            public string val;
            public int row;
            public int column;
            public int childType;
            public PrintNode parent;
        }

        public Node Parent { get; set; }

        public Tree()
        {
            Parent = new Node(null);
        }        

        public void PreetyPrint()
        {
            var printList = new List<PrintNode>();
            var queue = new Queue<Node>();
            var parentNode = new PrintNode { val = Parent.value, row = 1, childType = 0 };
            queue.Enqueue(Parent);
            printList.Add(parentNode);
            while (queue.Count > 0)
            {
                var cur = queue.Dequeue();                
                if (cur.left != null)
                {
                    var leftChild = new PrintNode { val = cur.left.value, childType = 1, parent = printList.First(x => x.val == cur.value) };
                    leftChild.row = leftChild.parent.row + 1;
                    queue.Enqueue(cur.left);
                    printList.Add(leftChild);
                }
                if (cur.right != null)
                {
                    var rightChild = new PrintNode { val = cur.right.value, childType = 2, parent = printList.First(x => x.val == cur.value) };
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
                    if (node.childType == 1)
                    {
                        diff = -diff;
                    }
                    node.column = node.parent.column + diff;
                }

                for (; curColumn < node.column-1; ++curColumn)
                {
                    Console.Write("*");
                }
                Console.Write(node.val);
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
            tree.Parent.value = "2";
            tree.Parent.left = new Tree.Node("7");
            tree.Parent.right = new Tree.Node("5");
            tree.Parent.left.left = new Tree.Node("2");
            tree.Parent.left.right = new Tree.Node("6");
            tree.Parent.left.right.left = new Tree.Node("5");
            tree.Parent.left.right.right = new Tree.Node("1");
            tree.Parent.right.right = new Tree.Node("9");
            tree.Parent.right.right.left = new Tree.Node("4");

            tree.PreetyPrint();
        }
    }
}
