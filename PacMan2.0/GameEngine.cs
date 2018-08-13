using PacMan2._0.Characters;
using PacMan2._0.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan2._0
{
    public class GameEngine
    {
        public List<Ghost> ghosts = new List<Ghost>(4);
        public event Action<Position> Movable;
        public event Action Collision;
        public Timer timer = new Timer();
        public DateTime lastChange = new DateTime();
        public int a { get; set; } = 1;
        

        public GameEngine(Blinky blinky, Clyde clyde, Inky inky, Pinky pinky)
        {
            ghosts.Add(blinky);
            ghosts.Add(clyde);
            ghosts.Add(inky);
            ghosts.Add(pinky);
        }

        public void StartMoving()
        {
            timer.Interval = 200;
            timer.Elapsed += SimpleMoving;
            timer.Start();
            lastChange = DateTime.Now;
        }
        

        public void StopMoving()
        {
            timer.Stop();
            timer.Elapsed -= SimpleMoving;
        }

        private void ChangeGhostsStatus(GhostStatus ghostStatus)
        {
            foreach(var ghost in ghosts)
            {
                timer.Stop();
                ghost.modeStatus = ghostStatus;
                timer.Start();
            }
        }

        public void ChangeLastTime()
        {
            lastChange = DateTime.Now;
        }

        public void SimpleMoving(object sender, ElapsedEventArgs s)
        {
            foreach (var ghost in ghosts)
            {
                if (ghost.modeStatus == GhostStatus.Frightened)
                {
                    timer.Interval = 300;
                    var t = DateTime.Now;
                    if (t.Second - ghost.time.Second <= 10)
                    {
                        ghost.modeStatus = GhostStatus.Frightened;
                        
                    }
                    else
                    {
                        ChangeGhostsStatus(GhostStatus.FirstStepInAGame);
                        timer.Interval = 200;
                        lastChange = DateTime.Now;
                    }
                }
                else
                {
                    timer.Interval = 200;
                    var timenow = DateTime.Now;
                    if (timenow.Second - lastChange.Second < 8)
                    {
                    }



                    if (timenow.Second - lastChange.Second >= 8 && timenow.Second - lastChange.Second < 18)
                    {
                        timer.Interval = 200;
                        ChangeGhostsStatus(GhostStatus.Chase);
                        if (timenow.Second - lastChange.Second >= 17)
                        {
                            ChangeGhostsStatus(GhostStatus.Chase);
                            lastChange = DateTime.Now;
                        }
                    }
                }

               
                ghost.Move(ghost.direction);
                Movable(ghost.position);
                Collision();
            }

        }

    }
}
