using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class GameEngine : GUI
    {
        public ConsoleColor Color { get; set; }
        public Position Position { get; set; }


        public void GameOver() => Lives--;


    }
}
    

