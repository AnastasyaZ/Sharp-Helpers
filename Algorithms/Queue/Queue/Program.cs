using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    public class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> NextItem { get; set; }
    }

    public class Queue<T>:IEnumerable<T>
    {
        /*
        public class QueueEnumerator : IEnumerator<T>
        {
            Queue<T> queue;
            QueueItem<T> currentItem;
            
            public QueueEnumerator(Queue<T> queue)
            {
                this.queue = queue;
                currentItem = null;
            }
            
            public T Current
            {
                get { return currentItem.Value; }
            }


            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (currentItem == null)
                    currentItem = queue.head;
                else
                    currentItem = currentItem.NextItem;
                return currentItem != null;
            }

            #region
            public void Dispose()
            {
            }

            public void Reset()
            {
            }
            #endregion
        }
        */

        QueueItem<T> head;
        QueueItem<T> tail;

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public void Enqueue(T value)
        {
            if (IsEmpty)
                head = tail = new QueueItem<T> { Value = value, NextItem = null };//CHECK
            else
            {
                var item = new QueueItem<T> { Value = value, NextItem = null };
                tail.NextItem = item;
                tail = item;
            }
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.NextItem;
            if (head == null)
                tail = null;
            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //return new QueueEnumerator(this);
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var queue=new Queue<string>();
            queue.Enqueue("1");
            queue.Enqueue("2");
            queue.Enqueue("3");

            foreach(var value in queue)
                Console.WriteLine(queue.Dequeue());
        }
    }
}
