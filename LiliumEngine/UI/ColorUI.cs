namespace LiliumEngine.UI
{
    public class ColorUI
    {
        /// <summary>
        /// Red.
        /// </summary>
        public byte R { get; set; }

        /// <summary>
        /// Green.
        /// </summary>
        public byte G { get; set; }

        /// <summary>
        /// Blue.
        /// </summary>
        public byte B { get; set; }

        /// <summary>
        /// Alpha.
        /// </summary>
        public byte A { get; set; }

        /// <summary>
        /// Determines the color by four parameters: Red, Green, Blue and Alpha channel.
        /// </summary>
        /// <param name="r">Red.</param>
        /// <param name="g">Green.</param>
        /// <param name="b">Blue.</param>
        /// <param name="a">Alpha.</param>
        public ColorUI(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}
