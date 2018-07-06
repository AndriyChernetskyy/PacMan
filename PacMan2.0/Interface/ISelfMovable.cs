using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Interface
{
    public interface ISelfMovable
    {
        void Move(PacMan pacMan, GUI gui, AStar algo);
    }
}
