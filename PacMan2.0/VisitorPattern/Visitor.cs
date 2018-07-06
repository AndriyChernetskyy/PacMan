using PacMan2._0.Characters;

namespace PacMan2._0.VisitorPattern
{
    public abstract class Visitor
    {
        public abstract Position VisitElementA(PacMan pacMan);
        public abstract Position VisitElementB(Ghost ghost);
    }
}
