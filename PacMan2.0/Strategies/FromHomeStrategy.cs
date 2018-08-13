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
    public class FromHomeStrategy : IStrategy
    {
        public void StartStrategy(IAlgorythm algorythm, IPacMan pacMan, IMaze maze, IGhost ghost, Position start)
        {
            algorythm.From.X = ghost._position.X;
            algorythm.From.Y = ghost._position.Y;
            algorythm.To.X = start.X;
            algorythm.To.Y = start.Y;

            algorythm.Execute();
            List<Location> route = algorythm.ResultPath;

            foreach (var step in route.ToList())
            {

                if (ghost._position.X + 1 == step.X)
                {
                    ghost.direction = SidesToMove.Right;
                }

                if (ghost._position.X - 1 == step.X)
                {
                    ghost.direction = SidesToMove.Left;
                }

                if (ghost._position.Y - 1 == step.Y)
                {
                    ghost.direction = SidesToMove.Up;
                }

                if (ghost._position.Y + 1 == step.Y)
                {
                    ghost.direction = SidesToMove.Down;
                }
            }
            
        }
    }
}
