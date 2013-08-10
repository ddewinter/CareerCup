using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearchOutput
{
    public class Problem
    {
        public string GetPrintString(Node treeRoot)
        {
            if (treeRoot == null)
            {
                throw new ArgumentNullException("treeRoot");
            }

            var nodes = new Queue<Node>();
            nodes.Enqueue(treeRoot);
            
            StringBuilder print = new StringBuilder();

            int currentLevel = 0;
            while (nodes.Count != 0)
            {
                var n = nodes.Dequeue();

                if (n.Level != 0)
                {
                    print.Append(currentLevel != n.Level ? '\n' : ',');
                }

                print.Append(n.Name);

                currentLevel = n.Level;

                if (n.Left != null)
                {
                    nodes.Enqueue(n.Left);
                    n.Left.Level = currentLevel + 1;
                }

                if (n.Right != null)
                {
                    nodes.Enqueue(n.Right);
                    n.Right.Level = currentLevel + 1;
                }
            }

            print.Append('\n');

            return print.ToString();
        }
    }

    [TestFixture]
    public class BreadthFirstSearchOutputTests
    {
        [Test]
        public void Simple_three_level_tree_outputs_correct_string()
        {
            // Arrange
            var treeRoot = new Node("A");
            var left = treeRoot.Left = new Node("B");
            var right = treeRoot.Right = new Node("C");
            
            left.Left = new Node("D");
            left.Right = new Node("E");

            right.Left = new Node("F");
            right.Right = new Node("G");

            var subjectUnderTest = new Problem();

            // Act
            var str = subjectUnderTest.GetPrintString(treeRoot);

            // Assert
            str.Should().Be("A\nB,C\nD,E,F,G\n");
        }

        [Test]
        public void Root_should_not_be_null()
        {
            // Arrange
            var subjectUnderTest = new Problem();

            // Act
            Action a = () => subjectUnderTest.GetPrintString(null);

            // Assert
            a.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("treeRoot");
        }
    }

    public class Node
    {
        public Node(string name)
        {
            this.Name = name;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Name { get; private set; }
        public int Level { get; set; }
    }
}
