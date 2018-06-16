using System;

namespace DataStructure.Heaps
{
    class MinHeap
    {
        readonly int MAX_SIZE = 40;
        int[] array;
        int count = 0;
        public MinHeap(int size)
        {
            MAX_SIZE = size;
            array = new int[MAX_SIZE];
        }
        public void Insert(int n)
        {
            if (IsFull())
            {
                throw new Exception("Heap is Full");
            }
            array[count] = n;
            siftUp(count);
            count++;
        }
        public int Remove()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is Empty");
            }

            int highestPriorityItem = array[0];
            int lastItem = array[count - 1];
            array[0] = lastItem;
            count--;
            siftDown(0);
            return highestPriorityItem;
        }
        public void ReplaceHighestPriority(int n)
        {
            array[0] = n;
            siftDown(0);
        }

        public int Peek()
        {
            return array[0];
        }
        public bool IsEmpty()
        {
            return count <= 0;
        }
        public bool IsFull()
        {
            return count == MAX_SIZE;
        }
        int getLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }
        int getRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        int getParentIndex(int index)
        {
            return (index - 1) / 2;
        }
        void siftDown(int index)
        {
            if (index >= count)
                return;
            int leftChildIndex = getLeftChildIndex(index);
            int rightChildIndex = getRightChildIndex(index);
            if (leftChildIndex < count && rightChildIndex < count)
            {
                if (array[index] > array[leftChildIndex] || array[index] > array[rightChildIndex])
                {
                    if (array[leftChildIndex] > array[rightChildIndex])
                    {
                        swap(index, rightChildIndex);
                        siftDown(rightChildIndex);
                    }
                    else
                    {
                        swap(index, leftChildIndex);
                        siftDown(leftChildIndex);
                    }
                }
            }
            else if (leftChildIndex < count)
            {
                if (array[index] > array[leftChildIndex])
                {
                    swap(index, leftChildIndex);
                    siftDown(leftChildIndex);
                }
            }
            else if (rightChildIndex < count)
            {
                if (array[index] > array[rightChildIndex])
                {
                    swap(index, rightChildIndex);
                    siftDown(rightChildIndex);
                }
            }


        }
        void siftUp(int index)
        {
            if (index <= 0)
                return;
            int parentIndex = getParentIndex(index);
            if (array[parentIndex] > array[index])
            {
                swap(index, parentIndex);
            }
            siftUp(parentIndex);
        }

        void swap(int index1, int index2)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        public void Print()
        {
            foreach (var n in array)
            {
                if (n != 0) Console.Write("{0} ", n);
            }
        }

    }
}
