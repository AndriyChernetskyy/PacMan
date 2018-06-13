using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Ghost :  IMove
    {
        public Position ghostPos;


        private int prevPosX;
        private int prevPosY;

        public Tuple<int, int> CurrentPosition => Tuple.Create<int, int>(ghostPos.X, ghostPos.Y);       
        public int PrevPosX { get { return prevPosX; } set { value = this.prevPosX; } }
        public int PrevPosY { get { return prevPosY; } set { value = this.prevPosY; } }

        private string symbol = ((char)9787).ToString();

        public string Symbol { get => symbol; }
       
        private Color color;
        public string Color { get => color; }
        public string Direction = "up";
        

        public void EraseGhost()
        {
            Console.SetCursorPosition(prevPosX, prevPosY);
            Console.Write(' ');
        }

        public void moveRight()
        {
            if(ghostPos.X + 1 < 34)
            {
                prevPosX = ghostPos.X;
                prevPosY = ghostPos.Y;
                ghostPos.X++;
            }
        }

        public Ghost() { }

        public void moveLeft()
        {
            if(ghostPos.X - 1 > 0)
            {
                prevPosY = ghostPos.Y;
                prevPosX = ghostPos.X;
                ghostPos.X--;
            }
        }

        public void moveUp()
        {
            if(ghostPos.Y - 1 < 28)
            {
                prevPosX = ghostPos.X;
                prevPosY = ghostPos.Y;
                ghostPos.Y++;
            }
        }

        public void moveDown()
        {
            if(ghostPos.Y + 1 > 0)
            {
                prevPosY = ghostPos.Y;
                prevPosX = ghostPos.X;
                ghostPos.Y--;
            }
        }



        public static string[] possibleDirections =
        {
            "up",
            "down",
            "left",
            "right"
        };

        public static Random random = new Random();

        public Ghost (string color, int x, int y)
        {
            this.color = color;
            ghostPos = new Position(x, y);
            this.prevPosX = x;
            this.prevPosY = y;
        }


        public bool isFrightened;
        

        public bool LeftAvalibility(List<Ghost> ghostList, int x, int y, string[,] border)
        {
            bool isEmpty = true;
            foreach (var ghost in ghostList)
            {
                if(ghost.CurrentPosition.Item1.Equals(x - 1) && ghost.CurrentPosition.Item2.Equals(y))
                {
                    isEmpty = false;
                    break;
                }
            }
            if(border[y, x - 1] == "#")
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        public bool RightAvalibility(List<Ghost> ghostList, int x, int y, string[,] border)
        {
            bool isEmpty = true;
            foreach(var ghost in ghostList)
            {
                if(ghost.CurrentPosition.Item1.Equals(x + 1) && ghost.CurrentPosition.Item2.Equals(y))
                {
                    isEmpty = false;
                    break;
                }
            }
            if (border[y, x + 1] == "#")
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        public bool UpAvalibility(List<Ghost> ghostList, int x, int y, string[,] border)
        {
            bool isEmpty = true;
            foreach(var ghost in ghostList)
            {
                if(ghost.CurrentPosition.Item1.Equals(x) && ghost.CurrentPosition.Item2.Equals(y - 1))
                {
                    isEmpty = false;
                    break;
                }
            }
            if(border[y - 1, x] == "#")
            {
                isEmpty = false;
            }
            return isEmpty;
        }

        public bool DownAvalibility(List<Ghost> ghostList, int x, int y, string[,] border)
        {
            bool isEmpty = true;
            foreach(var ghost in ghostList)
            {
                if(ghost.CurrentPosition.Item1.Equals(x) && ghost.CurrentPosition.Item2.Equals(y + 1))
                {
                    isEmpty = false;
                    break;
                }
            }
            if(border[y + 1, x] == "#")
            {
                isEmpty = false;
            }
            return isEmpty;
        }
    }
}
