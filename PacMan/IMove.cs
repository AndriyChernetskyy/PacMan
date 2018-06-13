using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    public interface IMove
    {
        void moveRight();
        void moveLeft();
        void moveUp();
        void moveDown();
    }
}
