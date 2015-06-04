using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestSorting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InsertNumBaseTest()
        {
            int[] testArr = {1, 3, 4, 5, 2, 6, 7};
            int[] correct = {1, 2, 3, 4, 5, 6, 7};
            Sorting.MainClass.InsertNum(testArr, 4, 1);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void SwapNumBaseTest()
        {
            int[] testArr = {1, 6, 3, 4, 5, 2, 7};
            int[] correct = {1, 2, 3, 4, 5, 6, 7};
            Sorting.MainClass.SwapNums(testArr, 1, 5);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void partitionBaseTest()
        {
            int[] testArr = {3, 9, 5, 2, -1};
            int[] correct = {2, -1, 3, 5, 9};
            int retVal = Sorting.MainClass.Partition(testArr, 0, 5);
            Sorting.MainClass.PrintArray(testArr);
            CollectionAssert.AreEqual(correct, testArr);
            Assert.AreEqual(2, retVal);
        }





        [TestMethod]
        public void SelectionSortBaseTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.SelectionSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void InsertionSortBaseTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.InsertionSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }
        
        [TestMethod]
        public void BubbleSortBaseTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.BubbleSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void MergeSortBaseTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.MergeSort(testArr);
            Sorting.MainClass.PrintArray(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void MergeSortOddTest()
        {
            int[] testArr = {67, 110, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67, 110};
            Sorting.MainClass.MergeSort(testArr);
            Sorting.MainClass.PrintArray(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void QuickSortBaseTest()
        {
            int[] testArr = {3, 9, 5, 2, -1};
            int[] correct = {-1, 2, 3, 5, 9};
            Sorting.MainClass.QuickSort(testArr);
            Sorting.MainClass.PrintArray(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void QuickSortBaseTest2()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.QuickSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void QuickSortOddTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5, -23, 12, 15, 222226, -100000};
            int[] correct = {-100000, -23, -1, 2, 3, 3, 4, 5, 7, 9, 10, 12, 15, 67, 222226};
            Sorting.MainClass.QuickSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }
    }
}
