using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using PacMan2._0;
using PacWeb.Hubs;
using PacWeb.Models;

namespace PacWeb
{
    public class GameConnections
    {
        public Game game { get; set; }
        private IHubContext<PacHub> hubContext { get; set; }
        private readonly CodeFirstContext _context;

        public GameConnections(Game _game, IHubContext<PacHub> _hubContext)
        {
            hubContext = _hubContext;
            game = _game;
            _context = new CodeFirstContext();
            _game.pacMan.Movful += PrintPacman;
            _game.gameEngine.Movable += Printblinky;
            _game.gameEngine.Movable += Printclyde;
            _game.gameEngine.Movable += Printinky;
            _game.gameEngine.Movable += Printpinky;
            _game.pacMan.AddPointsForFood += _game.gui.AddToScore;
            _game.gui.GameEnded += WriteDataToDB;
            _game.collision.MapRedraw += SendMap;
        }
        


      
        public void WriteDataToDB()
        {
            _context.Add(new PlayerInfo { Name =  game.gui.PlayerNickName, Score = game.gui.Score});
            _context.SaveChanges();
        }

        public void SendMap()
        {
            hubContext.Clients.Group(game.ID).SendAsync("SendMap", game.gui.Score, game.gui.Lives, game.map.map);
        }

        public async void PrintPacman(Position position)
        {
            await PrintPacMan(position);
        }

        public async void Printpinky(Position position)
        {
            await PrintPinky(position);
        }

        public async void Printinky(Position position)
        {
            await PrintInky(position);
        }

        public async void Printblinky(Position position)
        {
            await PrintBlinky(position);
        }

        public async void Printclyde(Position position)
        {
            await PrintClyde(position);
        }

        public async Task PrintPacMan(Position position)
        {
            await hubContext.Clients.Group(game.ID).SendAsync("PrintPacMan", game.pacMan.ID, position.X, position.Y, game.pacMan.previousPosition.X, game.pacMan.previousPosition.Y, game.gui.Score, game.gui.Lives, game.gui.Level);
        }

        public async Task PrintPinky(Position position)
        {
            await hubContext.Clients.Group(game.ID).SendAsync("PrintPinky", game.pinky.modeStatus.ToString(), game.map.map, game.pinky.ID, game.pinky.position.X, game.pinky.position.Y, game.pinky.previousPosition.X, game.pinky.previousPosition.Y);
        }

        public async Task PrintInky(Position position)
        {
            await hubContext.Clients.Group(game.ID).SendAsync("PrintInky", game.inky.modeStatus.ToString(), game.map.map, game.inky.ID, game.inky.position.X, game.inky.position.Y, game.inky.previousPosition.X, game.inky.previousPosition.Y);
        }

        public async Task PrintClyde(Position position)
        {
            await hubContext.Clients.Group(game.ID).SendAsync("PrintClyde", game.clyde.modeStatus.ToString(), game.map.map, game.clyde.ID, game.clyde.position.X, game.clyde.position.Y, game.clyde.previousPosition.X, game.clyde.previousPosition.Y);
        }

        public async Task PrintBlinky(Position position)
        {
            await hubContext.Clients.Group(game.ID).SendAsync("PrintBlinky", game.blinky.modeStatus.ToString(), game.map.map, game.blinky.ID, game.blinky.position.X, game.blinky.position.Y, game.blinky.previousPosition.X, game.blinky.previousPosition.Y);
        }
    }
}
