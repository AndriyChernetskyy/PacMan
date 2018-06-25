using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class PacMan : IPacMan
    {
        public readonly string Symbol = "P";

        public Position position;
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }
        

        public PacMan(ConsoleColor color, Position position)
        {
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public void Eat(IMaze map, List<IFood> foods, GUI gui)
        {
            foreach (var food in foods)
            {
                if (map.Map[Position.Y, Position.X] == food.Symbol)
                {
                    gui.AddToScore(food);
                    map.Map[Position.Y, Position.X] = " ";
                }
            }
            
        }

        
        

        public void GetDirection(ConsoleKey key, IMaze map, List<IFood> food, GUI gui)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Move(SidesToMove.Down, map);
                    Eat(map, food, gui);
                    break;
                case ConsoleKey.UpArrow:
                    Move(SidesToMove.Up, map);
                    Eat(map, food, gui);
                    break;
                case ConsoleKey.RightArrow:
                    Move(SidesToMove.Right, map);
                    Eat(map, food, gui);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(SidesToMove.Left, map);
                    Eat(map, food, gui);
                    break;
            }
            
        }

        public void Move(SidesToMove stm, IMaze map)
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
