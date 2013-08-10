using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace MirrorTree
{
    public class Problem
    {
        public Node MirrorTree(Node root)
        {
            if (root == null)
            {
                return null;
            }

            var tmp = root.Left;
            root.Left = root.Right;
            root.Right = tmp;

            return root;
        }
    }

    [TestFixture]
    public class MirrorTreeTests
    {
        [Test]
        public void Null_root_returns_null()
        {
            Node n = null;

            var p = new Problem();
            var result = p.MirrorTree(n);

            result.Should().BeNull();
        }

        [Test]
        public void Root_with_no_children_returns_root()
        {
            Node n = new Node("A");

            var p = new Problem();
            var result = p.MirrorTree(n);

            result.Name.Should().Be("A");
        }

        [Test]
        public void Root_with_children_returns_flipped_children()
        {
            Node n = new Node("A");
            n.Left = new Node("B");
            n.Right = new Node("C");

            var p = new Problem();
            var result = p.MirrorTree(n);

            result.Name.Should().Be("A");
            result.Left.Name.Should().Be("C");
            result.Right.Name.Should().Be("B");
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