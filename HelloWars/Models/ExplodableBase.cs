using HelloWars.Common.Converters;
using Newtonsoft.Json;

namespace HelloWars.Common.Models
{
    public abstract class ExplodableBase
    {
        protected ExplodableBase() { }

        protected ExplodableBase(ExplodableBase explodableBase)
        {
            Location = explodableBase.Location;
            ExplosionRadius = explodableBase.ExplosionRadius;
        }

        [JsonConverter(typeof(PointFormatConverter))]
        public Point Location { get; set; }
        public int ExplosionRadius { get; set; }
        public bool IsExploded { get; set; }
    }
}