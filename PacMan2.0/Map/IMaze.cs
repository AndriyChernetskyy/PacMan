using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public interface IMaze
    {
        string[,] Map { get; set; }
        string[,] Draw();
        string Wall { get; set; }
    }
}
