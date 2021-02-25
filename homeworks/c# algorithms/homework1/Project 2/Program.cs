using System;

namespace Project_2
{
    class Program
    {
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;   //O(1)
            for (int i = 0; i < inputArray.Length; i++) //O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N*N)
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N*N*N)
                    {
                        int y = 0; //O(1)

                        if (j != 0) 
                        {
                            y = k / j; //O(1)
                        }

                        sum += inputArray[i] + i + k + j + y; //O(1)
                    }
                }
            }

            return sum; //O(1)

            // SUM = O(3N^3+1)
        }
        static void Main(string[] args)
        {
            int[] test = { 1, 1, 1, 1 };
            int result = StrangeSum(test);
            Console.WriteLine(result);
        }
    }
}
