using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public sealed class Cherry : IEatable
    {
        Event ev = new Event();
        public void Eat(GameState score)
        {
            score.Score += 100;
            ev.events.Add(new Cherry());
        }
    }
}
