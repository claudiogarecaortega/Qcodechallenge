using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.Helpers
{
    public class WordFinder
    {
        private readonly string[,] _matrix;

        public WordFinder(string[,] matrix)
        {
            this._matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordsToFind)
        {
            var foundWords = new List<string>();
            foreach (var word in wordsToFind)
            {
                if(FindHorizontal(word))
                    foundWords.Add(word);
                if(FindVertical(word))
                    foundWords.Add(word);
                
            }

            return foundWords;
        }

        private bool FindHorizontal(string word)
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (_matrix[i, j].ToLower() == word[0].ToString().ToLower())
                    {
                        var auxWord = word[0].ToString();
                        for (int k = 1; k < word.Length; k++)
                        {
                            if(j+k < _matrix.GetLength(0)) 
                                auxWord += _matrix[i, j + k];
                        }

                        if (auxWord.ToLower() == word.ToLower())
                            return true;
                    }
                }
            }

            return false;
        }

        private bool FindVertical(string word)
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(0); j++)
                {
                    if (_matrix[i, j].ToLower() == word[0].ToString().ToLower())
                    {
                        var auxWord = word[0].ToString();
                        for (int k = 1; k < word.Length; k++)
                        {
                            if (i + k < _matrix.GetLength(0))
                                auxWord += _matrix[i+k, j ];
                        }

                        if (auxWord.ToLower() == word.ToLower())
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
