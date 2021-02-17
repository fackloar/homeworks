using System;
using System.IO;
using System.Collections.Generic;

namespace Project_3
{
    class Program
    {
        static byte[] getNumbers(string[] data)
        {
            List<byte> inputBytes = new List<byte>();
            for (int i = 0; i < data.Length; i++)
            {
                inputBytes.Add(Byte.Parse(data[i]));
            }
            byte[] array = inputBytes.ToArray();
            return array;
        }
        static void Main(string[] args)
        {
            string filename = "binary.bin";
            Console.WriteLine("Enter numbers from 0 to 255 and we will write them into a binary file!");
            string input = Console.ReadLine();
            string[] inputString = input.Split(" ");
            byte[] parsedInput = getNumbers(inputString);
            File.WriteAllBytes(filename, parsedInput);
            Console.ReadKey();
        }
    }
}
