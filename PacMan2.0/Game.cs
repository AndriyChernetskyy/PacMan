using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2;
using PacMan2._0.Characters;
using PacMan2._0.Food;
using PacMan2._0.Map;

namespace PacMan2._0
{
    public class Game
    {
        public Maze map;
        public GUI gUI;
        public PacMan pacMan;
        public List<IFood> food;
        public Ghost ghost;

        public Game()
        {
            map = new Maze();
            gUI = new GUI();
            food = new List<IFood>(3)
            {
                new PointFood(),
                new Energizer(),
                new Cherry()
            };

            ghost = new Ghost();

            pacMan = new PacMan("images/pacman.png", map, "Yellow", new Position(13, 17));
        }

        public void Start()
        {
        }
    }
}
