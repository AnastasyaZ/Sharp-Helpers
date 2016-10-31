using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    public class BynaryHeap<TKey, TValue> : IPriorityQueue<TKey, TValue>
        where TKey : IComparable
    {
        private readonly List<Tuple<TKey, TValue>> heap;

        public BynaryHeap()
        {
            heap = new List<Tuple<TKey, TValue>>();
            heap.Add(null);
        }

        public BynaryHeap(IEnumerable<Tuple<TKey, TValue>> heapItems)
            : this()
        {
            foreach (var item in heapItems)
            {
                heap.Add(item);
            }
        }

        ///<summary>
        ///Временная сложность O(logn)
        /// </summary>
        public void Add(TKey key, TValue value)
        {
            heap.Add(new Tuple<TKey, TValue>(key, value));
            HeapifyUp();
        }

        public Tuple<TKey, TValue> ExtractMin()
        {
            if (heap.Count == 1) throw new InvalidOperationException();
            var result = Tuple.Create(heap[1].Item1, heap[1].Item2);

            var movingItemIndex = heap.Count - 1;
            heap[1] = heap[movingItemIndex];
            heap.RemoveAt(movingItemIndex);

            HeapifyDown(1);

            return result;
        }

        private void HeapifyUp()
        {
            var itemIndex = heap.Count - 1;
            while (itemIndex > 1)
            {
                var parentIndex = itemIndex / 2;
                if (heap[parentIndex].Item1.CompareTo(heap[itemIndex].Item1) != 1) break;
                Swap(parentIndex, itemIndex);
                itemIndex = parentIndex;
            }
        }

        private void HeapifyDown(int itemIndex)//todo change
        {
            while (itemIndex < heap.Count-1)
            {
                var leftChildIndex = 2 * itemIndex;
                var rightChildIndex = 2 * itemIndex + 1;


                if (leftChildIndex == heap.Count) return;
                if (heap[leftChildIndex].Item1.CompareTo(heap[itemIndex].Item1) == -1)
                {
                    Swap(leftChildIndex, itemIndex);
                    itemIndex = leftChildIndex;
                }
                else
                {
                    if (rightChildIndex == heap.Count) return;
                    if( heap[rightChildIndex].Item1.CompareTo(heap[itemIndex].Item1) == -1)
                    {
                        Swap(rightChildIndex, itemIndex);
                        itemIndex = rightChildIndex;
                    }
                }
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            var tmp = heap[firstIndex];
            heap[firstIndex] = heap[secondIndex];
            heap[secondIndex] = tmp;
        }

        public override string ToString()
        {
            return String.Join(" ", heap);
        }
    }
}

