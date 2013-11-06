using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Node
    {
        public string value;
        public Node parent;
        public Node nextSibling;
        public Node firstChild;
    }

    public class Tree
    {
        public Node Parent { get; set; }

        public Tree()
        {
            Parent = new Node();
            Parent.parent = null;
            Contract.Ensures(Parent.parent == null);
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
            if (node == Parent)
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

        public void LevelOrder(Node start)
        {
            Console.Write(start.value + ", ");
            LevelOrderVisitChildren(start);
        }

        private void LevelOrderVisitChildren(Node start)
        {
            var child = start.firstChild;
            while (child != null)
            {
                Console.Write(child.value + ", ");
                child = child.nextSibling;
            }
            child = start.firstChild;
            while (child != null)
            {
                LevelOrderVisitChildren(child);
                child = child.nextSibling;
            }

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Parent.value = "F";
            var b = tree.InsertChild(tree.Parent, "B");
            var g = tree.InsertChild(tree.Parent, "G");
            var a = tree.InsertChild(b, "A");
            var d = tree.InsertChild(b, "D");
            var c = tree.InsertChild(d, "C");
            var e = tree.InsertChild(d, "E");
            var i = tree.InsertChild(g, "I");
            var h = tree.InsertChild(i, "H");


            //tree.PreOrder(tree.Parent);

            //tree.PostOrder(tree.Parent);

            tree.InOrder(tree.Parent);

            //tree.LevelOrder(tree.Parent);

        }
    }
}
