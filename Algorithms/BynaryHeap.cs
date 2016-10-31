using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEST
{
    public interface IPriorityQueue<TKey>
    {
        void Add(TKey key, double value);
        void Delete(TKey key);
        void Update(TKey key, double newValue);
        Tuple<TKey, double> ExtractMin();
        bool TryGetValue(TKey key, out double value);
    }

    /// <summary>
    /// В этой задаче для простоты в куче хранятся не пары, а только сами приоритеты
    /// </summary>
    /// <returns></returns>
    public class BynaryHeap
    {
        private readonly List<int> heap;

        public BynaryHeap()
        {
            heap = new List<int>();
        }
        
        public BynaryHeap(IEnumerable<int> heapItems)
        {
            heap=new List<int>(heapItems);
        }

        public void HeapifyUp(int itemIndex)
        {
            while (itemIndex > 0)
            {
                var parentIndex = itemIndex / 2;
                if (heap[parentIndex] <= heap[itemIndex]) break;
                Swap(heap, parentIndex, itemIndex);
                itemIndex = parentIndex;
            }
        }

        public void HeapifyDown(int itemIndex)
        {
            while (itemIndex < heap.Count)
            {
                var leftChildIndex = 2 * itemIndex;
                var rightChildIndex = 2 * itemIndex;
                if (heap[leftChildIndex] >= heap[itemIndex] && heap[rightChildIndex] >= heap[itemIndex]) break;
                Swap(heap, leftChildIndex, itemIndex);
                itemIndex = leftChildIndex;
            }
        }

        private static void Swap<T>(List<T> list, int firstIndex, int secondIndex)
        {
            var tmp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = tmp;
        }
    }

    class Program
    {
        public static void Main()
        {

        }
    }
}
