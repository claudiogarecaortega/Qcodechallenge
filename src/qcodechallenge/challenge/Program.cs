using System;
using challenge.Helpers;

namespace challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixGenerator = new MatrixGenerator();
            var matrix = matrixGenerator.GenerateMatrix(20,20);

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
