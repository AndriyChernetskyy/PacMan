using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public sealed class Cherry : IFood
    {
        private string symbol = "C";

        public string GetSymbol()
        {
            return symbol;
        }

        public void SetSymbol(string value)
        {
            symbol = value;
        }

        public int GetScore() => 100;

        
    }
}
