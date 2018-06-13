using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public abstract class ItemsToEat
    {
        public const int cherry = 200;
        public const int simpleFood = 1;
        public const int energizer = 100;
        public void Energizer()
        {

        }

        public void ghost(Ghost ghost)
        {
            if (Ghost.isFrightened() == true)
            {

            }
        }
        
    }
}
