﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWars.Common.Models
{
    public class TankBlasterConfig
    {
        public int MapWidth { get; set; }
        public int MapHeight { get; set; }
        public int BombBlastRadius { get; set; }
        public int MissileBlastRadius { get; set; }
        public int RoundsBetweenMissiles { get; set; }
        public int RoundsBeforeIncreasingBlastRadius { get; set; }
        public int BombRoundsUntilExplodes { get; set; }
    }
}
