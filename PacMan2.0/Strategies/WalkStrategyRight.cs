using PacMan2._0.Algorythms;
using PacMan2._0.Characters;
using PacMan2._0.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan2._0.Strategies
{
    class WalkStrategyRight : IStrategy
    {
        public void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position start)
        {
            Random random = new Random();
            string dir = random.Next(1, 4).ToString();

            if (maze.Map[ghost._position.Y - 1, ghost._position.X] == maze.Wall && maze.Map[ghost._position.Y, ghost._position.X - 1] == maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Up)
                {
                    dir = "1";
                }
                if (ghost.prevDirection == SidesToMove.Left)
                {
                    dir = "4";
                }
            }

            if (maze.Map[ghost._position.Y + 1, ghost._position.X] == maze.Wall && maze.Map[ghost._position.Y, ghost._position.X - 1] == maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Down)
                {
                    dir = "1";
                }
                if (ghost.prevDirection == SidesToMove.Left)
                {
                    dir = "3";
                }
            }

            if (maze.Map[ghost._position.Y - 1, ghost._position.X] == maze.Wall && maze.Map[ghost._position.Y, ghost._position.X + 1] == maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Up)
                {
                    dir = "2";
                }

                if (ghost.prevDirection == SidesToMove.Right)
                {
                    dir = "4";
                }
            }

            if (maze.Map[ghost._position.Y + 1, ghost._position.X] == maze.Wall && maze.Map[ghost._position.Y, ghost._position.X + 1] == maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Down)
                {
                    dir = "2";
                }
                if (ghost.prevDirection == SidesToMove.Right)
                {
                    dir = "3";
                }
            }


            if (maze.Map[ghost._position.Y - 1, ghost._position.X] != maze.Wall && maze.Map[ghost._position.Y, ghost._position.X + 1] != maze.Wall && maze.Map[ghost._position.Y, ghost._position.X - 1] != maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Left)
                {
                    dir = "3";
                }
                if (ghost.prevDirection == SidesToMove.Right)
                {
                    dir = "4";
                }
            }
            if (maze.Map[ghost._position.Y - 1, ghost._position.X] != maze.Wall && maze.Map[ghost._position.Y + 1, ghost._position.X] != maze.Wall && maze.Map[ghost._position.Y, ghost._position.X - 1] != maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Right)
                {
                    dir = "4";
                }
                if (ghost.prevDirection == SidesToMove.Down)
                {
                    dir = "2";
                }
            }

            if (maze.Map[ghost._position.Y, ghost._position.X + 1] != maze.Wall && maze.Map[ghost._position.Y + 1, ghost._position.X] != maze.Wall && maze.Map[ghost._position.Y, ghost._position.X - 1] != maze.Wall)
            {
                if (ghost.prevDirection == SidesToMove.Up)
                {
                    dir = "1";
                }
            }

            switch (dir)
            {
                case "1":
                    if (maze.Map[ghost._position.Y, ghost._position.X + 1] != maze.Wall)
                    {
                        if (ghost.prevDirection != SidesToMove.Left)
                        {
                            ghost.direction = SidesToMove.Right;
                        }
                    }
                    break;
                case "2":
                    if (maze.Map[ghost._position.Y, ghost._position.X - 1] != maze.Wall)
                    {
                        if (ghost.prevDirection != SidesToMove.Right)
                        {
                            ghost.direction = SidesToMove.Left;
                        }
                    }
                    break;
                case "3":
                    if (maze.Map[ghost._position.Y - 1, ghost._position.X] != maze.Wall)
                    {
                        if (ghost.prevDirection != SidesToMove.Down)
                        {
                            ghost.direction = SidesToMove.Up;
                        }
                    }
                    break;
                case "4":
                    if (maze.Map[ghost._position.Y + 1, ghost._position.X] != maze.Wall)
                    {
                        if (ghost.prevDirection != SidesToMove.Up)
                        {
                            ghost.direction = SidesToMove.Down;
                        }
                    }
                    break;
            }
        }
    }
}
