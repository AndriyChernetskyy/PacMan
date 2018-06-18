using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PacMan
{
    public class PacMan : IPacMan
    {
        public Position pacManPos;

        public Ghost[] ghosts;

        public Tuple<int, int> currentPosition => new Tuple<int, int>(pacManPos.X, pacManPos.Y);
        
        public int Score { get; set; }

        public int Lives { get; set; }

        public int Level { get; set; }

        private string symbol = ((char)9786).ToString();

        public string Symbol { get => symbol; }

        public string Color { get; set; }
        

        

        public string Direction = "right";
        public string nextStep = "right";

        public PacMan()
        {
            pacManPos = new Position(17, 20);
            Score = 0;
            Level = 1;
            Lives = 3;
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
            this.Lives++;
        }




        public void Eat(GameState score)
        {
            this.Score += score.Score;
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
            this.Level++;
            this.Score = 0;
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
                            return new SimpleFood();
                            
                        case "*":
                            return new Energizer();
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
                            return new SimpleFood();
                        case "*":
                            return new Energizer();
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
                            return new SimpleFood();
                        case "*":
                            return new Energizer();
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
