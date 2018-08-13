using PacMan2._0.Actions;
using PacMan2._0.Algorythms;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Enums;
using PacMan2._0.Interface;
using PacMan2._0.Map;
using PacMan2._0.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan2._0.Characters
{
    public class Clyde : Ghost
    {
        public new int countToExit { get; set; } = 1;

        public Clyde(PacMan pacman, IMaze map, Position position) : base(pacman, map, position)
        {
            aStar = new AStar(this, pacman, map);
            this.pacman = pacman;
            Map = map;
            this.position = position;
        }

        public override void Reset()
        {
            modeStatus = GhostStatus.FirstStepInAGame;
            position.X = 11;
            position.Y = 15;
        }
        
        public override async void Move(SidesToMove direction)
        {
            if (countToExit == 1)
            {
                await Task.Delay(3000);
                ++countToExit;
            }
            switch (direction)
            {
                case SidesToMove.Right:
                    if (Map.Map[position.Y, position.X + 1] != Map.Wall)
                    {
                        if (Map.Map[position.Y, position.X + 1] == Map.PortalRight)
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/clyde/right.png";
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
                                ID = "images/ghosts/clyde/right.png";
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
                                ID = "images/ghosts/clyde/left.png";
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
                                ID = "images/ghosts/clyde/left.png";
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
                            ID = "images/ghosts/clyde/up.png";
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
                            ID = "images/ghosts/clyde/down.png";
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

            
            if (position.X == Map.StartPointClyde.X && position.Y == Map.StartPointClyde.Y && modeStatus == GhostStatus.FirstStepInAGame)
            {
                modeStatus = GhostStatus.Walking;
            }



            if (modeStatus == GhostStatus.Chase)
            {
                if (Math.Sqrt(((pacman.position.X - position.X) * (pacman.position.X - position.X)) + ((pacman.position.Y - position.Y) * (pacman.position.Y - position.Y))) > 9)
                {
                    Strategy = new ChaseStrategy();
                    Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointClyde);
                }
                else
                {
                    modeStatus = GhostStatus.FirstStepInAGame;
                }
            }
            if (modeStatus == GhostStatus.Walking)
            {
                Strategy = new WalkStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointClyde);
            }
            if (modeStatus == GhostStatus.Frightened)
            {
                Strategy = new WalkStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointClyde);
            }
            if (modeStatus == GhostStatus.FirstStepInAGame)
            {
                Strategy = new FromHomeStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointClyde);
            }

        }
    }
}