using System;
using MxRealityConsole;
using MxRealityConsole.Models;
using NUnit.Framework;
using System.Collections;
using MxRealityConsole.Repositories;
using MxRealityConsole.Interfaces;

namespace MxRealityUnitTestProject
{
    [TestFixture]
    public class StringManagerTests
    {

        public static IEnumerable InputParameterTestData
        {
            get
            {
                yield return new SortUsingDotNetFramework();
                yield return new SortUsingBubbleSort();
            }
        }

        [Test]
        [TestCaseSource("InputParameterTestData")]
        public void Test_Sort_When_Null_Argument_Throws_Expected_Exception(ISort sortingLogic)
        {
            var stringManager = new StringManager(sortingLogic);
            Assert.Throws<ArgumentNullException>(() => stringManager.Sort(null, SortOrder.Ascending)); 
        }

        [Test]
        [TestCaseSource("InputParameterTestData")]
        public void Test_Sort_When_Empty_Argument_Throws_Expected_Exception(ISort sortingLogic)
        {
            var emptyStrings = new string[][] {};
            var stringManager = new StringManager(sortingLogic);
            Assert.Throws<ArgumentException>(() => stringManager.Sort(emptyStrings, SortOrder.Ascending));
        }

        [Test]
        [TestCaseSource("InputParameterTestData")]
        public void Test_Sort_When_Valid_Strings_Then_Returns_Expected_Ascending_Unique_Sorted_Results(ISort sortingLogic)
        {
            string[] string1 = { "def", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var stringManager = new StringManager(sortingLogic);
            var sortedascendingUniqueStrings = stringManager.Sort(new string[][] { string1, string2}, SortOrder.Ascending).SortedUniqueStrings;

            var expectedResult = new string[] { "abc", "def", "ghi", "jkl" };

            Assert.AreEqual(expectedResult[0], sortedascendingUniqueStrings[0]);
            Assert.AreEqual(expectedResult[1], sortedascendingUniqueStrings[1]);
            Assert.AreEqual(expectedResult[2], sortedascendingUniqueStrings[2]);
            Assert.AreEqual(expectedResult[3], sortedascendingUniqueStrings[3]);
        }

        [Test]
        [TestCaseSource("InputParameterTestData")]
        public void Test_Sort_When_Valid_Strings_Then_Returns_Expected_Descending_Unique_Sorted_Results(ISort sortingLogic)
        {
            string[] string1 = { "def", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var stringManager = new StringManager(sortingLogic);
            var sortedDescendingUniqueStrings = stringManager.Sort(new string[][] { string1, string2 }, SortOrder.Descending).SortedUniqueStrings;

            var expectedResult = new string[] { "jkl", "ghi", "def", "abc" };

            Assert.AreEqual(expectedResult[0], sortedDescendingUniqueStrings[0]);
            Assert.AreEqual(expectedResult[1], sortedDescendingUniqueStrings[1]);
            Assert.AreEqual(expectedResult[2], sortedDescendingUniqueStrings[2]);
            Assert.AreEqual(expectedResult[3], sortedDescendingUniqueStrings[3]);
        }

        [Test]
        [TestCaseSource("InputParameterTestData")]
        public void Test_Sort_When_Valid_Duplicate_Strings_Then_Returns_Expected_Duplicate_Results(ISort sortingLogic)
        {
            string[] string1 = { "abc", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var stringManager = new StringManager(sortingLogic);
            var duplicateStrings = stringManager.Sort(new string[][] { string1, string2 }, SortOrder.Descending).DuplicateStrings;

            var expectedResult = new string[] { "abc"};

            Assert.AreEqual(expectedResult[0], duplicateStrings[0]);
        }

    }
}
