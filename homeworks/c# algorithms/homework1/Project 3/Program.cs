using System;

namespace Project_3
{
    class Program
    {
        public class Test
        {
            public int Number { get; set; }

            public int Expected { get; set; }
        }
        static int FibonacciRec(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else if (n < 0)
            {
                return FibonacciRec(n + 2) - FibonacciRec(n + 1);
            }
            else
            {
                return FibonacciRec(n - 1) + FibonacciRec(n - 2);
            }
        }

        static int FibonacciNoRec(int n)
        {
            int firstNumber = 0, secondNumber = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }

            return result;
        }


        static void Main(string[] args)
        {
            var testData = new Test[4];
            testData[0] = new Test()
            {
                Number = 1,
                Expected = 1
            };
            testData[1] = new Test()
            {
                Number = 8,
                Expected = 21
            };
            testData[2] = new Test()
            {
                Number = 18,
                Expected = 2584
            };
            testData[3] = new Test()
            {
                Number = 10,
                Expected = 55
            };
            int i = 0;
            foreach (var Test in testData)
            {
                i++;
                int result = FibonacciRec(Test.Number);
                Console.WriteLine($"Test {i}\nn: '{Test.Number}'\nexpected: '{Test.Expected}'\nresult: '{result}'");
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nNon recursive function:");
            foreach (var Test in testData)
            {
                i++;
                int result = FibonacciNoRec(Test.Number);
                Console.WriteLine($"Test {i}\nn: '{Test.Number}'\nexpected: '{Test.Expected}'\nresult: '{result}'");
            }
            Console.ResetColor();
            Console.ReadKey();

        }
    }
}