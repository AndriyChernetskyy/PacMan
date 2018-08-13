using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PacMan2._0.Food;
using PacMan2._0.Map;
using PacMan2._0.Interface;

namespace PacMan2._0.Characters
{
    public interface IPacMan : ICharacter
    {
        void Reset();
        void StartMoving();
        void StopMoving();
    }
}
