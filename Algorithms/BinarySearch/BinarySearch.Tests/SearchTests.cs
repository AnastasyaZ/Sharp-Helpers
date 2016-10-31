using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinarySearch.Tests
{
    [TestClass]
    public class SearchTests
    {
        void Test(int[] arr, int element, int expectedIndex, int expectedBorder)
        {
            var result = Search.BinarySearch(arr, element);
            Assert.AreEqual(expectedIndex,result);

            var border = Search.BinSearchRightBorder(arr, element);
            Assert.AreEqual(expectedBorder, border);
        }
        
        [TestMethod]
        public void OrdinaryTest()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8, 9 };
            var elementToFind = 3;
            var index = 2;
            var border=4;
            Test(arr, elementToFind, index, border);
        }
        
        [TestMethod]
        public void OneMoreOrdinaryTest()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8 };
            var elementToFind = 3;
            var index = 2;
            var border = 4;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void OneElement()
        {
            var arr = new[] {1};
            var elementToFind = 1;
            var index = 0;
            var border = 1;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void TwoElements()
        {
            var arr = new[] { 0, 2};
            var elementToFind = 0;
            var index = 0;
            var border = 1;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void ThreeElements()
        {
            var arr = new[] { 0, 1, 8};
            var elementToFind = 8;
            var index = 2;
            var border = 3;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void FirstElement()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8, 9 };
            var elementToFind = 0;
            var index = 0;
            var border = 1;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void LastElement()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8, 8, 9 };
            var elementToFind = 9;
            var index = 7;
            var border = 8;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void NonexistantElement()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8, 8, 9 };
            var elementToFind = 4;
            var index = -1;
            var border = -1;
            Test(arr, elementToFind, index, border);
        }

        [TestMethod]
        public void NegativeElement()
        {
            var arr = new[] { 0, 1, 3, 3, 5, 8, 8, 9 };
            var elementToFind = -5;
            var index = -1;
            var border = -1;
            Test(arr, elementToFind, index, border);
        }
    }
}
