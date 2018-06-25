using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public sealed class Cherry : IFood
    {
        public string Symbol { get; set; } = "C";
        
        
        public int GetScore() => 100;

        
    }
}
