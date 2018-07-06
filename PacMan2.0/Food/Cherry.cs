using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Actions;
using PacMan2._0.Characters;

namespace PacMan2._0.Food
{
    public sealed class Cherry : IFood
    {
        public string Symbol { get; set; } = "C";
        
        
        public int GetScore() => 100;

   

    }
}
