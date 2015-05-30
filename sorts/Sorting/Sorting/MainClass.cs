/*
 * Implementation of:
 * - Selection Sort
 * - Insertion Sort
 * - Bubble Sort
 * - Merge Sort
 * - Quick Sort
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    /// <summary>
    /// Class to generate and hold sets of test data
    /// </summary>
    public class TestData
    {
        private int[] data;
        private Random rand;
        private long size;

        /// <summary>
        /// Constructs a new TestData with the given size.
        /// </summary>
        /// <param name="size"></param>
        public TestData(long size)
        {
            rand = new Random();
            data = new int[size];
            this.size = size;
            generateData();
        }

        /// <summary>
        /// Generates new test data
        /// </summary>
        public void generateData()
        {
            for (int i = 0; i < size; i++)
            {
                data[i] = rand.Next(Int16.MaxValue);
            }
        }

        /// <summary>
        /// Gets the test data
        /// </summary>
        /// <returns></returns>
        public int[] getData()
        {
            return data;
        }

        public int[] getCopyOfData(long size)
        {
            if(size < 0)
            {
                System.Console.WriteLine("Cannot get negative data.");
                return new int[0];
            }
            int[] ret = new int[size];
            for (int i = 0; i < size; i++)
            {
                ret[i] = data[i];
            }
            return ret;
        }
    }

    public class MainClass
    {
        //Delegate to use for whichever sort I want to run
        public delegate void Sorter(int[] arr);

        /// <summary>
        /// Main entry point of this solution
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Main(String[] args)
        {
            //Use some common powers of 2
            int[] sizes = {1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, //2^10 - 2^19
                           1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, //2^20 - 2^29
                           107374182}; //2^30
            //Generate all the needed data first
            TestData data = new TestData(sizes[sizes.Length-1]); 

            //Configure which sorting methods to test
            List<Sorter> testSuite = new List<Sorter>();
            //testSuite.Add(QuickSort);
            testSuite.Add(MergeSort);
            //testSuite.Add(BubbleSort);
            //testSuite.Add(InsertionSort);
            //testSuite.Add(SelectionSort);

            foreach (Sorter sort in testSuite)
            {
                PerformSort(data, sort, sizes);
            }

            // TODO:
            // Merge Sort 
            // Quick Sort 

            // Wait for user input to close the command shell.
            System.Console.Read();
            return 0;
        }

        public static void PerformSort(TestData data, Sorter sort, int[] sizes)
        {
            if(data == null)
            {
                System.Console.WriteLine("You must instantiate the test data before attempting to sort it!");
                return;
            }
            if(sort == null)
            {
                System.Console.WriteLine("You must instantiate the sorter before attempting to use it!");
                return;
            }

            //Print which sorting method we are performing
            System.Console.WriteLine("****************************** " + sort.Method.Name + " ******************************");

            // Perform the sort on arrays of increasing sizes. Once a sort takes over a minute, then stop.
            for (int i = 0; i < sizes.Length; i++)
            {
                int[] numbers = data.getCopyOfData(sizes[i]);
                System.Console.Write("Size:" + sizes[i] + "\t");

                System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
                sort(numbers);
                sw.Stop();

                if (!IsSorted(numbers))
                {
                    System.Console.WriteLine("Array was not successfully sorted!");
                    return;
                }
                System.Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + " milliseconds.");
                if (sw.ElapsedMilliseconds > 1000 * 60 && i > 0)
                {
                    System.Console.WriteLine("Maximum elements sorted in under 1 minute: " + sizes[i - 1] + "\n");
                    break;
                }
            }
        }

        /// <summary>
        /// Sort the array using the common Selection Sort algorithm.
        /// http://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            // Loop through the entire list finding the next smallest element each time
            for (int firstIndex = 0; firstIndex < arr.Length; firstIndex++)
            {
                int smallest = arr[firstIndex];
                int smallestIndex = firstIndex;
                //Find the next smallest element and swap with the element at firstIndex
                for (int secondIndex = firstIndex; secondIndex < arr.Length; secondIndex++)
                {
                    if(arr[secondIndex] < smallest)
                    {
                        smallest = arr[secondIndex];
                        smallestIndex = secondIndex;
                    }
                }
                SwapNums(arr, firstIndex, smallestIndex);
            }
        }

        /// <summary>
        /// Sort the array using the common Insertion Sort algorithm.
        /// http://en.wikipedia.org/wiki/Insertion_sort
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            // We can treat the first element as already sorted, since an array of 1 is always sorted.
            for (int alreadySortedIndex = 1; alreadySortedIndex < arr.Length; alreadySortedIndex++)
            {
                for (int insertAtIndex = 0; insertAtIndex < alreadySortedIndex; insertAtIndex++)
                {
                    if(arr[insertAtIndex] >= arr[alreadySortedIndex])
                    {
                        InsertNum(arr, alreadySortedIndex, insertAtIndex);
                    }
                }
            }
        }

        /// <summary>
        /// Sort the array using the common Bubble Sort method.
        /// http://en.wikipedia.org/wiki/Bubble_sort
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            bool swapped = true;
            while (swapped)
            {
                swapped = false;
                for (int index = 0; index < arr.Length-1; index++)
                {
                    if(arr[index] > arr[index+1])
                    {
                        SwapNums(arr, index, index+1);
                        swapped = true;
                    }
                }
            }
        }

        /// <summary>
        /// Sort the array using the common MergeSort method.
        /// http://en.wikipedia.org/wiki/Merge_sort 
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            int[] newArr = recMergeSort(arr, 0, arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = newArr[i];
            }
        }
        
        /// <summary>
        /// A recurisve helper method to do the actual merge sort.
        /// Create temp arrays along the way and return them.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static int[] recMergeSort(int[] arr, int start, int end)
        {
            // start is inclusive, end is non-inclusive.
            int size = end - start;

            // It should never be 0 or negative
            if(size <= 0)
            {
                throw new System.ArgumentException("Can't sort an array of 0 elements.");
            }

            // If there is only a single element, it's already sorted.
            if(size == 1)
            {
                int[] toReturn = new int[size];
                toReturn[0] = arr[start];
                return toReturn;
            }

            // Find the middle (auto floor function) and make recursive calls on each half
            int mid = start + (end - start) / 2;
            int[] leftSide = recMergeSort(arr, start, mid);
            int[] rightSide = recMergeSort(arr, mid, end);

            // Create a new array to merge into and then return
            int[] retArr = new int[size];

            int leftIndex = 0;
            int rightIndex = 0;
            for (int index = 0; index < size; index++)
            {
                if(rightIndex >= rightSide.Length )
                {
                    retArr[index] = leftSide[leftIndex];
                    leftIndex++;
                }
                else if(leftIndex >= leftSide.Length)
                {
                    retArr[index] = rightSide[rightIndex];
                    rightIndex++;
                }
                else if(leftSide[leftIndex] < rightSide[rightIndex])
                {
                    retArr[index] = leftSide[leftIndex];
                    leftIndex++;
                }
                else
                {
                    retArr[index] = rightSide[rightIndex];
                    rightIndex++;
                }
            }
            return retArr;
        }

        public static void QuickSort(int[] arr)
        {

        }
        

        /// <summary>
        /// Swap two numbers in an array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static void SwapNums(int[] arr, int index1, int index2)
        {
            if(index1 > arr.Length || index1 < 0)
            {
                System.Console.WriteLine("Illegal index: " + index1.ToString() + " Array Length: " + arr.Length.ToString());
                return;
            }
            if(index2 > arr.Length || index2 < 0)
            {
                System.Console.WriteLine("Illegal index: " + index2.ToString() + " Array Length: " + arr.Length.ToString());
                return;
            }
            if(index1 == index2)
            {
                return;
            }

            int temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
            return;
        }

        /// <summary>
        /// Takes a number in the array and inserts it at a different position in the array, shifting numbers to the right as needed.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="insertAtIndex"></param>
        /// <param name="insertFromIndex"></param>
        public static void InsertNum(int[] arr, int insertFromIndex, int insertAtIndex)
        {
            if(insertAtIndex > arr.Length || insertAtIndex < 0)
            {
                System.Console.WriteLine("Illegal index: " + insertAtIndex.ToString() + " Array Length: " + arr.Length.ToString());
                return;
            }
            if(insertFromIndex > arr.Length || insertFromIndex < 0)
            {
                System.Console.WriteLine("Illegal index: " + insertFromIndex.ToString() + " Array Length: " + arr.Length.ToString());
                return;
            }
            if(insertAtIndex == insertFromIndex)
            {
                return;
            }
            if (insertFromIndex < insertAtIndex)
            {
                System.Console.WriteLine("Illegal insert operation. Must always insert from right to left." + insertFromIndex, insertAtIndex);
                return;
            }
            int numToInsert = arr[insertFromIndex];
            for (int i = insertFromIndex; i != insertAtIndex; i--)
            {
                arr[i] = arr[i - 1];
            }
            arr[insertAtIndex] = numToInsert;
        }

        /// <summary>
        /// Returns true if an array is sorted, false otherwise.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static bool IsSorted(int[] arr)
        {
            if(arr.Length < 1)
            {
                //An empty array is always sorted.
                return true;
            }
            int num1 = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < num1)
                {
                    return false;
                }
                num1 = arr[i];
            }
            //If we make it to here, we know it is sorted
            return true;
        }

        /// <summary>
        /// Prints an integer array
        /// </summary>
        /// <param name="arr"></param>
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.Write(arr[i]);
                if(i != arr.Length-1)
                {
                    System.Console.Write(", ");
                }
            }
            System.Console.WriteLine();
        }
    }
}
