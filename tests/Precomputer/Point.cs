using System;

namespace tests.Precomputer
{
    class Point : IComparable
    {

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public int X;
        public int Y;

        public int CompareTo(object obj)
        {
            var item = obj as Point;
            if (item == null) throw new ArgumentException();

            if (item.X > X && item.Y > Y)
                return -1;

            return 1;
        }

        public static bool operator <(Point p1, Point p2)
        { return (p1.CompareTo(p2) < 0); }
        public static bool operator >(Point p1, Point p2)
        { return (p1.CompareTo(p2) > 0); }
        public static bool operator <=(Point p1, Point p2)
        { return (p1.CompareTo(p2) <= 0); }
        public static bool operator >=(Point p1, Point p2)
        { return (p1.CompareTo(p2) >= 0); }

        public override string ToString()
        {
            return String.Format("Point {0},{1}", X, Y);
        }
    }
}