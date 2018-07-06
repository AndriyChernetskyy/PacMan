using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Map;
using PacMan2._0.Interface;

namespace PacMan2._0.Characters
{
    public interface IPacMan : IEatable, IMovable
    {
        IMaze Map { get; set; }
        Position Position { get; set; }
        ConsoleColor Color { get; set; }

    }
}
