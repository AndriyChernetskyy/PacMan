using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class GUI
    {
        private int score;
        private int lives;
        private int level;

        public int Level { get => level; set => level = value; }
        public int Lives { get => lives; set => lives = value; }
        public int Score { get => score; set => score = value; }

        
        public void AddToScore(IFood food)
        {
            score += food.GetScore();
        }

        public GUI()
        {
            this.score = 0;
            this.lives = 3;
            this.level = 0;
        }


    }
}
