using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWars.Common.Models
{
    public class Bomb
    {
        public Point Location { get; set; }
        public int RoundsUntilExplodes { get; set; }
        public int ExplosionRadius { get; set; }
    }
}
