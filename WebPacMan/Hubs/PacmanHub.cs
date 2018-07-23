using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PacMan2._0.Map;
using PacMan2._0.Characters;
using PacMan2._0;

namespace WebPacMan.Hubs
{
    public class PacmanHub : Hub
    {
        private Game game;

        public string direction;

        private readonly IHubContext<PacmanHub> hubContext;

        public PacmanHub(Game game, IHubContext<PacmanHub> hubContext)
        {
         //   this.direction = direction;
            this.hubContext = hubContext;
            this.game = game;
            DrawPacMan();
        }

        private void DrawPacMan()
        {
            Task.Run(() => hubContext.Clients.All.SendAsync("DrawPacMan", game.pacMan.ID, game.pacMan.position.X, game.pacMan.position.Y));
        }
        
        public void PacmanDirection(string direction)
        {
            switch (direction)
            {
                case "37":
                    game.pacMan.GetDirection("left", game.food, game.gUI, game.ghost);
                    
                    break;
                case "38":
                    game.pacMan.GetDirection("up", game.food, game.gUI, game.ghost);
                    break;
                case "39":
                    game.pacMan.GetDirection("right", game.food, game.gUI, game.ghost);
                    break;
                case "40":
                    game.pacMan.GetDirection("down", game.food, game.gUI, game.ghost);
                    break;
            }
            DrawPacMan();
        }
        
        
    }
}
