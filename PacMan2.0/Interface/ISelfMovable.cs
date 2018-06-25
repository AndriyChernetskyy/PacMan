using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public interface ISelfMovable
    {
        void Move(SidesToMove stm, IMaze map);
    }
}
