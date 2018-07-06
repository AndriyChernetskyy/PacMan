using PacMan2._0.Actions;
using PacMan2._0.VisitorPattern;
using PacMan2._0.Characters;

namespace PacMan2._0.Actions
{
    public class Collision : ICollision
    {
        public void Collide(PacMan pacMan, Ghost ghost, GUI gui)
        {
            var structure = new ObjectStructure();
            structure.Add(pacMan);
            structure.Add(ghost);
            structure.Accept(new ConcreteVisitor1());
            structure.Accept(new ConcreteVisitor2());
            for (int i = 1; i < structure.elements.Count; i++)
            {
                if (structure.elements[i - 1].SomePosition.X == structure.elements[i].SomePosition.X
                    && structure.elements[i - 1].SomePosition.Y == structure.elements[i].SomePosition.Y)
                {
                    gui.GameOver();
                }
            }
        }
    }
}
