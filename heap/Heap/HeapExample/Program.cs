using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class HeapExample
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 5,2,3,7,19,11,4 };
            Console.WriteLine("Before sorting: " + string.Join(",", arr));
            Heap<int> testHeap = new Heap<int>(arr);
            testHeap.HeapSort();
            Console.WriteLine("After sorting: " + testHeap.ToString());
        }
    }
}
