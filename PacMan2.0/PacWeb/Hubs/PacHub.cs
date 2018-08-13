using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PacMan2._0;
using PacWeb.Models;
using static PacWeb.Models.CodeFirstContext;

namespace PacWeb.Hubs
{
    public class PacHub : Hub
    {
        private ActiveGameCollection activeGameCollection;
        
        public PacHub(ActiveGameCollection activeGameCollection)
        {
            this.activeGameCollection = activeGameCollection;
        }

        public void DrawMap(string Id)
        {
            Clients.Caller.SendAsync("SendMap", activeGameCollection[Id].gui.Score, activeGameCollection[Id].gui.Lives, activeGameCollection[Id].map.map);
        }

        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("connect");
            return base.OnConnectedAsync();
        }

        public async Task ConnectToGroup(string Id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Id);
        }

        
        public void SubmitForm(string nickName, string Id)
        {
            activeGameCollection[Id].gui.PlayerNickName = nickName;
            activeGameCollection[Id].StartGame();

        }

        public async void RestartGame(string Id)
        {
            activeGameCollection[Id].EndGame();
            DrawMap(Id);
            await Task.Delay(3000);
            activeGameCollection[Id].StartGame();
        }


        public void PacmanDirection(string Id, string direction)
         {
             switch (direction)
             {
                 case "37":
                    activeGameCollection[Id].pacMan.ChangeDirection(SidesToMove.Left);
                     break;
                 case "38":
                    activeGameCollection[Id].pacMan.ChangeDirection(SidesToMove.Up);
                     break;
                 case "39":
                    activeGameCollection[Id].pacMan.ChangeDirection(SidesToMove.Right);
                     break;
                 case "40":
                    activeGameCollection[Id].pacMan.ChangeDirection(SidesToMove.Down);
                     break;
             }
         }


    }
}
