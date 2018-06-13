using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public class EatGhost : IEatable
    {
        public void Eat(GameState score)
        {
            if(score.isFrightened == true)
            {
                score.Score += 200;
            }
        }
    }
}
