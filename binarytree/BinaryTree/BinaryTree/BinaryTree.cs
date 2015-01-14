using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : ICollection<T> where T : IComparable
    {
        protected Node root;

        protected class Node
        {
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public T Data { get; set; }
        }

        public void Add(T item)
        {
            var newNode = new Node() { Data = item }; 
            Node parent = null;
            Node current = root;
            while (current != null)
            {
                parent = current;
                if (item.CompareTo(current.Data) < 0)
                {                    
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }
            newNode.Parent = parent;
            if (parent == null)
            {
                root = newNode;
            }
            else
            {
                if (item.CompareTo(parent.Left.Data) < 0)
                {
                    parent.Left = newNode;
                }
                else
                {
                    parent.Right = newNode;
                }
            }
        }

        public void Clear()
        {
            root = null;
        }

        public bool Contains(T item)
        {
            Node current = root;
            while (current != null)
            {
                if (item.CompareTo(current.Data) < 0)
                {
                    current = current.Left;
                }
                else if (item.CompareTo(current.Data) > 0)
                {
                    current = current.Right;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        private Node Minimum(Node n)
        {
            while (n.Left != null)
            {
                n = n.Left;
            }
            return n;
        }

        private Node Maximum(Node n)
        {
            while (n.Right != null)
            {
                n = n.Right;
            }
            return n;
        }

        private Node Successor(Node n)
        {
            if (n.Right != null)
            {
                return Minimum(n.Right);
            }        
            Node parent = n.Parent;
            while (parent != null && n == parent.Right)
            {
                n = parent;
                parent = parent.Parent;
            }
            if (parent == root && n == parent.Right)
            {
                return null;
            }
            else
            {
                return parent;
            }
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
