using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Interface;
using PacMan2._0.Map;
using PacMan2._0.VisitorPattern;

namespace PacMan2._0.Characters
{
    public interface IGhost : ICharacter, ISelfMovable
    {
        IMaze Map { get; set; }
        Position Position { get; set; }
        Position GetCurrentPosition();
        void Scared(IPacMan pacMan);
        Position Accept(Visitor visitor);
    }
}
