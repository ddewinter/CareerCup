using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public class BreadthFirstSearchOutput
    {
        public string GetPrintString(Node treeRoot)
        {
            return "null";
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

            var subjectUnderTest = new BreadthFirstSearchOutput();

            // Act
            var str = subjectUnderTest.GetPrintString(treeRoot);

            // Assert
            str.Should().Be("A\nB,C\nD,E,F,G\n");
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
    }
}
