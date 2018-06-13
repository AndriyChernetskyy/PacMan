using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    public class PacMan : IMove, IEatable
    {
        public Position pacManPos;

        public Ghost[] ghosts;

        public Tuple<int, int> currentPosition => new Tuple<int, int>(pacManPos.X, pacManPos.Y);

        private int score;
        
        public int Score { get; protected set; }

        private int lives;

        public int Lives { get { return this.lives; } }

        private int level;

        public int Level { get { return this.level; } }

        private string symbol = ((char)9786).ToString();

        public string Symbol { get => symbol; }

        private string color = "Yellow";

        public string Color
        {
            get
            {
                return color;
            }
            
        }
        

        public string Direction = "right";
        public string nextStep = "right";

        public PacMan()
        {
            pacManPos = new Position(17, 20);
            score = 0;
            level = 1;
            lives = 3;
        }

        public void Reset()
        {
            this.pacManPos.X = 17;
            this.pacManPos.Y = 20;
            this.Direction = "right";
            this.nextStep = "right";
        }

        public void PacManDead()
        {
            this.lives++;
        }




        public void Eat(ItemsToEat item)
        {
            this.score += item;
        }
        /*
        public void Eat(ItemsToEat food)
        {
            if(food == ItemsToEat.SimpleFood)
            {
                this.score++;
            }

            if(food == ItemsToEat.Energizer)
            {
                this.score += 50;
            }

            if(food == ItemsToEat.Cherry)
            {
                this.score += 100;
                foreach (Ghost ghost in ghosts)
                {
                    ghost.Frightened();
                }
            }

            if(food == ItemsToEat.Ghost)
            {
                this.score += 200;
            }
        }
        
        */




        public void LevelUp()
        {
            this.level++;
            this.score = 0;
        }

        public Object CheckCell(string[,] border, string direction, List<Ghost> ghostList)
        {
            switch (direction)
            {
                case "up":
                    switch(border[this.pacManPos.Y - 1, this.pacManPos.X])
                    {
                        case "#":
                            return MazeElements.Wall;
                        case ".":
                            return ItemsToEat.SimpleFood;
                        case "*":
                            return ItemsToEat.Energizer;
                        default:
                            if (Collision(ghostList, this.pacManPos.Y - 1, this.pacManPos.X))
                            {
                                return MazeElements.Ghost;
                            }
                            else
                            {
                                return MazeElements.Empty;
                            }
                    }
                case "down":
                    switch (border[this.pacManPos.Y + 1, this.pacManPos.X])
                    {
                        case "#":
                            return MazeElements.Wall;
                        case ".":
                            return ItemsToEat.SimpleFood;
                        case "*":
                            return ItemsToEat.Energizer;
                        default:
                            if (Collision(ghostList, this.pacManPos.Y + 1, this.pacManPos.X))
                            {
                                return MazeElements.Ghost;
                            }
                            else
                            {
                                return MazeElements.Empty;
                            }
                    }
                case "left":
                    switch (border[this.pacManPos.Y, this.pacManPos.X - 1])
                    {
                        case "#":
                            return MazeElements.Wall;
                        case ".":
                            return ItemsToEat.SimpleFood;
                        case "*":
                            return ItemsToEat.Energizer;
                        default:
                            if (Collision(ghostList, this.pacManPos.Y, this.pacManPos.X - 1))
                            {
                                return MazeElements.Ghost;
                            }
                            else
                            {
                                return MazeElements.Empty;
                            }
                    }
                default:
                    if (Collision(ghostList, this.pacManPos.Y, this.pacManPos.X))
                    {
                        return MazeElements.Ghost;
                    }
                    else
                    {
                        return MazeElements.Empty;
                    }

            }
        }

        public void moveRight()
        {
            this.pacManPos.X++;
        }

        public void moveLeft()
        {
            this.pacManPos.X--;
        }

        public void moveUp()
        {
            this.pacManPos.Y--;
        }

        public void moveDown()
        {
            this.pacManPos.Y++;
        }


        public bool Collision(List<Ghost> ghostList, int pacManPosY, int pacManPosX)
        {
            foreach (var ghost in ghostList)
            {
                if (ghost.CurrentPosition.Item1.Equals(pacManPosX) && ghost.CurrentPosition.Item2.Equals(pacManPosY))
                {
                    return true;
                    
                }

            }

            return false;
        }


    }
}
