using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Actions
{
    public class RunAway : IRunAway
    {
        public bool IsScared { get; set; }
        public Ghost _Ghost { get; set; }


      /*  public RunAway()
        {
            Energizer objectToSunscribeTo = new Energizer();
            objectToSunscribeTo.EnergizerEaten += HandleSomethingHappened;
        }*/
/*
        public void HandleSomethingHappened(object sender, EventArgs e)
        {
            _Ghost.Scared();
        }
        */

        /*public void Scared(PacMan pacMan, Ghost ghost, Energizer energizer)
        {
            ghost.IsScared = false;
            var waitTime = new TimeSpan(0,0,10);
            var waitUntil = DateTime.Now + waitTime;

            while (DateTime.Now <= waitUntil)
            {
                ghost.IsScared = true;
            }
            if (IsScared)
            {
                ghost.position.X = pacMan.position.X + 5;
                ghost.position.Y = pacMan.position.Y + 5;

            }
        }*/
    }
}
