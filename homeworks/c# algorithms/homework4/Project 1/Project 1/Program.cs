using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadLine();
            Console.ReadLine();
            /*
                |           Method |     Mean |     Error |    StdDev |
                |----------------- |---------:|----------:|----------:|
                |   TestCheckArray | 2.099 ms | 0.0357 ms | 0.0334 ms |
                | TestCheckHashSet | 3.446 ms | 0.0317 ms | 0.0296 ms |
             */
        }
    }
    


}
