using System.Collections.Generic;
using HelloWars.Common.Models;

namespace Game.TankBlaster.Models
{
    public class Explosion
    {
        public Point Center { get; set; }
        public IEnumerable<Point> BlastLocations { get; set; }
    }
}