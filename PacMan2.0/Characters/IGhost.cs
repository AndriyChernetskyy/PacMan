using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Interface;
using PacMan2._0.Map;

namespace PacMan2._0.Characters
{
    public interface IGhost : ICharacter, ISelfMovable
    {
        IMaze Map { get; set; }
        Position Position { get; set; }
        ConsoleColor Color { get; set; }
        Position GetCurrentPosition();

    }
}
