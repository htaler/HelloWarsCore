namespace HelloWars.Common.Models
{
    public struct Point
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Point && Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public static bool operator ==(Point x, Point y)
        {
            return x.X == y.X && x.Y == y.Y;
        }

        public static bool operator !=(Point x, Point y)
        {
            return !(x.X == y.X && x.Y == y.Y);
        }
    }
}