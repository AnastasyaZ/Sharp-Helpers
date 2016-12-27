using System;
using NUnit.Framework;

namespace TestsForTest
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CriticalAttribute : CategoryAttribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyOwnAttribute : CategoryAttribute { }

    [TestFixture]
    public class NUnitAttributes
    {
        /*Identifies methods to be called once prior to any child tests.*/
        [OneTimeSetUp]
        public void Init()
        { }

        [Test, Critical, MyOwn, Category("second")]
        public void CategoryTest()
        { }


        [Test, Combinatorial]
        public void CombinatorialTest([Values(1, 2, 3)] int x, [Values("a", "b")] string s)
        {
            //equals to
            //CombinatorialTest(1, "A")
            //CombinatorialTest(1, "B")
            //CombinatorialTest(2, "A")
            //CombinatorialTest(2, "B")
            //CombinatorialTest(3, "A")
            //CombinatorialTest(3, "B")
        }

        /*The Description attribute is used to apply descriptive text to a Test, TestFixture or Assembly. The text appears in the XML output file and is shown in the Test Properties dialog.*/
        //for assembly before namespace:  [assembly: Description("Assembly description here")]
        [Test, Description("Test description here")]
        public void DescriptionTest()
        { }

        /*The Explicit attribute causes a test or test fixture to be skipped unless it is explicitly selected for running. 
         Can be used with Test and TestFixture*/
        [Test, Explicit]
        public void ShoudBeRunExplicit()
        { }

        [TestFixture, Explicit]
        public class ExplicitTests
        { }

        /*The Until named parameter allows you to ignore a test for a specific period of time, after which the test will run normally.
         *Can be used with Test and TestFixture*/
        [Test]
        [Ignore("Waiting for Joe to fix his bugs", Until = "2014-07-31 12:00:00Z")]
        public void IgnoredTest()
        { }

        /*Specifies the maximum time in milliseconds for a test case to succeed.*/
        [Test]
        //[Maxtime(2000)]
        public void TimedTest()
        { }

        /*Will be run in order A,B,C*/
        [Test, Order(1)]
        public void TestA() { }
        [Test, Order(2)]
        public void TestB() { }
        [Test]
        public void TestC() { }


        [Test, Pairwise]
        public void PairwiseTest(
            [Values("a", "b", "c")] string a,
            [Values("+", "-", "*")] string b,
            [Values("x", "y", "z")] string c)
        { }


        [Test]
        public void TestWithRandomSecondArg(
        [Values(1, 2, 3)] int first,
        [Random(-1.0, 1.0, 5)] double second)
        { }


        [TestCase(12, 3, 4)]
        [TestCase(12, 2, 6)]
        [TestCase(12, 4, 3)]
        public void DivideTest1(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        [TestCase(12, 3, ExpectedResult = 4)]
        [TestCase(12, 2, ExpectedResult = 6)]
        [TestCase(12, 4, ExpectedResult = 3)]
        public int DivideTest2(int n, int d)
        {
            return (n / d);
        }

        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest3(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static readonly object[] DivideCases = {
        new object[] { 12, 3, 4 },
        new object[] { 12, 2, 6 },
        new object[] { 12, 4, 3 }
        };

        /*If the assumptions are violated for all test cases, then the Theory itself is marked as a failure.
        If any Assertion fails, the Theory itself fails.
        If at least some cases pass the stated assumptions, and there are no assertion failures or exceptions, then the Theory passes.*/
        [DatapointSource]
        public double[] values = { 0.0, 1.0, -1.0, 42.0 };

        [Theory]
        public void SquareRootDefinition(double num)
        {
            Assume.That(num >= 0.0);

            var sqrt = Math.Sqrt(num);

            Assert.That(sqrt >= 0.0);
            Assert.That(sqrt * sqrt, Is.EqualTo(num).Within(0.000001));
        }

    }
}