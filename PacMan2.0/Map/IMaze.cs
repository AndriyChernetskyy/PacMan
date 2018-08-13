using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0.Map
{
    public interface IMaze
    {
        string[,] Map { get; set; }
        string[,] Draw();
        string Wall { get; set; }
        string PortalLeft { get; set; }
        string PortalRight { get; set; }
        Position PortalLeftPos { get; }
        Position PortalRightPos { get; }
        Position RightCorner { get; }
        Position LeftCorner { get; }
        Position BottomLeftCorner { get; }
        Position BottomRightCorner { get; }
        Position StartPointClyde { get; }
        Position StartPointPinky { get; }
        Position StartPointInky { get; }
        Position StartPointBlinky { get; }
        string GhostHouseDoors { get; }
    }
}
