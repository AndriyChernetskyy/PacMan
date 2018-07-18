using PacMan2._0.Algorythms;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Characters;
using PacMan2._0.Food;

namespace PacMan2._0.Interface
{
    public interface ISelfMovable : IMovable
    {
        void Move(PacMan pacMan, GUI gui, IAlgorythm algo);
    }
}
