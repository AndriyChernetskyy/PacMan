using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0.Interface
{
    public class Collision : GameEngine, IAction
    {
        public ICharacter Character { get; set; }
        public IGhost ghost { get; set; }

        public Collision(ICharacter Character, IGhost ghost)
        {
            this.Character = Character;
            this.ghost = ghost;
        }

        public void Collide()
        {
            if (ghost.Map.Map[ghost.Position.Y, ghost.Position.X] ==
                Character.Symbol)
            {
                GameOver();
            }
        }
    }
}
