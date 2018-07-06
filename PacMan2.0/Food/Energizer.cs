using PacMan2._0.Actions;
using PacMan2._0.Characters;


namespace PacMan2._0.Food
{
    public sealed class Energizer : IFood
    {

        //public event EventHandler EnergizerEaten;

        public string Symbol { get; set; } = "*";

        public int GetScore() => 50;

        /*public void Button_Click(object o, EventArgs s)
        {
            if (EnergizerEaten != null)
            {
                EnergizerEaten(this, null);
            }
            
        }*/

        public void MakeGhostScared(Ghost ghost, PacMan pacMan)
        {
            ghost.Scared(pacMan);
        }

    
/*
        

        public void Scare(Ghost ghost)
        {

            EnergizerEaten(true);

        }
        */
    }
}
