using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Project_1
{
    public class BechmarkClass
    {
        static string[] CreateArray()
        {
            string[] randomStringsArray = new string[10000];

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            for (int i = 0; i < randomStringsArray.Length - 1; i++)
            {
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }

                var finalString = new String(stringChars);
                randomStringsArray[i] = finalString;
            }
            randomStringsArray[9999] = "testString";
            return randomStringsArray;
            
        }
        static HashSet<String> CreateHashSet()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();
            HashSet<String> randomStrings = new HashSet<String>();
            for (int i = 0; i < 9999; i++)
            {
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }
                var finalString = new String(stringChars);
                randomStrings.Add(finalString);
            }
            randomStrings.Add("testString");
            return randomStrings;
        }

        static void CheckArray(string[] test)
        {
            bool check = false;
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == "testString")
                {
                    check = true;
                    break;
                }
                else
                {
                    check = false;
                }
            }
            if (check == true)
                Console.WriteLine("FOUND IT!");
            else
                Console.WriteLine("NOT FOUND!");
        }
        static void CheckHashSet(HashSet<String> test)
        {
            if (test.Contains("testString"))
                Console.WriteLine("Found");
            else
                Console.WriteLine("Not found");
        }
        [Benchmark]
        public void TestCheckArray()
        {
            string[] testArray = CreateArray();
            CheckArray(testArray);
        }
        [Benchmark]
        public void TestCheckHashSet()
        {
            HashSet<String> testHashSet = CreateHashSet();
            CheckHashSet(testHashSet);
        }
    }
}
