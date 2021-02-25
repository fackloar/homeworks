using System;

namespace Project_2
{
    class Program
    {
        public class Test
        {
            public int[] testArray { get; set; }
            public int testValue { get; set; }
            public int expected { get; set; }
        }
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1; // O(1)
        }

        static void Main(string[] args)
        {
            var testData = new Test[5];
            testData[0] = new Test()
            {
                testArray = new int[5] {1, 2, 3, 4, 5},
                testValue = 3,
                expected = 2,
            };
            testData[1] = new Test()
            {
                testArray = new int[10] { 10, 100, 5, 200, 15, 350, 2000, 4000, 154, 46 },
                testValue = 46,
                expected = -1,
            };
            testData[2] = new Test()
            {
                testArray = new int[3] { 10, 100, 1000 },
                testValue = 100,
                expected = 1,
            };
            testData[3] = new Test()
            {
                testArray = new int[6] { 3, 6, 9, 12, 15, 18 },
                testValue = 6,
                expected = 1,
            };
            testData[4] = new Test()
            {
                testArray = new int[7] { 10, 20, 30, 40, 50, 60, 70 },
                testValue = 60,
                expected = 5,
            };
            int i = 0;
            foreach (var Test in testData)
            {
                i++;
                int result = BinarySearch(Test.testArray, Test.testValue);
                Console.WriteLine($"Test {i}\ntestArray:{Test.testArray}'\ntestValue: {Test.testValue}\nexpected: '{Test.expected}'\nresult: '{result}'");
                Console.WriteLine();
            }
        }
    }
}
