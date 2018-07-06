using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Actions
{
    public interface IRunAway
    {
        bool IsScared { get; set; }
       // void Scared(PacMan pacMan, Ghost ghost, Energizer energizer);

    }
}
