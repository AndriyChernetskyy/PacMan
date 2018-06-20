using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public sealed class Energizer : GameEngine, IAction
    {
        public int GetScore() => Score += 50;
    }
}
