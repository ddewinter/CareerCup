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