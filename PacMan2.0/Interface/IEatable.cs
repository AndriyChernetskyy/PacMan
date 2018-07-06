using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Interface
{
    public interface IEatable 
    {
        void Eat(List<IFood> food, GUI gui, Ghost ghost);
        
    }
}
