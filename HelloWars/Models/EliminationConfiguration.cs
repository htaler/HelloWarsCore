using HelloWars.Common.Interfaces;

namespace HelloWars.Common.Models
{
    public class EliminationConfiguration : IConfigurable
    {
        public string Type { get; set; }
        public int NextMoveDelay { get; set; }
    }
}
