using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IGameContext
    {
        int Score { get; set; }
        int Lives { get; }
        int Level { get; }
    }
}
