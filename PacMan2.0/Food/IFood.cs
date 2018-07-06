using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Actions;
using PacMan2._0.Characters;
using PacMan2._0.Interface;

namespace PacMan2._0.Food
{
    public interface IFood : ICharacter
    {
        int GetScore();
        
    }
}
