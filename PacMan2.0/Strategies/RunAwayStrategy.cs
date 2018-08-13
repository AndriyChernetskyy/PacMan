using PacMan2._0.Algorythms;
using PacMan2._0.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using PacMan2._0.Map;
using PacMan2._0.AStarAlgotithm;

namespace PacMan2._0.Strategies
{
    public class RunAwayStrategy : IStrategy
    {
        public void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position start)
        {
            algorythm.From.X = ghost._position.X;
            algorythm.From.Y = ghost._position.Y;
            algorythm.To.X = maze.BottomRightCorner.X;
            algorythm.To.Y = maze.BottomRightCorner.Y;
            algorythm.Execute();
            List<Location> rightCornerBottom = algorythm.ResultPath;

            foreach (var i in rightCornerBottom)
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
