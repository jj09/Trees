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
            throw new NotImplementedException();
        }

        public void LevelOrder(Node start)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Parent.value = "F";
            var first = tree.InsertChild(tree.Parent, "B");
            var second = tree.InsertChild(tree.Parent, "G");
            var third = tree.InsertChild(first, "A");
            var four = tree.InsertChild(first, "D");
            var five = tree.InsertChild(four, "C");
            var six = tree.InsertChild(four, "E");
            var seven = tree.InsertChild(second, "I");
            var eight = tree.InsertChild(seven, "H");


            //tree.PreOrder(tree.Parent);

            tree.PostOrder(tree.Parent);

        }
    }
}
