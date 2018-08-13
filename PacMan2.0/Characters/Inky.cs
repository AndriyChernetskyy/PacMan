using PacMan2._0.Actions;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Enums;
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
    public sealed class Inky : Ghost
    {

        public new int countToExit { get; set; } = 1;

        public Inky(PacMan pacman, IMaze map, Position position) : base(pacman, map, position)
        {
            aStar = new AStar(this, pacman, map);
            this.pacman = pacman;
            Map = map;
            this.position = position;
        }

        public override void Reset()
        {
            modeStatus = GhostStatus.FirstStepInAGame;
            position.X = 12;
            position.Y = 15;
        }
        
        public override async void Move(SidesToMove dir)
        {
            if(countToExit == 1)
            {
                await Task.Delay(6000);
                ++countToExit;
            }

            switch (dir)
            {
                case SidesToMove.Right:
                    if (Map.Map[position.Y, position.X + 1] != Map.Wall)
                    {
                        if (Map.Map[position.Y, position.X + 1] == Map.PortalRight)
                        {
                            if (modeStatus != GhostStatus.Frightened)
                            {
                                ID = "images/ghosts/inky/right.png";
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
                                ID = "images/ghosts/inky/right.png";
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
                                ID = "images/ghosts/inky/left.png";
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
                                ID = "images/ghosts/inky/left.png";
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
                            ID = "images/ghosts/inky/up.png";
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
                            ID = "images/ghosts/inky/down.png";
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

            
            if (position.X == Map.StartPointInky.X && position.Y == Map.StartPointInky.Y && modeStatus == GhostStatus.FirstStepInAGame) 
            {
                modeStatus = GhostStatus.Walking;
            }

            if (modeStatus == GhostStatus.Chase)
            {
                Strategy = new InkyChaseStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointInky);
            }
            if (modeStatus == GhostStatus.Walking)
            {
                Strategy = new WalkStrategyRight();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointInky);
            }
            if (modeStatus == GhostStatus.Frightened)
            {
                Strategy = new WalkStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointInky);
            }
            if (modeStatus == GhostStatus.FirstStepInAGame)
            {
                Strategy = new FromHomeStrategy();
                Strategy.StartStrategy(aStar, pacman, Map, this, Map.StartPointInky);
            }
        }
    }
}
