using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PacMan2._0.Map;
using PacMan2._0.VisitorPattern;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Actions;
using PacMan2._0.Food;

namespace PacMan2._0.Characters
{
    public class Ghost : Element, IGhost
    {
        public Position position;
        public IMaze Map { get; set; }
        public ICollision Collision { get; set; }

        public bool IsScared { get; set; }
        public List<Position> Curposition;
        public new string Symbol { get; set; } = "G";
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }


        public void Scared(PacMan pacMan)
        {
            IsScared = false;
            var waitTime = new TimeSpan(0, 0, 10);
            var waitUntil = DateTime.Now + waitTime;

            while (DateTime.Now <= waitUntil)
            {
                IsScared = true;
            }

            if (IsScared)
            {
                position.X = pacMan.position.X + 2;
                position.Y = pacMan.position.Y + 2;
            }
        }


        public Ghost(IMaze map, ConsoleColor color, Position position)
        {
            Map = map;
            Position = position;
            Color = color;
        }



        public override Position Accept(Visitor visitor) => visitor.VisitElementB(this);


        public async void Push(PacMan pacMan, GUI gui, AStar algo)
        {
            await Task.Run(() => Move(pacMan, gui, algo));
        }


        public Position GetCurrentPosition() => this.Position;


        public async void Move(PacMan pacMan, GUI gui, AStar algo)
        {

            algo.Execute(this, pacMan, Map);

            Curposition = new List<Position>(algo.ResultPath.Capacity);

            foreach (var item in algo.ResultPath)
            {
                Curposition.Add(new Position(item.X, item.Y));
            }



            foreach (var V in Curposition)
            {
                position.X = V.X;
                position.Y = V.Y;
                await Task.Delay(250);
            }


            Collision = new Collision();
            Collision.Collide(pacMan, this, gui);

            if (gui.Lives < 1)
            {

                Environment.Exit(0);
            }

            Thread.Sleep(500);

        }




    }
}
