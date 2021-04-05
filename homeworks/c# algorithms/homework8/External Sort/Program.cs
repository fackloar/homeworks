using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace External_Sort
{
    class Program
    {
        public static void WriteToFileArr(int[] arrayOfIntNumbers, string filename)
        {
            var stringBuilder = new StringBuilder();

            foreach (var arrayElement in arrayOfIntNumbers)
            {
                stringBuilder.AppendLine(arrayElement.ToString());
            }
            File.AppendAllText(filename, stringBuilder.ToString());
        }
        public static void WriteToFileList(List<int> list, string filename)
        {
            var stringBuilder = new StringBuilder();

            foreach (var listElement in list)
            {
                stringBuilder.AppendLine(listElement.ToString());
            }
            File.AppendAllText(filename, stringBuilder.ToString());
        }

        static public void Test1() //test with pre-decided numbers
        {
            var fileArray = File.Create("array.txt");
            fileArray.Close();
            string fArrString = "array.txt";
            string fSorArrString = "doneArray.txt";
            var directory = Directory.GetCurrentDirectory();
            string dirStr = directory.ToString();
            int[] numbers = { 28, 84, 18, 10, 92, 87, 58, 16, 81, 64, 21, 61, 63, 52, 105, 242, 143, 1, 234, 543, 756, 887, 977, 456, 5436, 2, 13, 29, 100, 300};
            WriteToFileArr(numbers, fArrString);
            fileArray.Close();
            ExtSort.Split(fArrString);
            ExtSort.SortTheChunks(dirStr);
            ExtSort.MergeTheChunks(dirStr, fSorArrString);
        }

        static public void Test2() //test with big random list
        {
            
            List<int> bigList = new List<int>();
            var rand = new Random();
            for (int i = 0; i <=1000; i++)
            {
                int intRand = rand.Next();
                bigList.Add(intRand);
            }
            var fileList = File.Create("list.txt");
            fileList.Close();
            string fnString = "list.txt";
            string fSorList = "doneList.txt";
            var directory = Directory.GetCurrentDirectory();
            string dirStr = directory.ToString();
            WriteToFileList(bigList, fnString);
            fileList.Close();
            ExtSort.Split(fnString);
            ExtSort.SortTheChunks(dirStr);
            ExtSort.MergeTheChunks(dirStr, fSorList);
        }
        static void Main(string[] args)
        {
            Test1();
            Test2();
        }
    }
}
