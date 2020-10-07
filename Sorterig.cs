using System;
using System.Diagnostics;

namespace Sortering
{
    class Program
    {
        static void Main(String[] args)
        {
            int numberOfWords = 1000;
            String[] unsorted = new String[numberOfWords];

            String[] letters =
                    { "A", "B", "C", "D", "E", "F",
                      "G", "H", "I", "J", "K", "L",
                      "M", "N", "O", "P", "Q", "R",
                      "S", "T", "U", "V", "X", "Y",
                      "Z"
                    };

            for (int i = 0; i < numberOfWords; i++)
            {
                String randomWord = "";


                for(int j = 0; j < 20; j++)
                {
                    Random random = new Random();
                    int randomInt = random.Next(0, 25);
                    randomWord += letters[randomInt];
                }

                unsorted[i] = randomWord;

            }

            Stopwatch stopWatch = new Stopwatch();
            
            stopWatch.Start();
            string[] sorted = BubbleSort(unsorted);
            stopWatch.Stop();

           
            string elapsedTimeBubble = stopWatch.ElapsedMilliseconds.ToString();
            Console.WriteLine("Time for sorting with Bubble Sort: ");
            Console.WriteLine(elapsedTimeBubble);

            stopWatch.Reset();

            stopWatch.Start();
            string[] sorted2 = InsertionSort(unsorted);
            stopWatch.Stop();

            string elapsedTimeInsertion = stopWatch.ElapsedMilliseconds.ToString();
            
            Console.WriteLine("Time for sorting with Insertion Sort: ");
            Console.WriteLine(elapsedTimeInsertion);
            
            foreach(string s in unsorted)
            {
                Console.WriteLine(s);
            }

            stopWatch.Reset();

            
            stopWatch.Start();
            String[] sorted3 = MergeSort(unsorted);
            stopWatch.Stop();
            string elapsedTimeMerge = stopWatch.ElapsedMilliseconds.ToString();
            
            Console.WriteLine("Time for sorting with Merge Sort: ");
            Console.WriteLine(elapsedTimeMerge);

        }

        private static String[] BubbleSort(String[] unsortedArray)
        {

            String[] sorted = unsortedArray;
            string temp;

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                for(int j = i + 1; j < sorted.Length; j++)
                {
                    if(sorted[i].CompareTo(sorted[j]) > 0)
                    {
                        temp = sorted[i];
                        sorted[i] = sorted[j];
                        sorted[j] = temp;


                    }
                }

            }




            return sorted;

        }


        private static String[] InsertionSort(String[] unsortedArray)
        {
            String[] sorted = unsortedArray;

            String temp, smallest;

            for(int i = 0; i < sorted.Length - 1; i++)
            {
                for(int j = i + 1; j > 0; j--)
                {
                    if(sorted[j - 1].CompareTo(sorted[j]) > 0)
                    {
                        temp = sorted[j - 1];
                        sorted[j - 1] = sorted[j];
                        sorted[j] = temp;
                    }
                }
            }

            return sorted;
        }

        private static String[] MergeSort(String[] unsortedArray) {
            String[] sorted = unsortedArray;

            string[] left;
            string[] right;
            string[] result = new string[sorted.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (sorted.Length <= 1)
                return sorted;
            // The exact midpoint of our array  
            int midPoint = sorted.Length / 2;
            //Will represent our 'left' array
            left = new string[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (sorted.Length % 2 == 0)
                right = new string[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new string[midPoint + 1];
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = sorted[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to 
            for (int i = midPoint; i < sorted.Length; i++)
            {
                right[x] = sorted[i];
                x++;
            }
            //Recursively sort the left array
            left = MergeSort(left);
            //Recursively sort the right array
            right = MergeSort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        private static string[] merge(string[] left, string[] right)
        {
            int resultLength = right.Length + left.Length;
            string[] result = new string[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft].CompareTo(right[indexRight]) < 0)
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

    }
    
}
