using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using System;

namespace Project_Benchmark

{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();


            /*  |                              Method |       Mean |     Error |    StdDev |     Median |
                |------------------------------------ |-----------:|----------:|----------:|-----------:|
                |              TestPointDistanceClass | 26.6552 ns | 1.2740 ns | 3.7564 ns | 26.7525 ns |
                |             TestPointDistanceStruct |  0.0093 ns | 0.0129 ns | 0.0115 ns |  0.0057 ns |
                |       TestPointDistanceDoubleStruct |  0.0106 ns | 0.0106 ns | 0.0083 ns |  0.0105 ns |
                | TestPointDistanceDoubleStructNoRoot |  0.0171 ns | 0.0288 ns | 0.0270 ns |  0.0000 ns | */ 
        }
    }


    public class PointClass
    {
        public float X;
        public float Y;
    }
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }
    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }

    public class BechmarkClass
    {
        public static float RandFloatX1 { get; set; }

        public static float RandFloatY1 { get; set; }

        public static float RandFloatX2 { get; set; }

        public static float RandFloatY2 { get; set; }

        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float PointDistanceStruct(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceDoubleStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static double PointDistanceDoubleStructNoRoot(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        public static float GenerateRandomFloat()
        {
            Random rnd = new Random();
            double mantissa = (rnd.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, rnd.Next(-126, 127)); //произвольная переменная
            return (float)(mantissa * exponent);
        }

        public static void RandCoords()
        {
            RandFloatX1 = GenerateRandomFloat();
            RandFloatY1 = GenerateRandomFloat();
            RandFloatX2 = GenerateRandomFloat(); //4 произвольных координаты
            RandFloatY2 = GenerateRandomFloat();
        }

        [Benchmark]
        public void TestPointDistanceClass()
        {
            PointClass pointOne = new PointClass() { X = RandFloatX1, Y = RandFloatY1 };
            PointClass pointTwo = new PointClass() { X = RandFloatX2, Y = RandFloatY2 };
            PointDistanceClass(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceStruct()
        {
            PointStructFloat pointOne = new PointStructFloat() { X = RandFloatX1, Y = RandFloatY1 };
            PointStructFloat pointTwo = new PointStructFloat() { X = RandFloatX2, Y = RandFloatY2 };
            PointDistanceStruct(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceDoubleStruct()
        {
            PointStructDouble pointOne = new PointStructDouble() { X = (double)RandFloatX1, Y = (double)RandFloatY1 };
            PointStructDouble pointTwo = new PointStructDouble() { X = (double)RandFloatX2, Y = (double)RandFloatY2 };
            PointDistanceDoubleStruct(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceDoubleStructNoRoot()
        {
            PointStructDouble pointOne = new PointStructDouble() { X = (double)RandFloatX1, Y = (double)RandFloatY1 };
            PointStructDouble pointTwo = new PointStructDouble() { X = (double)RandFloatX2, Y = (double)RandFloatY2 };
            PointDistanceDoubleStructNoRoot(pointOne, pointTwo);
        }
    }
}