using System;

namespace BinaryHeap
{
    public interface IPriorityQueue<TKey,TValue>
    {
        void Add(TKey key, TValue value);
        Tuple<TKey, TValue> ExtractMin();

        /*void Delete(TKey key);
        void Update(TKey key, TValue newValue);
        bool TryGetValue(TKey key, out TValue value);*/
    }
}