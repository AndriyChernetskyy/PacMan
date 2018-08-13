using PacMan2._0.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0.Characters
{
    public interface ICharacter : IMovable
    {
        string ID { get; set; }
        SidesToMove direction { get; set; }
        Position _position { get; set; }
    }
}
