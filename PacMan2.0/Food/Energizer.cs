using PacMan2._0.Actions;
using PacMan2._0.Characters;


namespace PacMan2._0.Food
{
    public sealed class Energizer : IFood
    {
        public string Symbol { get; set; } = "*";

        public int GetScore() => 50;

        public void MakeGhostScared(IGhost ghost, IPacMan pacMan)
        {
            ghost.Scared(pacMan);
        }
        
    }
}
