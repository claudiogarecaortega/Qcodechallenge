using System;
using System.Collections.Generic;
using System.Linq;
using challenge.Models;

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
            if (rows > 64 || columns > 64)
                throw new Exception("the Matrix length can not be more than 64");

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

        /// <summary>
        /// Add list of words in Matrix
        /// </summary>
        /// <param name="wordsCollection">collection of words to be added</param>
        /// <param name="matrix"> Matrix to be updated</param>
        /// <returns></returns>
        public string[,] HideWordsCollection(IEnumerable<string> wordsCollection, string[,] matrix)
        {
            var values = Enum.GetValues(typeof(WordOrientation));
            var random = new Random();
            var wordsInsertedDictionary = new List<WordsInserted>();
           
            foreach (var word in wordsCollection)
            {
                var positions = new List<Positions>();
                var randomEnumValue = (WordOrientation)values.GetValue(random.Next(values.Length));
                var index = GetMatrixIndexToAddWord(matrix.GetLength(0), word.Length);
                var indexRow = new Random().Next(index);
                var indexColumn = new Random().Next(index);

                while (!CanBeInserted(word, index, randomEnumValue, wordsInsertedDictionary, indexRow, indexColumn))
                {
                    randomEnumValue = (WordOrientation)values.GetValue(random.Next(values.Length));
                    index = GetMatrixIndexToAddWord(matrix.GetLength(0), word.Length);
                    indexRow = new Random().Next(index);
                    indexColumn = new Random().Next(index);
                }
                
                if (randomEnumValue == WordOrientation.Horizontal)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                       matrix[index , indexColumn + i] = word[i].ToString().ToUpper();
                         positions.Add(new Positions()
                         {
                             Row = index,
                             Column = indexColumn + i,
                             Value = word[i].ToString().ToUpper()
                    });
                    }
                }
                else
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        matrix[indexRow + i, index ] = word[i].ToString().ToUpper();
                        positions.Add(new Positions()
                        {
                            Row = indexRow+ i,
                            Column = index,
                            Value = word[i].ToString().ToUpper()
                        });
                    }
                }
                wordsInsertedDictionary.Add(new WordsInserted(){Positions = positions, Word = word});
            }

            return matrix;
        }

        /// <summary>
        /// Get max index to be added the word
        /// </summary>
        /// <param name="matrixLength"></param>
        /// <param name="wordLengh"></param>
        /// <returns></returns>
        public int GetMatrixIndexToAddWord(int matrixLength, int wordLengh)
        {
            if (matrixLength < wordLengh)
                throw new InvalidOperationException($"The word provide is grater that the matrix length");

            var random = new Random();
            var maxLimit = matrixLength - wordLengh;
            var index = random.Next(0, maxLimit-1);
            return index;
        }
        /// <summary>
        /// check if the word can be inserted prevent override if some word has been added 
        /// </summary>
        /// <param name="word">word to try insert</param>
        /// <param name="index"></param>
        /// <param name="orientation"></param>
        /// <param name="wordsInsertedList"></param>
        /// <param name="indexRow"></param>
        /// <param name="indexColumn"></param>
        /// <returns></returns>
        private bool CanBeInserted(string word, int index, WordOrientation orientation, List<WordsInserted> wordsInsertedList, int indexRow, int indexColumn )
        {
            if (!wordsInsertedList.Any())
                return true;

            var positions = new List<Positions>();

            if (orientation == WordOrientation.Horizontal)
            {
                positions.AddRange(word.Select((t, i) => new Positions() {Row = index, Column = indexColumn + i, Value = t.ToString().ToUpper()}));
            }
            else
            {
                positions.AddRange(word.Select((t, i) => new Positions() {Row = indexRow + i, Column = index, Value = t.ToString().ToUpper()}));
            }

            foreach (var wordsInserted in wordsInsertedList)
            {
                foreach (var wordsInsertedPosition in wordsInserted.Positions)
                {
                    foreach (var position in positions.Where(position => position.Column == wordsInsertedPosition.Column &&
                                                                         position.Row == wordsInsertedPosition.Row))
                    {
                        return position.Value == wordsInsertedPosition.Value;
                    }
                }
            }

            return true;
        }
    }
}
