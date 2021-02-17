using System;

namespace Project1
{
    class Program
    {
        public class Test
        {
            public int n { get; set; }

            public string expected { get; set; }
        }
        public static string PrimeOrNo(int n)
        {
            string result;
            int d = 0;
            int i = 2;
            while (i < n)
            {
                if (n % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                result = "Prime number";
            }
            else
            {
                result = "Not prime number";
            }
            return result;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var testData = new Test[4];
            testData[0] = new Test()
            {
                n = 2,
                expected = "Prime number"
            };
            testData[1] = new Test()
            {
                n = 23,
                expected = "Prime number"
            };
            testData[2] = new Test()
            {
                n = 65,
                expected = "Not prime number"
            };
            testData[3] = new Test()
            {
                n = 124,
                expected = "Not prime number"
            };
            int i = 0; 
            foreach (var Test in testData)
            {
                i++;
                string result = PrimeOrNo(Test.n);
                Console.WriteLine($"Test {i}\nn: '{Test.n}'\nexpected: '{Test.expected}'\nresult: '{result}'");
            }
            Console.ReadKey();
        }
    }
}
