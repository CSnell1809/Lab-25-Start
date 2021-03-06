﻿/* BinaryTreeNode.cs
 * Author: Rod Howell */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KansasStateUniversity.TreeViewer2;

namespace Ksu.Cis300.PriorityQueueLibrary
{
    /// <summary>
    /// An immutable generic binary tree node that can draw itself.
    /// </summary>
    /// <typeparam name="T">The type of the elements stored in the tree.</typeparam>
    public partial class LeftistTree<T> : ITree
    {
        /// <summary>
        /// The length of the shorttest path to get to null
        /// </summary>
        private int _nullPathLength;

        /// <summary>
        /// Gets the data stored in this node.
        /// </summary>
        public T Data { get; }

        /// <summary>
        /// Gets this node's left child.
        /// </summary>
        public LeftistTree<T> LeftChild { get; }

        /// <summary>
        /// Gets this node's right child.
        /// </summary>
        public LeftistTree<T> RightChild { get; }

        /// <summary>
        /// Constructs a BinaryTreeNode with the given data, left child, and right child.
        /// </summary>
        /// <param name="data">The data stored in the node.</param>
        /// <param name="left">The left child.</param>
        /// <param name="right">The right child.</param>
        public LeftistTree(T data, LeftistTree<T> left, LeftistTree<T> right)
        {
            Data = data;
            int l = NullPathLength(left);
            int r = NullPathLength(right);
            if (l < r)
            {
                RightChild = left;
                LeftChild = right;
                _nullPathLength = l + 1;
            }
            else
            {
                LeftChild = left;
                RightChild = right;
                _nullPathLength = r + 1;
            }
        }

        /// <summary>
        /// Finds the length of shortest path top a null for a tree
        /// </summary>
        /// <param name="t">tree path is being looked in</param>
        /// <returns>length of shortest path to null</returns>
        public static int NullPathLength(LeftistTree<T> t)
        {
            if (t == null)
            {
                return 0;
            }
            return t._nullPathLength;
        }
    }
}
