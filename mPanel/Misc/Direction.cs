namespace mPanel.Misc
{
    public class Direction
    {
        public static Direction Up => new Direction(0, -1);
        public static Direction Down => new Direction(0, 1);
        public static Direction Left => new Direction(-1, 0);
        public static Direction Right => new Direction(1, 0);
        public static Direction None => new Direction(0, 0);

        public int DeltaX { get; set; }
        public int DeltaY { get; set; }

        public Direction(int deltaX, int deltaY)
        {
            DeltaX = deltaX;
            DeltaY = deltaY;
        }

        public bool IsOpposite(Direction other)
        {
            return (DeltaX == -other.DeltaX) && (DeltaY == -other.DeltaY);
        }
    }
}
