using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using PacMan2._0.Enums;
using PacMan2._0.Interface;
using PacMan2._0.Map;
//using PacMan2._0.VisitorPattern;

namespace PacMan2._0.Characters
{
    public interface IGhost : ICharacter
    {
        void BeScared();
        SidesToMove prevDirection { get; set; }
        GhostStatus modeStatus { get; set; }
        Position _previousPosition { get; set; }
        int countToExit { get; set; }
    }
}
