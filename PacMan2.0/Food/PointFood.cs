using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PacMan2._0.Actions;
using PacMan2._0.Characters;

namespace PacMan2._0.Food
{
    public sealed class PointFood : IFood
    {
        public string Symbol { get; set; } = "2";

        public int GetScore() => 10;

    }
}
