using PacMan2._0.Algorythms;
using PacMan2._0.Characters;
using PacMan2._0.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using PacMan2._0.Map;

namespace PacMan2._0.Strategies
{
    public interface IStrategy
    {
        void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position start);
    }
}
