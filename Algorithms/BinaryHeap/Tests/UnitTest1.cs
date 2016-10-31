using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BinaryHeap;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var items = new[] {3, 5, 4, 7}
                .Select(x => Tuple.Create(x, x));

            var heap = new BynaryHeap<int,int>(items);

            heap.Add(6,6);
            heap.Add(1,1);
            heap.Add(2,2);

            var rasultItems = Enumerable.Range(1, 7);

            foreach (var item in rasultItems)
            {
                var i = heap.ExtractMin();
                Assert.AreEqual(i.Item1,item);
            }

            try
            {
                heap.ExtractMin();
            }
            catch (InvalidOperationException exception)
            {
                return;
            }
            Assert.Fail("No exception was thrown.");
        }
    }
}
