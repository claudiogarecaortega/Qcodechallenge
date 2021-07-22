using System;
using System.Collections.Generic;
using challenge.Helpers;

namespace challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var listWords = new List<string>() {"test","TesHome","Home","walk", "string", "sop"};
            var listWordsToFind = new List<string>() {"test","Home", "sop", "circule"};
            var matrixGenerator = new MatrixGenerator();
            var matrix = matrixGenerator.GenerateMatrix(50,50);
            var matrixWithWords = matrixGenerator.HideWordsCollection(listWords, matrix);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write($"{matrixWithWords[i, j]} ");
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }

            var wordFinder = new WordFinder(matrixWithWords);
            var findResult = wordFinder.Find(listWordsToFind);
            Console.Write($"Word Found: ");
            Console.Write(Environment.NewLine + Environment.NewLine);

            foreach (var result in findResult)
            {
                Console.Write($"- {result} ");
                Console.Write(Environment.NewLine + Environment.NewLine);

            }
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
