namespace Didutron
{
    public struct Coord
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj)
        {
            if (obj is Coord)
            {
                var other = (Coord)obj;
                return x == other.x && y == other.y;
            }
            return false;
        }
        public static bool operator ==(Coord lhs, Coord rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator != (Coord lhs, Coord rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }

        public static Coord operator +(Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Coord operator - (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ y.GetHashCode();
        }
    }
}
