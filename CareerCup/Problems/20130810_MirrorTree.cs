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

            var bfs = new Queue<Node>();
            bfs.Enqueue(root);

            while (bfs.Count > 0)
            {
                var n = bfs.Dequeue();

                if (n.Left != null)
                {
                    bfs.Enqueue(n.Left);
                }

                if (n.Right != null)
                {
                    bfs.Enqueue(n.Right);
                }

                var tmp = n.Left;
                n.Left = n.Right;
                n.Right = tmp;
            }
            
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

        [Test]
        public void Root_with_two_levels_returns_flipped_tree()
        {
            Node n = new Node("R")
            {
                Left = new Node("S")
                {
                    Left = new Node("T"),
                    Right = new Node("U"),
                }
            };

            var p = new Problem();
            var result = p.MirrorTree(n);

            result.Name.Should().Be("R");
            result.Left.Should().BeNull();
            result.Right.Name.Should().Be("S");
            result.Right.Left.Name.Should().Be("U");
            result.Right.Right.Name.Should().Be("T");
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