namespace HelloWars.Common.Models
{
    public class Bomb : ExplodableBase
    {
        public Bomb(Bomb bomb) : base(bomb)
        {
            RoundsUntilExplodes = bomb.RoundsUntilExplodes;
        }

        public Bomb()
        {
        }

        public int RoundsUntilExplodes { get; set; }
    }
}