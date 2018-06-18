using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class SimpleFood : IEatable
    {
        Event ev = new Event();
        public void Eat(GameState score)
        {
            score.Score++;
            ev.events.Add(new SimpleFood());
        }        
    }
}
