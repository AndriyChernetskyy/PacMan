using PacMan2._0.Characters;

namespace PacMan2._0.VisitorPattern
{
    public class ConcreteVisitor1 : Visitor
    {
        public override Position VisitElementA(IPacMan pacMan) => pacMan.GetCurrentPosition();
        public override Position VisitElementB(IGhost ghost) => ghost.GetCurrentPosition();
    }
}
