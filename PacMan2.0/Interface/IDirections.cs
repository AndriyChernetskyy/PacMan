using System;
using System.Collections.Generic;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Interface
{
    public interface IDirections
    {
        void GetDirection(ConsoleKey key, List<IFood> food, GUI gui, Ghost ghost);
    }
}
