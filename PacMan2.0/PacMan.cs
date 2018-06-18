using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class PacMan : GameEngine, IEatable
    {
        public readonly string Symbol = "P";

        //public new Position Position { get; set; }
        //public new ConsoleColor Color { get; set; }


        public PacMan(ConsoleColor color, Position position)
        {
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public void Eat(Food food)
        {
            if (food == Food.PointFood)
            {
                this.Score++;
            }

            if (food == Food.Cherry)
            {
                this.Score += 100;
            }

            if (food == Food.Energizer)
            {
                this.Score += 50;
            }

            if (food == Food.Ghost)
            {
                this.Score += 200;
            }
        }


    }
}
