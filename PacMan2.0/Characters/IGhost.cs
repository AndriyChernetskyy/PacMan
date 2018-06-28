using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Interface;

namespace PacMan2._0
{
    public interface IGhost : ICharacter, ISelfMovable
    {
        IMaze Map { get; set; }
        Position Position { get; set; }
        ConsoleColor Color { get; set; }

        
    }
}
