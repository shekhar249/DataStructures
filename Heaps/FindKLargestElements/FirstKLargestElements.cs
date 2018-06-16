using System;

namespace DataStructure.Heaps
{
    class FirstKLargestElements
    {
        static MinHeap heap = new MinHeap(5);
        static int[] randomStream = new int[] { 2,5,8,23,90,111,2,78,34,89,45,67,1,78,456,34,4,1,2,75,3,0,2,5,78,234,12,999,45,23,89,33,88,77,55,44,11,9,0,90,86};
        public static void Main(string[] args)
        {
            foreach (var item in randomStream)
            {
                ProcessStreamData(item);
            }
        }
        public static void ProcessStreamData(int n)
        {
            if (!heap.IsFull())
            {
                heap.Insert(n);
            }
            else
            {
                if (heap.Peek() < n)
                    heap.ReplaceHighestPriority(n);
            }

            Console.Clear();
            Console.Write("n={0}",n);
            Console.WriteLine();
            heap.Print();
            Console.ReadKey();
        }
    }
}
