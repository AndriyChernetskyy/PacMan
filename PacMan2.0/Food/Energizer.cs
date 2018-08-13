using PacMan2._0.Characters;


namespace PacMan2._0.Food
{
    public sealed class Energizer : IFood
    {
        public string Symbol { get; set; } = "5";

        public int GetScore() => 50;
        
    }
}
