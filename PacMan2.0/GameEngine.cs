using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class GameEngine : IMovable
    {
        public ConsoleColor Color { get; set; }
        public Position Position { get; set; }
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Level { get; set; }

        public GameEngine()
        {
            this.Level = 1;
            this.Lives = 3;
            this.Score = 0;
        }

        public void GameOver()
        {
            Lives--;
        }

        public void GetDirection(ConsoleKey key)
        {
            if (key == ConsoleKey.DownArrow)
            {
                Move(SidesToMove.Down);
            }

            if (key == ConsoleKey.UpArrow)
            {
                Move(SidesToMove.Up);
            }

            if (key == ConsoleKey.LeftArrow)
            {
                Move(SidesToMove.Left);
            }

            if (key == ConsoleKey.RightArrow)
            {
                Move(SidesToMove.Right);
            }
        }


        public void Move(SidesToMove stm)
        {
            if (stm == SidesToMove.Right)
            {
                this.Position.X++;
            }
            else if (stm == SidesToMove.Left)
            {
                this.Position.X--;
            }
            else if(stm == SidesToMove.Up)
            {
                this.Position.Y--;
            }
            else
            {
                this.Position.Y++;
            }
        }
    }
}
    

