using System;
using System.Collections.Generic;
using PacMan2._0.Actions;
using PacMan2._0.Food;
using PacMan2._0.VisitorPattern;
using PacMan2._0.Map;



namespace PacMan2._0.Characters
{
    public class PacMan : Element, IPacMan
    {
        public string symbol = "P";
        public Position position;
        public new string Symbol
        {
            get => this.symbol;
            set => this.symbol = value;
        }
        public IMaze Map { get; set; }
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }
        

        public PacMan(IMaze map, ConsoleColor color, Position position)
        {
            Map = map;
            Color = ConsoleColor.Yellow;
            Position = position;
        }

        public override Position Accept(Visitor visitor)
        {
            return visitor.VisitElementA(this);
        }


        public void Eat(List<IFood> foods, GUI gui, Ghost ghost)
        {
            foreach (var food in foods)
            {
                if (Map.Map[Position.Y, Position.X] == food.Symbol)
                {
                    gui.AddToScore(food);
                    if (food is Energizer)
                    {
                        ((Energizer)food).MakeGhostScared(ghost, this);
                    }
                    Map.Map[Position.Y, Position.X] = " ";
                }
            }
            
        }

        
        

        public void GetDirection(ConsoleKey key, List<IFood> food, GUI gui, Ghost ghost)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    Move(SidesToMove.Down);
                    Eat(food, gui, ghost);
                    break;
                case ConsoleKey.UpArrow:
                    Move(SidesToMove.Up);
                    Eat(food, gui, ghost);
                    break;
                case ConsoleKey.RightArrow:
                    Move(SidesToMove.Right);
                    Eat(food, gui, ghost);
                    break;
                case ConsoleKey.LeftArrow:
                    Move(SidesToMove.Left);
                    Eat(food, gui, ghost);
                    break;
            }

        }

        public Position GetCurrentPosition() => this.position;
        



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
