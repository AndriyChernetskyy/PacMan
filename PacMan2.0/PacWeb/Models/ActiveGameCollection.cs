using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PacMan2._0;

namespace PacWeb
{
    public class ActiveGameCollection
    {
        private Dictionary<string, GameConnections> games { get; set; }
        public ActiveGameCollection()
        {
            games = new Dictionary<string, GameConnections>();
        }
        public void AddGame(string Id, GameConnections _games)
        {
            games.Add(Id, _games);
        }
        public void RemoteGame(string Id)
        {
            games.Remove(Id);
        }

        public Game this[string key] => games[key].game;

    }
}
