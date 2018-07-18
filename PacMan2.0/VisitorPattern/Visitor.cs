using PacMan2._0.Characters;

namespace PacMan2._0.VisitorPattern
{
    public abstract class Visitor
    {
        public abstract Position VisitElementA(IPacMan pacMan);
        public abstract Position VisitElementB(IGhost ghost);
    }
}
