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
            System.Console.WriteLine("Generating test data...");
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
            //In order to allocate arrays of this size, we need to set the gcAllowVeryLargeObjects flag in the App.config file. 
            //Use some common powers of 2
            int[] sizes = {1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, //2^10 - 2^19
                           1048576, 2097152, 4194304, 8388608};

            int[] sizes2 = {1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, //2^10 - 2^19
                           1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, //2^20 - 2^29
                           1073741824}; //2^30
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
            int[] mergeArray = new int[arr.Length];
            recMergeSort(arr, 0, arr.Length, mergeArray);
        }
        
        /// <summary>
        /// A recurisve helper method to do the actual merge sort.
        /// Create temp arrays along the way and return them.
       /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static void recMergeSort(int[] arr, int start, int end, int[] mergeArray)
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
                return;
            }

            // Find the middle (auto floor function) and make recursive calls on each half
            int mid = start + (end - start) / 2;
            recMergeSort(arr, start, mid, mergeArray);
            recMergeSort(arr, mid, end, mergeArray);

            int leftIndex = start;
            int rightIndex = mid;
            for (int index = start; index < end; index++)
            {
                if(rightIndex >= end)
                {
                    mergeArray[index] = arr[leftIndex];
                    leftIndex++;
                }
                else if(leftIndex >= mid)
                {
                    mergeArray[index] = arr[rightIndex];
                    rightIndex++;
                }
                else if(arr[leftIndex] < arr[rightIndex])
                {
                    mergeArray[index] = arr[leftIndex];
                    leftIndex++;
                }
                else
                {
                    mergeArray[index] = arr[rightIndex];
                    rightIndex++;
                }
            }
            // Copy back into the original array
            for (int i = start; i < end; i++)
            {
                arr[i] = mergeArray[i];
            }
            return;
        }

        /// <summary>
        /// Sort the array using the common QuickSort metho.
        /// http://en.wikipedia.org/wiki/Quick_sort
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(int[] arr)
        {
            recQuickSort(arr, 0, arr.Length);
        }

        private static void recQuickSort(int[] arr, int start, int end)
        {
            // start is inclusive, end is non-inclusive.
            int size = end - start;
            int midInd = start + size / 2;

            // It should never be negative
            if(size < 0)
            {
                throw new System.ArgumentException("Can't sort an array of less than 0 elements.");
            }

            // If there is only a single element or zero elements, it's already sorted.
            if(size == 1 || size == 0)
            {
                return;
            }

            // If there are only 2 elements, quicker to do it this way
            if(size == 2)
            {
                if(arr[start] > arr[start+1])
                {
                    SwapNums(arr, start, start + 1);
                }
                return;
            }

            // Calculate pivot value - for now take median of first, last, middle
            // TODO: better way to find the median...
            if((arr[start] >= arr[midInd] && arr[start] <= arr[end-1]) ||
                (arr[start] <= arr[midInd] && arr[start] >= arr[end-1]))
            {
                // Do nothing here since it is already at index "start"
            }
            else if((arr[midInd] >= arr[start] && arr[midInd] <= arr[end-1]) ||
                (arr[midInd] <= arr[start] && arr[midInd] >= arr[end-1]))
            {
                SwapNums(arr, start, midInd);
            }
            else
            {
                SwapNums(arr, start, end - 1);
            }

            // Partition the array so the numbers on the left < partValue and the nums on the right all >= partValu
            int pivIndex = Partition(arr, start, end);

            // Optimization to handle duplicate numbers
            int pivIndex2 = pivIndex;
            while(pivIndex2 < end && arr[pivIndex] == arr[pivIndex2])
            {
                pivIndex2++;
            }

            // Rec calls
            recQuickSort(arr, start, pivIndex);
            recQuickSort(arr, pivIndex2, end);
        }

        /// <summary>
        /// QuickSort helper function to partition the array.
        /// The first value is treated as the pivot value.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>The index of the partition value after this step.</returns>
        public static int Partition(int[] arr, int start, int end)
        {
            // Partition the array so the numbers on the left < partValue and the nums on the right all >= partValu
            int leftMarker = start + 1; // Plus one to start after the pivot value which is always at index start
            int rightMarker = end - 1;
            int pivVal = arr[start];
            while(leftMarker <= rightMarker)
            {
                // First move left marker to the right until an element > pivVal is found.
                while(leftMarker < end && arr[leftMarker] < pivVal)
                {
                    leftMarker++;
                }
                // Then move right marker to the left until an element < pivVal is found.
                while(rightMarker > start & arr[rightMarker] > pivVal)
                {
                    rightMarker--;
                }
                if(leftMarker < rightMarker)
                {
                    SwapNums(arr, leftMarker, rightMarker);
                    leftMarker++;  // Fix an infinite loop bug where arr[left] == arr[right] == pivtoValue;
                }
                else
                {
                    SwapNums(arr, start, rightMarker);
                    break;
                }
            }
            return rightMarker; // Is this right??
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
        /// Note: this doesn't really test that the sort worked correctly, since it doesn't compare the numbers 
        /// with those in the original array. An array full of 0's would pass this test, 
        /// but it is only meant as a quick sanity check not an actual unit test.
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
