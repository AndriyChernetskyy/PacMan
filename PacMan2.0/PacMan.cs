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

        public Position Position { get; set; }
        public ConsoleColor Color { get; set; }
        

        public PacMan(ConsoleColor color, Position position)
        {
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public void Eat(IMaze map, IFood food)
        {
            if (map.Map[Position.Y, Position.X] == food.Symbol)
            {
                map.Map[Position.Y, Position.X] = " ";
            } 
        }

        /*public void Eat(IFood food)
        {
            food.GetScore();
        }
        */
        

        public bool CanMoveRight(IMaze map) => map.Map[Position.Y, Position.X + 1] != "#";
        public bool CanMoveLeft(IMaze map) => map.Map[Position.Y, Position.X - 1] != "#";
        public bool CanMoveDown(IMaze map) => map.Map[Position.Y+1, Position.X] != "#";
        public bool CanMoveUp(IMaze map) => map.Map[Position.Y-1, Position.X] != "#";
         

        public void GetDirection(ConsoleKey key, IMaze map, IFood food)
        {
            if (key == ConsoleKey.DownArrow)
            {
                Move(SidesToMove.Down, map);
                Eat(map, food);
            }

            if (key == ConsoleKey.UpArrow)
            {
                Move(SidesToMove.Up, map);
                Eat(map, food);
            }

            if (key == ConsoleKey.LeftArrow)
            {
                Move(SidesToMove.Left, map);
                Eat(map, food);
            }

            if (key == ConsoleKey.RightArrow)
            {
                Move(SidesToMove.Right, map);
                Eat(map, food);
            }

        }

        public void Move(SidesToMove stm, IMaze map)
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

        /*public void Eat(Food food)
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
        }*/


    }
}
