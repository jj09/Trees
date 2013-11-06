using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Trees.Tests
{
    // test cases are from: http://en.wikipedia.org/wiki/Tree_traversal

    public class Traversal
    {
        private Tree GenerateTestTree()
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
            return tree;
        }

        [Fact]
        public void FactPreOrder()
        {
            using (var sw = new StringWriter())
            {
                // arrange
                Console.SetOut(sw);
                string expected = "F, B, A, D, C, E, G, I, H, ";
                Tree t = GenerateTestTree();

                // act
                t.PreOrder(t.Parent);

                // assert
                Assert.Equal<string>(expected, sw.ToString());
            }
        }

        [Fact]
        public void FactPostOrder()
        {
            using (var sw = new StringWriter())
            {
                // arrange
                Console.SetOut(sw);
                string expected = "A, C, E, D, B, H, I, G, F, ";
                Tree t = GenerateTestTree();

                // act
                t.PostOrder(t.Parent);

                // assert
                Assert.Equal<string>(expected, sw.ToString());
            }
        }

        [Fact]
        public void FactInOrder()
        {
            using (var sw = new StringWriter())
            {
                // arrange
                Console.SetOut(sw);
                string expected = "A, B, C, D, E, F, G, I, H, ";
                Tree t = GenerateTestTree();

                // act
                t.InOrder(t.Parent);

                // assert
                Assert.Equal<string>(expected, sw.ToString());
            }
        }

        [Fact]
        public void FactLevelOrder()
        {
            using (var sw = new StringWriter())
            {
                // arrange
                Console.SetOut(sw);
                string expected = "F, B, G, A, D, I, C, E, H, ";
                Tree t = GenerateTestTree();

                // act
                t.LevelOrder(t.Parent);

                // assert
                Assert.Equal<string>(expected, sw.ToString());
            }
        }
    }
}
