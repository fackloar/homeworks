using System;
using System.Collections.Generic;

namespace Bucket_Sort
{
    class Program
    {
        
        public static void BucketSort(ref int[] data)
        {
            List<int>[] buckets = new List<int>[7];
            List<int> output = new List<int>();
            for (int i = 0; i < buckets.Length; i++)
            buckets[i] = new List<int>();
            


            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < 0)
                {
                    buckets[0].Add(data[i]);
                }
                else if (data[i] >= 0 && data[i] <= 19)
                {
                    buckets[1].Add(data[i]);
                }
                else if (data[i] >= 20 && data[i] <= 39)
                {
                    buckets[2].Add(data[i]);
                }
                else if (data[i] >= 40 && data[i] <= 59)
                {
                    buckets[3].Add(data[i]);
                }
                else if (data[i] >= 60 && data[i] <= 79)
                {
                    buckets[4].Add(data[i]);
                }
                else if (data[i] >= 80 && data[i] <= 99)
                {
                    buckets[5].Add(data[i]);
                }
                else if (data[i] >= 100)
                {
                    buckets[6].Add(data[i]);
                }
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();
            }
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    data[index++] = buckets[i][j];
                }
            }


        }

        public static void Test1()
        {
            int[] exArr = { 28, 84, 18, 10, 92, 8, 54, 6, 81, 64, 21, 61 };
            BucketSort(ref exArr);
            Console.WriteLine("Expected output:\n6 8 10 18 21 28 54 61 64 81 84 92");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Actual output:");
            for (int i = 0; i < exArr.Length; i++)
            {
                Console.Write($"{exArr[i]} ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Test2()
        {
            int[] exArr = { 29, 85, 19, 11, 93, 9, 55, 7, 82, 65, 22, 62 };
            BucketSort(ref exArr);
            Console.WriteLine("Expected output:\n7 9 11 19 22 29 55 62 65 82 85 93");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Actual output:");
            for (int i = 0; i < exArr.Length; i++)
            {
                Console.Write($"{exArr[i]} ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void Test3()
        {
            int[] exArr = { 69, 73, 0, 9, 7, 96, 1003, -13, 59, 50, 43, 97, 3, 86, 156, 42 };
            BucketSort(ref exArr);
            Console.WriteLine("Expected output:\n-13 0 3 7 9 42 43 50 59 69 73 86 96 97 156 1003");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Actual output:");
            for (int i = 0; i < exArr.Length; i++)
            {
                Console.Write($"{exArr[i]} ");
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Test1();
            Test2();
            Test3();

        }
    }
}
