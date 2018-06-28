﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan2._0
{
    public interface IPacMan : IEatable, IMovable
    {
        IMaze Map { get; set; }
        Position Position { get; set; }
        ConsoleColor Color { get; set; }

    }
}
