using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree
    {
        #region Tree Logic

        public class Node
        {
            public string value;
            public Node parent;
            public Node nextSibling;
            public Node firstChild;
        }

        public Node Root { get; set; }

        public Tree()
        {
            Root = new Node();
            Root.parent = null;
            Contract.Ensures(Root.parent == null);
        }

        public Node InsertChild(Node parent, string value)
        {
            var newNode = new Node { value = value, parent = parent };
            if (parent.firstChild == null)
            {
                parent.firstChild = newNode;
            }
            else
            {
                var child = parent.firstChild;
                while (child.nextSibling != null)
                {
                    child = child.nextSibling;
                }
                child.nextSibling = newNode;
            }
            return newNode;
        }

        public void Remove(Node node)
        {
            if (node == Root)
            {
                throw new NotImplementedException();
            }

            if (node == node.parent.firstChild)
            {
                node.parent.firstChild = node.nextSibling;
            }
            else
            {
                var n = node.parent.firstChild;
                while (n.nextSibling != node)
                {
                    n = n.nextSibling;
                }
                n.nextSibling = node.nextSibling;
            }
        }

        #endregion Tree Logic

        #region Depth-first

        public void PreOrder(Node start)
        {
            Console.Write(start.value + ", ");
            var child = start.firstChild;
            while (child != null)
            {
                PreOrder(child);
                child = child.nextSibling;
            }

        }

        public void PostOrder(Node start)
        {
            var child = start.firstChild;
            while (child != null)
            {
                PostOrder(child);
                child = child.nextSibling;
            }
            Console.Write(start.value + ", ");
        }

        public void InOrder(Node start)
        {
            var child = start.firstChild;
            if (child != null)
            {
                while (child.nextSibling != null)
                {
                    InOrder(child);
                    child = child.nextSibling;
                }
            }
            Console.Write(start.value + ", ");
            if (child != null)
            {
                InOrder(child);
            }
        }

        #endregion Depth-first

        #region Breadth-first

        public void LevelOrder(Node start)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.Write(node.value + ", ");
                var child = node.firstChild;
                while (child != null)
                {
                    queue.Enqueue(child);
                    child = child.nextSibling;
                }
            }
        }

        #endregion Breadth-first
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Root.value = "F";
            var b = tree.InsertChild(tree.Root, "B");
            var g = tree.InsertChild(tree.Root, "G");
            var a = tree.InsertChild(b, "A");
            var d = tree.InsertChild(b, "D");
            var c = tree.InsertChild(d, "C");
            var e = tree.InsertChild(d, "E");
            var i = tree.InsertChild(g, "I");
            var h = tree.InsertChild(i, "H");


            Console.Write("Pre-Order:\t");
            tree.PreOrder(tree.Root);
            Console.WriteLine();

            Console.Write("Post-Order:\t");
            tree.PostOrder(tree.Root);
            Console.WriteLine();

            Console.Write("In-Order:\t");
            tree.InOrder(tree.Root);
            Console.WriteLine();

            Console.Write("Level-Order:\t");
            tree.LevelOrder(tree.Root);
            Console.WriteLine();
        }
    }
}
