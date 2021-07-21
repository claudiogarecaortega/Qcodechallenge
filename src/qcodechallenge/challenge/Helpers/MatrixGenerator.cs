using System;
using System.Collections.Generic;

namespace challenge.Helpers
{
    public class MatrixGenerator
    {
        private readonly AlphaNumericGenerator alphaNumericGenerator;
        public MatrixGenerator()
        {
            alphaNumericGenerator = new AlphaNumericGenerator();
        }

        /// <summary>
        /// Generate a Matrix based on the size
        /// </summary>
        /// <param name="rows"> Rows to be generated </param>
        /// <param name="columns"> Columns to be generated </param>
        /// <returns> new Multidimensional Array </returns>
        public string[,] GenerateMatrix(int rows, int columns)
        {
            var matrix = new string[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {

                    matrix[i, j] = alphaNumericGenerator.RandomString();
                }
            }
            return matrix;
        }

        public string[,] HideWordsCollection(IEnumerable<string> wordsCollection, string[,] matrix)
        {
            Array values = Enum.GetValues(typeof(WordOrientation));
            Random random = new Random();

            foreach (var word in wordsCollection)
            {
                var randomEnumValue = (WordOrientation)values.GetValue(random.Next(values.Length));
                var index = GetMatrixIndexToAddWord(matrix.GetLength(0), word.Length);
               
                if (randomEnumValue == WordOrientation.Horizontal)
                {
                    var indexColumn = new Random().Next(matrix.GetLength(0));
                    for (int i = 0; i < word.Length; i++)
                    {
                        
                                matrix[index + i, indexColumn + i] = word[i].ToString();
                      
                    }
                }
                else
                {
                    var indexRow = new Random().Next(matrix.GetLength(0));
                    for (int i = 0; i < word.Length; i++)
                    {

                        matrix[indexRow + i, index + i] = word[i].ToString();

                    }
                }
            }

        }

        public int GetMatrixIndexToAddWord(int matrixLength, int wordLengh)
        {
            if (matrixLength < wordLengh)
                throw new InvalidOperationException($"The word provide is grater that the matrix length");

            var random = new Random();
            var index = random.Next(0, matrixLength - wordLengh);
            return index;
        }
    }
}
