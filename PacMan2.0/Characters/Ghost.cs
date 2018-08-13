using PacMan2._0.Algorythms;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Enums;
using PacMan2._0.Map;
using PacMan2._0.Strategies;
using System;
using PacMan2._0.Actions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PacMan2._0.Characters
{
    public abstract class Ghost : IGhost
    {
        public Position _position { get => position; set => position = value; }
        public Position position;
        public Position _previousPosition { get => previousPosition; set => previousPosition = value; }
        public Position previousPosition;
        public IMaze Map { get; set; }
        public string ID { get; set; }
        public SidesToMove direction { get; set; }
        public SidesToMove prevDirection { get; set; }
        public PacMan pacman;
        public GhostStatus modeStatus { get; set; } = GhostStatus.FirstStepInAGame;
        public IAlgorythm aStar;
        public IStrategy Strategy { get; set; }
        public DateTime lastChange { get; set; }
        public DateTime time;
        public int countToExit { get; set; }

        public Ghost(PacMan pacman, IMaze map, Position position)
        {
            aStar = new AStar(this, pacman, map);
            this.pacman = pacman;
            Map = map;
            this.position = position;
        }


        public void BeScared()
        {
            time = DateTime.Now;
            modeStatus = GhostStatus.Frightened;
        }

        public abstract void Reset();
        
        public abstract void Move(SidesToMove direction);
        
    }
}

