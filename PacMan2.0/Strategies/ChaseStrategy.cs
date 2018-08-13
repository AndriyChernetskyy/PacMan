using PacMan2._0.Algorythms;
using PacMan2._0.AStarAlgotithm;
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
    public class ChaseStrategy : IStrategy
    {
        public void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position Start)
        {
            algorythm.From.X = ghost._position.X;
            algorythm.From.Y = ghost._position.Y;
            algorythm.To.X = pacMan._position.X;
            algorythm.To.Y = pacMan._position.Y;

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
