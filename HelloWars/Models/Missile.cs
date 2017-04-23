using HelloWars.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWars.Common.Models
{
    public class Missile
    {
        public Point Location { get; set; }
        public int ExplosionRadius { get; set; }
        public MoveDirection MoveDirection { get; set; }
    }
}
