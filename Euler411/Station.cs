namespace Euler411
{
    using System;

    public struct Station
    {
        public readonly int X;
        public readonly int Y;
        public int Length;
        
        public Station(int x, int y)
        {
            X = x;
            Y = y;
            Length = 0;          
        }

        public override string ToString()
        {
            return $"({X},{Y})" + ":" + Length;
        }

        public override int GetHashCode()
        {
            return (X ^ Y);
        }

        public static bool operator ==(Station left, Station right)
        {
            return ((left.X == right.X) && (left.Y == right.Y));
        }
        public static bool operator !=(Station left, Station right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            return (Station)obj == this;
        }
    }
}