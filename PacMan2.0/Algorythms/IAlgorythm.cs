﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan2._0.AStarAlgotithm;
using PacMan2._0.Characters;
using PacMan2._0.Map;

namespace PacMan2._0.Algorythms
{
    public interface IAlgorythm
    {
        void Execute();
        List<Location> ResultPath { get; set; }
        Location From { get; set; }
        Location To { get; set; }
    }
}
