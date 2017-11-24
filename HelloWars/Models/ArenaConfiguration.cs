using HelloWars.Common.Models;

namespace Game.TankBlaster.Models
{
    public class ArenaConfiguration
    {
        public int ArenaMessageDuration { get; set; }
        public GameConfiguration GameConfiguration { get; set; }
        public EliminationConfiguration EliminationConfiguration { get; set; }
    }
}