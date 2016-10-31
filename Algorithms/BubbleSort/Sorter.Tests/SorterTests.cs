using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BubbleSort;

namespace Sorter.Tests
{
    [TestClass]
    public class SorterTests
    {

        void Test<T>(T[] array, T[] expArray)
        where T:IComparable
        {
            Sorter<T>.Sort(array);
            Assert.AreEqual(expArray.Length, array.Length);
            for (var i = 0; i < array.Length; i++)
                Assert.AreEqual(array[i], expArray[i]);
        }

        [TestMethod]
        public void IntArray()
        {
            var arr1 = new[] { 5, 8, 7, 6, 1, 4, 3 };
            var arr2 = new[] { 1, 3, 4, 5, 6, 7, 8 };

            Test<int>(arr1, arr2);
        }

        [TestMethod]
        public void StringArray()
        {
            var arr1 = new[] { "D","A","C","B"};
            var arr2 = new[] { "A","B","C","D" };

            Test<string>(arr1, arr2);   
        }
    }
}
