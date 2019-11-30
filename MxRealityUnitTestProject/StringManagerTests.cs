using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MxRealityConsole;
using MxRealityConsole.Models;

namespace MxRealityUnitTestProject
{
    [TestClass]
    public class StringManagerTests
    {
        [TestMethod]
        public void Test_Sort_When_Null_Argument_Throws_Expected_Exception()
        {
            Assert.ThrowsException<ArgumentNullException>(() => StringManager.Sort(null, SortOrder.Ascending)); 
        }

        [TestMethod]
        public void Test_Sort_When_Empty_Argument_Throws_Expected_Exception()
        {
            var emptyStrings = new string[][] {};
            Assert.ThrowsException<ArgumentException>(() => StringManager.Sort(emptyStrings, SortOrder.Ascending));
        }

        [TestMethod]
        public void Test_Sort_When_Valid_Strings_Then_Returns_Expected_Ascending_Unique_Sorted_Results()
        {
            string[] string1 = { "def", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var sortedascendingUniqueStrings = StringManager.Sort(new string[][] { string1, string2}, SortOrder.Ascending).SortedUniqueStrings;

            var expectedResult = new string[] { "abc", "def", "ghi", "jkl" };

            Assert.AreEqual(expectedResult[0], sortedascendingUniqueStrings[0]);
            Assert.AreEqual(expectedResult[1], sortedascendingUniqueStrings[1]);
            Assert.AreEqual(expectedResult[2], sortedascendingUniqueStrings[2]);
            Assert.AreEqual(expectedResult[3], sortedascendingUniqueStrings[3]);
        }

        [TestMethod]
        public void Test_Sort_When_Valid_Strings_Then_Returns_Expected_Descending_Unique_Sorted_Results()
        {
            string[] string1 = { "def", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var sortedDescendingUniqueStrings = StringManager.Sort(new string[][] { string1, string2 }, SortOrder.Descending).SortedUniqueStrings;

            var expectedResult = new string[] { "jkl", "ghi", "def", "abc" };

            Assert.AreEqual(expectedResult[0], sortedDescendingUniqueStrings[0]);
            Assert.AreEqual(expectedResult[1], sortedDescendingUniqueStrings[1]);
            Assert.AreEqual(expectedResult[2], sortedDescendingUniqueStrings[2]);
            Assert.AreEqual(expectedResult[3], sortedDescendingUniqueStrings[3]);
        }

        [TestMethod]
        public void Test_Sort_When_Valid_Duplicate_Strings_Then_Returns_Expected_Duplicate_Results()
        {
            string[] string1 = { "abc", "jkl" };
            string[] string2 = { "abc", "ghi" };
            var duplicateStrings = StringManager.Sort(new string[][] { string1, string2 }, SortOrder.Descending).DuplicateStrings;

            var expectedResult = new string[] { "abc"};

            Assert.AreEqual(expectedResult[0], duplicateStrings[0]);
        }

    }
}
