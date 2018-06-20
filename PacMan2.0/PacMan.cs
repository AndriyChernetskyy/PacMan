using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class PacMan : GameEngine, IEatable, IMovable
    {
        public readonly string Symbol = "P";

        //public new Position Position { get; set; }
        //public new ConsoleColor Color { get; set; }


        public PacMan(ConsoleColor color, Position position)
        {
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public bool CanMoveRight(Maze map) 
        {
            return map.Map[Position.Y, Position.X + 1] != "#";
        
        }

        public bool CanMoveLeft(Maze map)
        {
            return map.Map[Position.Y, Position.X - 1] != "#";
            
        }

        public bool CanMoveDown(Maze map)
        {
            return map.Map[Position.Y+1, Position.X] != "#";
        }

        public bool CanMoveUp(Maze map)
        {
            return map.Map[Position.Y-1, Position.X] != "#";
            
        }

        public void GetDirection(ConsoleKey key, Maze map)
        {
            if (key == ConsoleKey.DownArrow)
            {
                Move(SidesToMove.Down, map);
            }

            if (key == ConsoleKey.UpArrow)
            {
                Move(SidesToMove.Up, map);
            }

            if (key == ConsoleKey.LeftArrow)
            {
                Move(SidesToMove.Left, map);
            }

            if (key == ConsoleKey.RightArrow)
            {
                Move(SidesToMove.Right, map);
            }

        }

        public void Move(SidesToMove stm, Maze map)
        {
            if (stm == SidesToMove.Right)
            {
                if (CanMoveRight(map))
                {
                    this.Position.X++;
                }
            }
            else if (stm == SidesToMove.Left)
            {
                if (CanMoveLeft(map))
                {
                    this.Position.X--;
                }
            }
            else if (stm == SidesToMove.Up)
            {
                if (CanMoveUp(map))
                {
                    this.Position.Y--;
                }
            }
            else if(stm == SidesToMove.Down)
            {
                if (CanMoveDown(map))
                {
                    this.Position.Y++;
                }
            }
        }

        public void Eat(Food food)
        {
            switch (food)
            {
                case Food.PointFood:
                    this.Score++;
                    break;
                case Food.Cherry:
                    this.Score += 100;
                    break;
                case Food.Energizer:
                    this.Score += 50;
                    break;
                case Food.Ghost:
                    this.Score += 200;
                    break;
            }
        }


    }
}
