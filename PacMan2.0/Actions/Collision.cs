using PacMan2._0.Characters;
using PacMan2._0.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PacMan2._0.Actions
{
    public class Collision : ICollision
    {
        private List<Ghost> ghosts = new List<Ghost>(4);
        private IPacMan pacman { get; set; }
        public delegate void Collis();
        public delegate void redraw();
        public delegate void FoodEaten(int score);
        public delegate void StopGame();
        public delegate void ResetTimer();
        public event ResetTimer ChangeLastChange;
        public event StopGame StopGhosts;
        public event StopGame StartGhosts;
        public event FoodEaten EatGhost;
        public event redraw MapRedraw;
        public event Collis Collid;
        private GUI gui { get; set; }

        private int CountOfEatenGhosts { get; set; } = 1;

        public Collision(Pinky pinky, Blinky blinky, Inky inky, Clyde clyde, IPacMan pacMan, GUI gui)
        {
            this.gui = gui;
            pacman = pacMan;
            ghosts.Add(pinky);
            ghosts.Add(inky);
            ghosts.Add(blinky);
            ghosts.Add(clyde);
        }

        public void Reset()
        {
            foreach (var ghost in ghosts)
            {
                ghost.Reset();
                ghost.countToExit = 1;
            }
            pacman.Reset();
        }
        
        public async void Collide()
        {
            foreach (var ghost in ghosts)
            {
                if (ghost.modeStatus != GhostStatus.Frightened && pacman._position.X == ghost._position.X && pacman._position.Y == ghost._position.Y && gui.Lives > 0)
                {
                    
                    StopGhosts();
                    pacman.StopMoving();
                    Reset();
                    await Task.Delay(3000);
                    MapRedraw();
                    pacman.StartMoving();
                    StartGhosts();
                    ChangeLastChange();
                    Collid();

                }
                else if(ghost.modeStatus == GhostStatus.Frightened && pacman._position.X == ghost._position.X && pacman._position.Y == ghost._position.Y)
                {
                    ghost.Reset();
                    EatGhost(CountOfEatenGhosts * 100);
                    ghost.modeStatus = GhostStatus.FirstStepInAGame;
                    CountOfEatenGhosts++;
                    ChangeLastChange();
                }
            }

        }
    } 
}