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
    class MainClass
    {
        /* 
         * Main entry point of this solution.
         */
        static int Main(String[] args)
        {
            int[] numbers = {5, 3, -10, 7, 4, 5, 14};

            System.Console.Write("Pre-sorted array: ");
            PrintArray(numbers);
            System.Console.WriteLine("Selection Sorting...");
            SelectionSort(numbers);
            System.Console.Write("Post-sorted array: "); 
            PrintArray(numbers);

            System.Console.Read();
            return 0;
        }


        /*
         * Sort the array using the common Selection Sort algorithm.
         * http://en.wikipedia.org/wiki/Selection_sort
         * 
         */
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
        

        /************************************** Util Functions ****************************************/
        /*
         * Swap two numbers in an array.
         * 
         */
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

        /*
         * Prints an integer array
         * 
         */
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
