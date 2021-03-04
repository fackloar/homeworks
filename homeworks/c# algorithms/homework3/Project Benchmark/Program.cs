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


            /*  |                              Method |     Mean |    Error |   StdDev |
                |------------------------------------ |---------:|---------:|---------:|
                |              TestPointDistanceClass | 11.65 us | 0.096 us | 0.090 us |
                |             TestPointDistanceStruct | 11.50 us | 0.131 us | 0.123 us |
                |       TestPointDistanceDoubleStruct | 11.67 us | 0.132 us | 0.124 us |
                | TestPointDistanceDoubleStructNoRoot | 11.54 us | 0.096 us | 0.085 us | */
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
            RandCoords();
            PointClass pointOne = new PointClass() { X = RandFloatX1, Y = RandFloatY1 };
            PointClass pointTwo = new PointClass() { X = RandFloatX2, Y = RandFloatY2 };
            PointDistanceClass(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceStruct()
        {
            RandCoords();
            PointStructFloat pointOne = new PointStructFloat() { X = RandFloatX1, Y = RandFloatY1 };
            PointStructFloat pointTwo = new PointStructFloat() { X = RandFloatX2, Y = RandFloatY2 };
            PointDistanceStruct(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceDoubleStruct()
        {
            RandCoords();
            PointStructDouble pointOne = new PointStructDouble() { X = (double)RandFloatX1, Y = (double)RandFloatY1 };
            PointStructDouble pointTwo = new PointStructDouble() { X = (double)RandFloatX2, Y = (double)RandFloatY2 };
            PointDistanceDoubleStruct(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceDoubleStructNoRoot()
        {
            RandCoords();
            PointStructDouble pointOne = new PointStructDouble() { X = (double)RandFloatX1, Y = (double)RandFloatY1 };
            PointStructDouble pointTwo = new PointStructDouble() { X = (double)RandFloatX2, Y = (double)RandFloatY2 };
            PointDistanceDoubleStructNoRoot(pointOne, pointTwo);
        }
    }
}