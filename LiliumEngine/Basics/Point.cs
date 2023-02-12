namespace LiliumEngine.Basics
{
    /// <summary>
    /// A class describing a location in space.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// Position on the coordinate plane along the X-axis.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Position on the coordinate plane along the Y-axis.
        /// </summary>
        public float Y { get; set; }


        /// <summary>
        /// Initializes a point on the coordinate plane.
        /// </summary>
        /// <param name="x">X position.</param>
        /// <param name="y">Y position.</param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Determines if the points are equal.
        /// </summary>
        /// <param name="obj">Other point.</param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;

            var other = obj as Point;

            return this.X == other?.X && this.Y == other?.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }

        public override string ToString()
        {
            return $"X: {X}\tY: {Y}\n";
        }
    }
}
