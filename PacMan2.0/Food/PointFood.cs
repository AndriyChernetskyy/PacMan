using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public sealed class PointFood : IFood
    {
        public string Symbol { get; set; } = ".";

        public int GetScore() => 1;

        
    }
}
