using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class Ghost : GameEngine, IEatable
    {
        public string Symbol;
        public new Position Position { get; set; }
        public new ConsoleColor Color { get; set; }

        public Ghost(Position position, ConsoleColor color)
        {
            Position = position;
            Color = color;
        }

        public void Eat(Food food)
        {
            if (food == Food.PacMan)
            {
                GameOver();
            }
        }

        public void LookForPacMan()
        {

        }
    }
}
