using HelloWars.Common.Enums;

namespace HelloWars.Common.Models
{
    public class Missile : ExplodableBase
    {
        public MoveDirection MoveDirection { get; set; }

        public Missile(Missile missle) : base(missle)
        {
            MoveDirection = missle.MoveDirection;
        }

        public Missile() { }
    }
}
