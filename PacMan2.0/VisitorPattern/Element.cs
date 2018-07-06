namespace PacMan2._0.VisitorPattern
{
    public abstract class Element
    {
        public abstract Position Accept(Visitor visitor);
        public Position SomePosition { get; set; }
        public string Symbol { get; set; }
    }
}
