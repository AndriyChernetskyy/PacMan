using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class Energizer : IEatable
    {

        Event ev = new Event();

        public void Eat(GameState score)
        {
            score.Score += 50;
            ev.events.Add(new Energizer());
        }
    }
}
