using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class GUI
    {
        private int score = 0;
        private int lives = 3;
        private int level = 0;

        public int Level { get => level; set => level = value; }
        public int Lives { get => lives; set => lives = value; }
        public int Score { get => score; set => score = value; }
    }
}
