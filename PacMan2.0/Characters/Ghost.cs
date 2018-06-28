using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PacMan2._0.Interface;

namespace PacMan2._0
{
    public class Ghost : GameEngine, IGhost
    {
        private Position position;
        public IMaze Map { get; set; }
        
        public string Symbol { get; set; } = "G";
        public Position Position { get => position; set => position = value; }
        public ConsoleColor Color { get; set; }

        public Ghost(IMaze map, ConsoleColor color, Position position)
        {
            Map = map;
            Position = position;
            Color = color;
        }

        
        public async void Push()
        {
            //Task<int> task = new Task<int>(Move);
            await Task.Run(() => Move());

            var a =  Task.Run(() => Move());
            // blablabla
            
            await a;
        }

        

        public int Move()
        {
            while (true)
            {
                Position temp = new Position()
                {
                    X = Position.X,
                    Y = Position.Y
                };

                Console.SetCursorPosition(temp.X, temp.Y);
                Console.WriteLine(" ");

                Random rnd = new Random();
                int result = rnd.Next(4);
                SidesToMove sd = SidesToMove.Down;
                for (int i = 0; i < 4; i++)
                {
                    if (result == (int) SidesToMove.Down)
                    {
                        sd = SidesToMove.Down;
                    }

                    if (result == (int) SidesToMove.Left)
                    {
                        sd = SidesToMove.Left;
                    }

                    if (result == (int) SidesToMove.Right)
                    {
                        sd = SidesToMove.Right;
                    }

                    if (result == (int) SidesToMove.Up)
                    {
                        sd = SidesToMove.Up;
                    }
                }



                switch (sd)
                {
                    case SidesToMove.Right:
                        if (Map.Map[Position.Y, Position.X + 1] != Map.Wall)
                        {
                            position.X++;
                        }

                        break;
                    case SidesToMove.Left:
                        if (Map.Map[Position.Y, Position.X - 1] != Map.Wall)
                        {
                            position.X--;
                        }

                        break;
                    case SidesToMove.Up:
                        if (Map.Map[Position.Y - 1, Position.X] != Map.Wall)
                        {
                            position.Y--;
                        }

                        break;
                    case SidesToMove.Down:
                        if (Map.Map[Position.Y + 1, Position.X] != Map.Wall)
                        {
                            position.Y++;
                        }

                        break;
                }

                Console.SetCursorPosition(Position.X, Position.Y);
                Console.WriteLine(Symbol);
                Thread.Sleep(500);
               
            }

            return 0;
        }



        
    }
}
