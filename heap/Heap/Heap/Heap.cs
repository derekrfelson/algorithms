using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    public class Heap<T> where T : IComparable
    {
        private T[] _values;
        private int _heapSize;

        public Heap(T[] values)
        {
            _values = values;
        }

        /**
         * Turns the heap into a sorted array.
         * 
         * The max element in the heap is always at position 1.
         * Repeatedly swaps it with the element at the end of the heap,
         * then calls heapify on the remainder of the heap.
         * 
         * Runs in time O(nlgn) since BuildHeap takes O(n) and each of the
         * n - 1 calls to Heapify takes time O(lgn).
         */
        public void HeapSort()
        {
            BuildHeap();
            for (int i = Length; i >= 2; --i)
            {
                Swap(1, i);
                --_heapSize;
                Heapify(1);
            }
        }

        public int Length
        {
            get 
            {
                return _values.Length;
            }
        }

        /** Returns the heap element at the given index (starting at 1)
         * 
         * Index of element i's parent = floor(i/2)
         * Index of element i's left child = 2i
         * Index of element i's right child = 2i+1
         * 
         * Heap indexing must start at 1 or these formula's won't work
         * (e.g. left child of element 0 is 2*0 = 0)
         */

        private T this[int i]
        {
            get { return _values[i - 1]; }
            set { _values[i - 1] = value; }
        }

        private int Left(int i)
        {
            return i * 2;
        }

        private int Right(int i)
        {
            return i * 2 + 1;
        }

        private int Parent(int i)
        {
            return (int)Math.Floor((decimal)i / 2);
        }

        /** 
         * Makes the binary tree rooted at i a heap by letting the value
         * at node i "float down" until it's at the right place.
         * 
         * Precondition: the binary trees rooted at Left(i) and Right(i)
         * are heaps, but that this[i] may be smaller than its children,
         * thus violating the heap property.
         * 
         * Recall that the heap property says that for every node i other
         * than the root, this[Parent(i)] >= this[i].
         * 
         * Postcondition: the binary tree rooted at i is a heap.
         * 
         * Runs in lg(n) time.
         */
        private void Heapify(int i)
        {
            int left = Left(i);
            int right = Right(i);
            int largest = i;
            if (left <= _heapSize && this[left].CompareTo(this[i]) > 0)
            {
                largest = left;
            }
            if (right <= _heapSize && this[right].CompareTo(this[largest]) > 0)
            {
                largest = right;
            }
            if (largest != i)
            {
                Swap(largest, i);
                Heapify(largest);
            }
        }

        private void Swap(int lhs, int rhs)
        {
            T tempV = this[lhs];
            this[lhs] = this[rhs];
            this[rhs] = tempV;
        }

        /**
         * Turns an array into a heap.
         * 
         * Since the elements in the latter half of the array are all leaf
         * nodes, they're automatically 1-element heaps, so we can skip them.
         * This method goes through the remaining elements in a bottom-up manner
         * and runs Heapify on each. The order in which they are processed
         * guarantees that the children of each node are heaps before Heapify
         * is run on it.
         * 
         * Looks like it runs in O(nlgn) time, but can be proven to actually
         * run in O(n).
         */
        private void BuildHeap()
        {
            _heapSize = Length;
            for (int i = Length / 2; i > 0; --i)
            {
                Heapify(i);
            }
        }        

        public override string ToString()
        {
            return "[" + string.Join(",", _values) + "]";            
        }
    }
}
