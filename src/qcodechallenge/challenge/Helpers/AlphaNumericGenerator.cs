using System;
using System.Linq;

namespace challenge.Helpers
{
    public class AlphaNumericGenerator
    {
        private readonly Random random;

        public AlphaNumericGenerator()
        {
            random = new Random();
        }
        /// <summary>
        /// Get Random char
        /// </summary>
        /// <returns></returns>
        public string RandomString()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 1)
              .Select(s => s[random.Next(chars.Length)]).ToArray());
        }
    }
}
