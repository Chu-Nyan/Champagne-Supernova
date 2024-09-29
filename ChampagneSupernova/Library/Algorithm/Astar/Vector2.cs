namespace ChampagneSupernova.Library.Algorithm.Astar
{
    public struct Vector2
    {
        public int x;
        public int y;

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2 operator -(Vector2 p1, Vector2 p2)
        {
            return new Vector2(p1.x - p2.x, p1.y - p2.y);
        }

        public static bool operator ==(Vector2 p1, Vector2 p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(Vector2 p1, Vector2 p2)
        {
            return p1.x != p2.x || p1.y != p2.y;
        }
    }
}
