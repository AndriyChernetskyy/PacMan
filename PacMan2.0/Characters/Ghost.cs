using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class Ghost : IGhost
    {
        private Position position;
        public string Symbol { get; set; } = "G";
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }

        public Ghost(ConsoleColor color, Position position)
        {
            Position = position;
            Color = color;
        }
        
        public async void Move(SidesToMove stm, IMaze map)
        {
            switch (stm)
            {
                case SidesToMove.Right:
                    if (map.Map[Position.Y, Position.X + 1] != map.Wall)
                    {
                        position.X++;
                    }
                    break;
                case SidesToMove.Left:
                    if (map.Map[Position.Y, Position.X - 1] != map.Wall)
                    {
                        position.X--;
                    }

                    break;
                case SidesToMove.Up:
                    if (map.Map[Position.Y - 1, Position.X] != map.Wall)
                    {
                        position.Y--;
                    }

                    break;
                case SidesToMove.Down:
                    if (map.Map[Position.Y + 1, Position.X] != map.Wall)
                    {
                        position.Y++;
                    }
                    break;
            }

        }



        
    }
}
