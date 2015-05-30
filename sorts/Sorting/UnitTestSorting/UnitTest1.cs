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
            CollectionAssert.AreEqual(correct, testArr);
        }

        [TestMethod]
        public void QuickSortBaseTest()
        {
            int[] testArr = {67, -1, 10, 4, 7, 2, 9, 3, 3, 5};
            int[] correct = {-1, 2, 3, 3, 4, 5, 7, 9, 10, 67};
            Sorting.MainClass.QuickSort(testArr);
            CollectionAssert.AreEqual(correct, testArr);
        }
    }
}
