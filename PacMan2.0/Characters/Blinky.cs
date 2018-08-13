using System;
using PacMan2._0.Map;
using System.Timers;
using PacMan2._0.AStarAlgotithm;
using System.Collections.Generic;
using PacMan2._0.Enums;
using PacMan2._0.Strategies;
using System.Threading.Tasks;
using PacMan2._0.Actions;

namespace PacMan2._0.Characters
{
    public class Blinky :  Ghost
    {

        public Blinky(PacMan pacman, IMaze map, Position position) : base(pacman, map, position)
        {
            aStar = new AStar(this, pacman, map);
            this.pacman = pacman;
            Map = map;
            this.position = position;
        }

        public override void Reset()
        {
            modeStatus = GhostStatus.FirstStepInAGame;
            position.X = 10;
            position.Y = 11;
        }
        
        public override void Move(SidesToMove dir)
        {

            switch (dir)
            {
                case SidesToMove.Right:
                    if (Map.Map[position.Y, position.X + 1] != Map.Wall)
                    {
                        if (Map.Map[position.Y, position.X + 1] == Map.PortalRight)
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/blinky/right.png";
                            }
                            else
                            {
                                ID = "images/ghosts/scared.png";
                            }
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X = Map.PortalLeftPos.X;
                            position.Y = Map.PortalLeftPos.Y;
                            position.X++;
                        }
                        else
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/blinky/right.png";
                            }
                            else
                            {
                                ID = "images/ghosts/scared.png";
                            }
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            prevDirection = SidesToMove.Right;
                            position.X++;
                        }

                    }


                    break;
                case SidesToMove.Left:
                    if (Map.Map[position.Y, position.X - 1] != Map.Wall)
                    {
                        if (Map.Map[position.Y, position.X - 1] == Map.PortalLeft)
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/blinky/left.png";
                            }
                            else
                            {
                                ID = "images/ghosts/scared.png";
                            }
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X = Map.PortalRightPos.X;
                            position.Y = Map.PortalRightPos.Y;
                            position.X--;
                        }
                        else
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/blinky/left.png";
                            }
                            else
                            {
                                ID = "images/ghosts/scared.png";
                            }
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            prevDirection = SidesToMove.Left;
                            position.X--;
                        }
                    }

                    break;
                case SidesToMove.Up:
                    if (Map.Map[position.Y - 1, position.X] != Map.Wall)
                    {
                        if (modeStatus != GhostStatus.Frightened)
                        {
                            ID = "images/ghosts/blinky/up.png";
                        }
                        else
                        {
                            ID = "images/ghosts/scared.png";
                        }
                        previousPosition.X = position.X;
                        previousPosition.Y = position.Y;
                        prevDirection = SidesToMove.Up;
                        position.Y--;
                    }
                    break;
                case SidesToMove.Down:
                    if (Map.Map[position.Y + 1, position.X] != Map.Wall)
                    {

                        if (modeStatus != GhostStatus.Frightened)
                        {
                            ID = "images/ghosts/blinky/down.png";
                        }
                        else
                        {
                            ID = "images/ghosts/scared.png";
                        }
                        previousPosition.X = position.X;
                        previousPosition.Y = position.Y;
                        prevDirection = SidesToMove.Down;
                        position.Y++;
                    }
                    break;
            }


            if (position.X == Map.StartPointBlinky.X && position.Y == Map.StartPointBlinky.Y && modeStatus == GhostStatus.FirstStepInAGame)
            {
                modeStatus = GhostStatus.Walking;
            }

            if (modeStatus == GhostStatus.Chase)
            {
                Strategy = new ChaseStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointBlinky);
            }
            if (modeStatus == GhostStatus.Walking)
            {
                Strategy = new WalkStrategyRight();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointBlinky);
            }
            if (modeStatus == GhostStatus.Frightened)
            {
                Strategy = new WalkStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointBlinky);
            }
            if (modeStatus == GhostStatus.FirstStepInAGame)
            {
                Strategy = new FromHomeStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointBlinky);
            }
        }
    }
}
