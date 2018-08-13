using Microsoft.AspNetCore.SignalR;
using PacMan2._0.Actions;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Characters;
using PacMan2._0.Map;
using System;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public class Game
    {
        public Maze map { get; set; }
        public PacMan pacMan { get; set; }
        public Blinky blinky { get; set; }
        public Pinky pinky { get; set; }
        public IGhost ghost { get; set; }
        public GUI gui { get; set; }
        public Clyde clyde { get; set; }
        public Inky inky { get; set; }
        public Collision collision  { get; set; }
        public GameEngine gameEngine { get; set; }
        public string ID { get; set; }
      

        public Game(string Id)
        {
            ID = Id;
            map = new Maze();
            pacMan = new PacMan(map, new Position(13, 17));
            blinky = new Blinky(pacMan, map, new Position(10, 11));
            pinky = new Pinky(pacMan, map, new Position(11, 14));
            gui = new GUI(map);
            clyde = new Clyde(pacMan, map, new Position(11, 15));
            inky = new Inky(pacMan, map, new Position(12, 15));
            collision = new Collision(pinky, blinky, inky, clyde, pacMan, gui);
            gameEngine = new GameEngine(blinky, clyde, inky, pinky);
            
      }

        

        public void StartGame()
        {
            gameEngine.Collision += collision.Collide;
            pacMan.Collid += collision.Collide;
            collision.Collid += gui.GameOver;
            collision.ChangeLastChange += gameEngine.ChangeLastTime;
            collision.StopGhosts += gameEngine.StopMoving;
            collision.StartGhosts += gameEngine.StartMoving;
            gui.ScareGhost += blinky.BeScared;
            gui.ScareGhost += clyde.BeScared;
            gui.ScareGhost += pinky.BeScared;
            gui.ScareGhost += inky.BeScared;
            gui.GameEnded += End;
            collision.EatGhost += gui.AddToScore;
            pacMan.AddPointsForFood += gui.AddToScore;
            gui.LevelUp += pacMan.Eat; 
            pacMan.StartMoving();
            gameEngine.StartMoving();
       }

        public void End()
        {
            gameEngine.StopMoving();
            pacMan.StopMoving();
            pacMan.Collid -= collision.Collide;
            collision.Collid -= gui.GameOver;
            collision.ChangeLastChange -= gameEngine.ChangeLastTime;
            collision.StopGhosts -= gameEngine.StopMoving;
            collision.StartGhosts -= gameEngine.StartMoving;
            gui.ScareGhost -= blinky.BeScared;
            gui.ScareGhost -= clyde.BeScared;
            gui.ScareGhost -= pinky.BeScared;
            gui.ScareGhost -= inky.BeScared;
            gui.GameEnded -= End;
            collision.EatGhost -= gui.AddToScore;
            pacMan.AddPointsForFood -= gui.AddToScore;
            gameEngine.Collision -= collision.Collide;
        }

        public async void EndGame()
        {
            gameEngine.StopMoving();
            pacMan.StopMoving();
            collision.Reset();
            map = new Maze();
            pacMan.Map = map;
            blinky.Map = map;
            pinky.Map = map;
            clyde.Map = map;
            inky.Map = map;
            gui = new GUI(map);
            await Task.Delay(1000);
            collision.Collid -= gui.GameOver;
            collision.ChangeLastChange -= gameEngine.ChangeLastTime;
            collision.StopGhosts -= gameEngine.StopMoving;
            collision.StartGhosts -= gameEngine.StartMoving;
            gui.ScareGhost -= blinky.BeScared;
            gui.ScareGhost -= clyde.BeScared;
            gui.ScareGhost -= pinky.BeScared;
            gui.ScareGhost -= inky.BeScared;
            gui.GameEnded -= End;
            collision.EatGhost -= gui.AddToScore;
            pacMan.AddPointsForFood -= gui.AddToScore;
            gameEngine.Collision -= collision.Collide;
        }
    }
}
