using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 3, 0 , 2, 2 ,4};
            //Console.WriteLine("Enter the input size");
            //int size = Convert.ToInt32(Console.ReadLine());

            //int[] input = new int[size];
            //Random rnd = new Random();

            //for (int i = 0; i < size; i++)
            //{
                
            //    int no = rnd.Next(0, size);
            //    input[i] = no;
            //}

            Console.WriteLine("Array before sorting:");
            foreach (var t in input)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine("");

            Console.WriteLine("Array after sorting:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            HeapSort(input);
            stopwatch.Stop();
            foreach (var t in input)
            {
                Console.Write(t + " ");
            }
            Console.WriteLine("Execution Time: {0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Input array size: {0}", input.Length);
            Console.Read();

        }

        public static void HeapSort(int[] nos)
        {
            int arrayLength = nos.Length,temp;

            for (int i = (arrayLength / 2) - 1; i >= 0; i--)
            {
                ReOrder(nos, i, arrayLength );
            }

            for (int i = arrayLength - 1; i > 0; i--)
            {
                temp = nos[0];
                nos[0] = nos[i];
                nos[i] = temp;
                ReOrder(nos, 0, i-1);
            }

        }

        public static void ReOrder(int[] array, int root, int bottom)
        {
            int tracker, maxChild, temp;
            tracker = 0;
            while ((root * 2 <= bottom) && (tracker == 0))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (array[root * 2] > array[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                if (array[root] < array[maxChild])
                {
                    temp = array[root];
                    array[root] = array[maxChild];
                    array[maxChild] = temp;
                    root = maxChild;
                }
                else
                    tracker = 1;
            }

        }

    }
}
