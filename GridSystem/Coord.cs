namespace GridSystem
{
    public readonly struct Coord
    {
        public readonly int x;
        public readonly int y;

        public Coord()
        {
            x = 0;
            y = 0;
        }

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator == (Coord lhs, Coord rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        public static bool operator != (Coord lhs, Coord rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }

        public static Coord operator + (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Coord operator - (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x - rhs.x, lhs.y - rhs.y);
        }

       public override readonly string ToString()
        {
            return $"({x}, {y})";
        }

        public override readonly bool Equals(object? obj)
        {
            return obj is Coord other && x == other.x && y == other.y;
        }

        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
