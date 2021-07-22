using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class WordsInserted
    {
        public string Word { get; set; }
        public IEnumerable<Positions> Positions { get; set; }
    }

    public class Positions
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Value { get; set; }
    }
}
