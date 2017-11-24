using HelloWars.Common.Interfaces;

namespace HelloWars.Common.Models
{
    public class GameConfiguration : IConfigurable
    {
        public string Type { get; set; }
        public int NextMoveDelay { get; set; }
    }
}
