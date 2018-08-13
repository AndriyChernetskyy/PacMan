using System;
using System.Collections.Generic;
using System.Linq;
using PacMan2._0.Map;
using PacMan2._0.Characters;
using PacMan2._0.Algorythms;
//using PacMan2._0.Algorythms;

namespace PacMan2._0.AStarAlgotithm
{


    public class AStar : IAlgorythm
    {
        public List<Location> ResultPath { get; set; } = new List<Location>();
        public IGhost ghost;
        public IPacMan pacMan;
        public IMaze map;
        public Location From { get; set; } = new Location();
        public Location To { get; set; } = new Location();

        public AStar(IGhost ghost, IPacMan pacMan, IMaze map)
        {
            this.ghost = ghost;
            this.pacMan = pacMan;
            this.map = map;
        }

       

        public void Execute()
        {
            ResultPath.Clear();
            Location current = null;
            var start = new Location { X = From.X, Y = From.Y };
            var target = new Location { X = To.X, Y = To.Y };
            var openList = new List<Location>();
            var closedList = new List<Location>();
            int g = 0;

            openList.Add(start);
            while (openList.Count > 0)
            {
                // get the square with the lowest F score
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);

                // add the current square to the closed list
                closedList.Add(current);
                

                // remove it from the open list
                openList.Remove(current);

                // if we added the destination to the closed list, we've found a path
                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;

                var adjacentSquares = GetWalkableAdjacentSquares(current.X, current.Y, map.Map);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    // if this adjacent square is already in the closed list, ignore it
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) != null)
                        continue;

                    // if it's not in the open list...
                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X
                            && l.Y == adjacentSquare.Y) == null)
                    {
                        // compute its score, set the parent
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;

                        // and add it to the open list
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        // test if using the current G score makes the adjacent square's F score
                        // lower, if yes update the parent because it means it's a better path
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }

            // assume path was found; let's show it
            while (current != null)
            {
                ResultPath.Add(current);
                current = current.Parent;
            }

            // end
            
        }

        static List<Location> GetWalkableAdjacentSquares(int x, int y, string[,] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };

            return proposedLocations.Where(l => map[l.Y, l.X] != "1" && map[l.Y, l.X] != "7" && map[l.Y, l.X] != "8").ToList();
        }

        static int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}