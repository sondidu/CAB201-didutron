namespace Didutron
{
    public struct Coord
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Coord()
        {
            X = 0;
            Y = 0;
        }
        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override readonly bool Equals(object obj)
        {
            if (obj is Coord)
            {
                var other = (Coord)obj;
                return X == other.X && Y == other.Y;
            }
            return false;
        }
        public static bool operator == (Coord lhs, Coord rhs)
        {
            return lhs.X == rhs.X && lhs.Y == rhs.Y;
        }
        public static bool operator != (Coord lhs, Coord rhs)
        {
            return lhs.X != rhs.X || lhs.Y != rhs.Y;
        }
        public static Coord operator + (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.X + rhs.X, lhs.Y + rhs.Y);
        }
        public static Coord operator - (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.X - rhs.X, lhs.Y - rhs.Y);
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }
    }
}
