using PacMan2._0.Algorythms;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Characters;
using PacMan2._0.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace PacMan2._0.Strategies
{
    class InkyChaseStrategy : IStrategy
    {
        public void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position Start)
        {
            algorythm.From.X = ghost._position.X;
            algorythm.From.Y = ghost._position.Y;
            if (pacMan.direction == SidesToMove.Down)
            {
                algorythm.To.X = pacMan._position.X + 2;
                algorythm.To.Y = pacMan._position.Y - 2;
            }
            if (pacMan.direction == SidesToMove.Up)
            {
                algorythm.To.X = pacMan._position.X + 2;
                algorythm.To.Y = pacMan._position.Y + 2;
            }
            if (pacMan.direction == SidesToMove.Left)
            {
                algorythm.To.X = pacMan._position.X - 2;
                algorythm.To.Y = pacMan._position.Y - 2;
            }
            if (pacMan.direction == SidesToMove.Right)
            {
                algorythm.To.X = pacMan._position.X + 2;
                algorythm.To.Y = pacMan._position.Y - 2;
            }


            algorythm.Execute();
            List<Location> dir = algorythm.ResultPath;
            foreach (var i in dir.ToList())
            {
                if (i != null)
                {
                    if (ghost._position.X + 1 == i.X)
                    {
                        ghost.direction = SidesToMove.Right;
                    }

                    else if (ghost._position.X - 1 == i.X)
                    {
                        ghost.direction = SidesToMove.Left;
                    }

                    else if (ghost._position.Y - 1 == i.Y)
                    {
                        ghost.direction = SidesToMove.Up;
                    }

                    else if (ghost._position.Y + 1 == i.Y)
                    {
                        ghost.direction = SidesToMove.Down;
                    }
                }
            }
        }
    }
}
