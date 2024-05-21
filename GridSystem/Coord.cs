namespace GridSystem
{
    /// <summary>
    /// Represents a coordinate in a grid.
    /// </summary>
    public readonly struct Coord
    {
        /// <summary>
        /// The x-coordinate.
        /// </summary>
        public readonly int x;

        /// <summary>
        /// The y-coordinate.
        /// </summary>
        public readonly int y;

        /// <summary>
        /// Initialises a new instance of the <see cref="Coord"/> struct with default values (0, 0).
        /// </summary>
        public Coord()
        {
            x = 0;
            y = 0;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Coord"/> struct with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Determines whether two <see cref="Coord"/> instances are equal.
        /// </summary>
        public static bool operator == (Coord lhs, Coord rhs)
        {
            return lhs.x == rhs.x && lhs.y == rhs.y;
        }

        /// <summary>
        /// Determines whether two <see cref="Coord"/> instances are not equal.
        /// </summary>
        public static bool operator != (Coord lhs, Coord rhs)
        {
            return lhs.x != rhs.x || lhs.y != rhs.y;
        }

        /// <summary>
        /// Adds two <see cref="Coord"/> instances by adding their respective x and y coordinates.
        /// </summary>
        public static Coord operator + (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        /// <summary>
        /// Subtracts two <see cref="Coord"/> instances by subtracting their respective x and y coordinates.
        /// </summary>
        public static Coord operator - (Coord lhs, Coord rhs)
        {
            return new Coord(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        /// <summary>
        /// Returns a string as of the current <see cref="Coord"/> as <c>(x, y)</c>.
        /// </summary>
       public override readonly string ToString()
        {
            return $"({x}, {y})";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="Coord"/>.
        /// </summary>
        public override readonly bool Equals(object? obj)
        {
            return obj is Coord other && x == other.x && y == other.y;
        }

        /// <summary>
        /// Returns the hashcode of the current <see cref="Coord"/>.
        /// </summary>
        public override readonly int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
