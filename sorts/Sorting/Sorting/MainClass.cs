/*
 * Implementation of:
 * - Selection Sort
 * - Insertion Sort
 * - Bubble Sort
 * - Heap Sort
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
    class TestData
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

    class MainClass
    {
        /// <summary>
        /// Main entry point of this solution
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Main(String[] args)
        {
            //Use some common powers of 2
            long[] sizes = {1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, //2^10 - 2^19
                           1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, //2^20 - 2^29
                           107374182}; //2^30 and max size possible (close to 2^31)
            TestData data = new TestData(sizes[sizes.Length-1]); //Generate all the needed data first


            /**************************************************** Selection Sort Testing *********************************************/
            //For each sort to be tested, loop through using the previous array of sizes. Once a test takes over a minute, then stop looping.
            for (int i = 0; i < sizes.Length; i++)
            {
                int[] numbers = data.getCopyOfData(sizes[i]);
                System.Console.WriteLine("Size of test data: " + sizes[i]);
                System.Console.WriteLine("Selection Sorting................................");

                System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();
                SelectionSort(numbers);
                sw.Stop();

                if (!IsSorted(numbers))
                {
                    System.Console.WriteLine("Array was not successfully sorted!");
                    return 1;
                }
                System.Console.WriteLine("Time elapsed: " + sw.ElapsedMilliseconds + " milliseconds.");
                if (sw.ElapsedMilliseconds > 1000 * 60 && i > 0)
                {
                    System.Console.WriteLine("Maximum elements sorted in under 1 minute: " + sizes[i - 1]);
                    break;
                }

            }

            /**************************************************** Insertion Sort *********************************************/
            /**************************************************** Bubble Sort *********************************************/
            /**************************************************** Heap Sort *********************************************/
            /**************************************************** Quick Sort *********************************************/

            System.Console.Read();
            return 0;
        }

        /// <summary>
        /// Sort the array using the common Selection Sort algorithm.
        /// http://en.wikipedia.org/wiki/Selection_sort
        /// </summary>
        /// <param name="arr"></param>
        static void SelectionSort(int[] arr)
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

        static void InsertionSort(int[] arr)
        {

        }

        static void BubbleSort(int[] arr)
        {

        }

        static void HeapSort(int[] arr)
        {

        }

        static void QuickSort(int[] arr)
        {

        }
        

        /// <summary>
        /// Swap two numbers in an array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        static void SwapNums(int[] arr, int index1, int index2)
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
        /// Returns true if an array is sorted, false otherwise.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        static bool IsSorted(int[] arr)
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
        static void PrintArray(int[] arr)
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
