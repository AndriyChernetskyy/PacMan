using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.Enums;
using PacMan2._0.Food;
using PacMan2._0.Map;

namespace PacMan2._0
{
    public class GUI
    {
        public string PlayerNickName { get; set; }
        public int Level { get; set; }
        public int Lives { get; set ; }
        public int Score { get; set; }
        public delegate void EnergizerPower();
        public delegate void EndGame();
        public delegate void Promotion();
        public event Promotion LevelUp;
        public event EndGame GameEnded;
        public event EnergizerPower ScareGhost;
        public IMaze map { get; set; }
        private int count { get; set; } = 0;

        public void GameOver()
        {
            if (Lives != 0)
            {
                --Lives;
            }
            if(Lives < 1)
            {
                GameEnded();
            }
            
        }
        
        public void GoToNextLevel()
        {
            for (int i = 0; i < map.Map.GetLength(0); i++)
            {
                for (int j = 0; j < map.Draw().GetLength(1); j++)
                {
                    if (map.Map[i, j] == "2")
                    {
                        count++;
                    }
                }
            }
            if(count == 0)
            {
                Level++;
                LevelUp();
            }
        }

        public void AddToScore(int points)
        {
            Score += points;
        }

        public void AddToScore(IFood food)
        {
            Score += food.GetScore();
            if(food.Symbol == "5")
            {
                ScareGhost();                
            }
        }

        public GUI(IMaze map)
        {
            map = new Maze();
            this.Score = 0;
            this.Lives = 3;
            this.Level = 0;
        }

       

    }
}
