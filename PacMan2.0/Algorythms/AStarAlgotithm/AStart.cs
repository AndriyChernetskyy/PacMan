using System;
using System.Collections.Generic;
using System.Linq;
using PacMan2._0.Map;
using PacMan2._0.Characters;
using PacMan2._0.Algorythms;

namespace PacMan2._0.AStarAlgotithm
{


    public class AStar : IAlgorythm
    {
        public Location current { get; set; }
        public Location start { get; set; }
        public Location target { get; set; }
        public List<Location> openList { get; set; }
        public List<Location> closedList { get; set; }
        public int g = 0;
        public List<Location> ResultPath { get; set; }

        
        public void Execute(IGhost ghost, IPacMan pacMan, IMaze map)
        {
         
            if (pacMan.Position.X != target.X || pacMan.Position.Y != target.Y)
            {
                

                ResultPath.Clear();
                current = null;
                openList.Clear();
                closedList.Clear();
                g = 0;
                
                target.X = pacMan.Position.X;
                target.Y = pacMan.Position.Y;
                start.X = ghost.Position.X;
                start.Y = ghost.Position.Y;

            }

            openList.Add(start);

            while (openList.Count > 0)
            {
                var lowest = openList.Min(l => l.F);
                current = openList.First(l => l.F == lowest);
                closedList.Add(current);
                openList.Remove(current);
                if (closedList.FirstOrDefault(l => l.X == target.X && l.Y == target.Y) != null)
                    break;
                var adjacentSquares
                    = GetWalkableAdjacentSquares(current.X, current.Y, map.Map);
                g++;

                foreach (var adjacentSquare in adjacentSquares)
                {
                    if (closedList.FirstOrDefault(l => l.X == adjacentSquare.X
                                                       && l.Y == adjacentSquare.Y) != null)
                        continue;

                    if (openList.FirstOrDefault(l => l.X == adjacentSquare.X
                                                     && l.Y == adjacentSquare.Y) == null)
                    {
                        adjacentSquare.G = g;
                        adjacentSquare.H = ComputeHScore(adjacentSquare.X, adjacentSquare.Y, target.X, target.Y);
                        adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                        adjacentSquare.Parent = current;
                        openList.Insert(0, adjacentSquare);
                    }
                    else
                    {
                        if (g + adjacentSquare.H < adjacentSquare.F)
                        {
                            adjacentSquare.G = g;
                            adjacentSquare.F = adjacentSquare.G + adjacentSquare.H;
                            adjacentSquare.Parent = current;
                        }
                    }
                }
            }


                while (current != null)
                {

                    if (pacMan.Position.X == target.X || pacMan.Position.Y == target.Y)
                    {
                        ResultPath.Add(current);
                        current = current.Parent;
                    }
                    else
                    {
                        break;
                    }
                }

            ResultPath.Reverse();


        }

        public List<Location> GetWalkableAdjacentSquares(int x, int y, string[,] map)
        {
            var proposedLocations = new List<Location>()
            {
                new Location { X = x, Y = y - 1 },
                new Location { X = x, Y = y + 1 },
                new Location { X = x - 1, Y = y },
                new Location { X = x + 1, Y = y },
            };

            return proposedLocations.Where(l => map[l.Y, l.X] == " " || map[l.Y, l.X] == "B").ToList();
        }

        public int ComputeHScore(int x, int y, int targetX, int targetY)
        {
            return Math.Abs(targetX - x) + Math.Abs(targetY - y);
        }
    }
}
