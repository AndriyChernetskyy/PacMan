using System;
using System.Collections.Generic;
using PacMan2._0.Map;
using System.Timers;
using PacMan2._0.Food;
using System.Threading.Tasks;

namespace PacMan2._0.Characters
{
    public class PacMan : IPacMan
    {
        public Position _position { get => position; set => position = value; }
        public Position position;
        public Position previousPosition;
        public string ID { get; set; } = "images/pacman.png";
        public IMaze Map { get; set; }
        public Position Position { get => position; set => position = value; }
        public SidesToMove direction { get; set; } 
        public List<IFood> foods;
        public delegate void MoveHandler(Position position);
        public delegate void EatFood(IFood food);
        public delegate void Collide();
        public event Collide Collid;
        public event EatFood AddPointsForFood;
        private Timer timer;
        public SidesToMove button;
        public string ButtonActivated;
        public bool canTurn { get; set; } = false;
       

        public event MoveHandler Movful;

        public PacMan(IMaze map, Position position)
        {
            timer = new Timer();
           
            foods = new List<IFood>(3)
            {
                new PointFood(),
                new Energizer(),
                new Cherry()
            
            };

            Map = map;
            Position = position;
        }

        public void StartMoving()
        {
            previousPosition = position;
            direction = SidesToMove.Right;
            timer.Interval = 200;
            timer.Elapsed += Moving;
            timer.Start();
            
        }

        public PacMan()
        {
        }

        public void Eat()
        {
            foreach (var food in foods)
            {
                if (Map.Map[Position.Y, Position.X] == food.Symbol)
                {
                    AddPointsForFood(food);
                    Map.Map[Position.Y, Position.X] = "3";
                }
            }
            
        }

        
        public void StopMoving()
        {
            timer.Stop();
            timer.Elapsed -= Moving;
        }
        

        public void Reset()
        {
            previousPosition.X = position.X;
            previousPosition.Y = position.Y;
            position.X = 13;
            position.Y = 17;
        }
        


        private void Moving(object sender, ElapsedEventArgs s)
        {
           
            Move(direction);
            
            Movful(this.position);
            Collid();
     }

        public void ChangeDirection(SidesToMove stm)
        {
            switch (stm)
            {
                case SidesToMove.Down:
                    
                        if (Map.Map[position.Y + 1, position.X] != Map.Wall && Map.Map[position.Y + 1, position.X] != Map.GhostHouseDoors)
                        {
                            canTurn = true;
                        }
                    break;
                case SidesToMove.Left:
                     if (Map.Map[position.Y, position.X - 1] != Map.Wall)
                        {
                            canTurn = true;
                        }
                    

                    break;
                case SidesToMove.Right:
                    
                        if (Map.Map[position.Y, position.X + 1] != Map.Wall && Map.Map[position.Y + 1, position.X] != Map.GhostHouseDoors) 
                        {
                            canTurn = true;
                        }
                    

                    break;
                case SidesToMove.Up:
                    
                        if (Map.Map[position.Y - 1, position.X] != Map.Wall && Map.Map[position.Y + 1, position.X] != Map.GhostHouseDoors)
                        {
                            canTurn = true;
                        }
                    
                    break;

            }

            
            if (Map.Map[position.Y - 1, position.X] == Map.Wall && Map.Map[position.Y, position.X - 1] == Map.Wall)
            {
                if (stm != SidesToMove.Up && stm != SidesToMove.Left && canTurn == true)
                {
                    ButtonActivated = "pass";
                    button = stm;

                }
                
            }

            if (Map.Map[position.Y + 1, position.X] == Map.Wall || Map.Map[position.Y, position.X - 1] == Map.Wall)
            {
                if (stm != SidesToMove.Down && stm != SidesToMove.Left && canTurn == true)
                {
                    ButtonActivated = "pass";
                    button = stm;
                }
            }

            if (Map.Map[position.Y - 1, position.X] == Map.Wall && Map.Map[position.Y, position.X + 1] == Map.Wall)
            {
                if (stm != SidesToMove.Up && stm != SidesToMove.Right && canTurn == true)
                {
                    ButtonActivated = "pass";
                    button = stm;
                }
            }

            if (Map.Map[position.Y + 1, position.X] == Map.Wall && Map.Map[position.Y, position.X + 1] == Map.Wall)
            {
                if (stm != SidesToMove.Right && stm != SidesToMove.Down)
                {

                    ButtonActivated = "pass";
                    button = stm;
                }
            }
            
            
            if (ButtonActivated == null && stm != direction)
            {
                ButtonActivated = "pass";
                button = stm;
            }
        }

        public void Move(SidesToMove dir)
        {
            if (Map.Map[Position.Y, Position.X + 1] != Map.Wall && Map.Map[position.Y, position.X] != Map.GhostHouseDoors)
            {
                if (ButtonActivated != null && button == SidesToMove.Right && direction != SidesToMove.Right)
                {
                    ButtonActivated = null;
                    ID = "images/pacman_right.png";
                    previousPosition.X = position.X;
                    previousPosition.Y = position.Y;
                    position.X++;
                    timer.Stop();
                    direction = SidesToMove.Right;
                    timer.Start();
                }
            }

            if (Map.Map[Position.Y, Position.X - 1] != Map.Wall && Map.Map[position.Y, position.X - 1] != Map.GhostHouseDoors)
            {
                if (ButtonActivated != null && button == SidesToMove.Left)
                {
                    ButtonActivated = null;
                    ID = "images/pacman_left.png";
                    previousPosition.X = position.X;
                    previousPosition.Y = position.Y;
                    position.X--;
                    timer.Stop();
                    direction = SidesToMove.Left;
                    timer.Start();
                }
            }

            if (Map.Map[Position.Y - 1, Position.X] != Map.Wall && Map.Map[position.Y - 1, position.X] != Map.GhostHouseDoors)
            {
                if (ButtonActivated != null && button == SidesToMove.Up)
                {
                    ButtonActivated = null;
                    ID = "images/pacman_up.png";
                    previousPosition.X = position.X;
                    previousPosition.Y = position.Y;
                    position.Y--;
                    timer.Stop();
                    direction = SidesToMove.Up;
                    timer.Start();
                }
            }
            if (Map.Map[Position.Y + 1, Position.X] != Map.Wall && Map.Map[position.Y + 1, position.X] != Map.GhostHouseDoors)
            {
                if (ButtonActivated != null && button == SidesToMove.Down)
                {
                    ButtonActivated = null;
                    ID = "images/pacman_down.png";
                    previousPosition.X = position.X;
                    previousPosition.Y = position.Y;
                    position.Y++;
                    timer.Stop();
                    direction = SidesToMove.Down;
                    timer.Start();
                }
            }

            
            switch (dir)
            {
                case SidesToMove.Right:
                    if (Map.Map[Position.Y, Position.X + 1] != Map.Wall && Map.Map[position.Y, position.X + 1] != Map.GhostHouseDoors)
                    {
                        if (Map.Map[position.Y, position.X + 1] == Map.PortalRight)
                        {
                            ID = "images/pacman_right.png";
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X = Map.PortalLeftPos.X;
                            position.Y = Map.PortalLeftPos.Y;
                            position.X++;
                        }
                        else
                        {
                            ID = "images/pacman_right.png";
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X++;
                        }
                    }
                    break;
                case SidesToMove.Left:
                    if (Map.Map[Position.Y, Position.X - 1] != Map.Wall && Map.Map[position.Y, position.X - 1] != Map.GhostHouseDoors)
                    {
                        if (Map.Map[position.Y, position.X - 1] == Map.PortalLeft)
                        {
                            ID = "images/pacman_left.png";
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X = Map.PortalRightPos.X;
                            position.Y = Map.PortalRightPos.Y;
                            position.X--;
                        }

                        else
                        {
                            ID = "images/pacman_left.png";
                            previousPosition.X = position.X;
                            previousPosition.Y = position.Y;
                            position.X--;
                        }
                    }
                    break;
                case SidesToMove.Up:
                    if (Map.Map[Position.Y - 1, Position.X] != Map.Wall && Map.Map[position.Y  - 1, position.X] != Map.GhostHouseDoors)
                    {
                        ID = "images/pacman_up.png";
                        previousPosition.X = position.X;
                        previousPosition.Y = position.Y;
                        position.Y--;
                    }
                    break;
                case SidesToMove.Down:
                    if (Map.Map[Position.Y + 1, Position.X] != Map.Wall && Map.Map[position.Y + 1, position.X] != Map.GhostHouseDoors)
                    {
                        ID = "images/pacman_down.png";
                        previousPosition.X = position.X;
                        previousPosition.Y = position.Y;
                        position.Y++;
                    }
                    break;
            }
            Eat();
            
        }
        
    }
}
