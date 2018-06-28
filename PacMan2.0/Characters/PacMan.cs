﻿using System;
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
        public IMaze Map { get; set; }
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }
        

        public PacMan(IMaze map, ConsoleColor color, Position position)
        {
            Map = map;
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public void Eat(List<IFood> foods, GUI gui)
        {
            foreach (var food in foods)
            {
                if (Map.Map[Position.Y, Position.X] == food.Symbol)
                {
                    gui.AddToScore(food);
                    Map.Map[Position.Y, Position.X] = " ";
                }
            }
            
        }

        
        

        public void GetDirection(ConsoleKey key, List<IFood> food, GUI gui)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Move(SidesToMove.Down);
                    Eat(food, gui);
                    break;
                case ConsoleKey.UpArrow:
                    Move(SidesToMove.Up);
                    Eat(food, gui);
                    break;
                case ConsoleKey.RightArrow:
                    Move(SidesToMove.Right);
                    Eat(food, gui);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(SidesToMove.Left);
                    Eat(food, gui);
                    break;
            }
            
        }

        public void Move(SidesToMove stm)
        {
            switch (stm)
            {
                case SidesToMove.Right:
                    if (Map.Map[Position.Y, Position.X + 1] != Map.Wall)
                    {
                        position.X++;
                    }
                    break;
                case SidesToMove.Left:
                    if (Map.Map[Position.Y, Position.X - 1] != Map.Wall)
                    {
                        position.X--;
                    }

                    break;
                case SidesToMove.Up:
                    if (Map.Map[Position.Y - 1, Position.X] != Map.Wall)
                    {
                        position.Y--;
                    }

                    break;
                case SidesToMove.Down:
                    if (Map.Map[Position.Y + 1, Position.X] != Map.Wall)
                    {
                        position.Y++;
                    }
                    break;
            }
            
        }
        
    }
}
