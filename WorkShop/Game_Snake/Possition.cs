using System;
using System.Diagnostics.CodeAnalysis;

namespace Game_Snake
{
    public class Possition : IEquatable<Possition>
    {
        public Possition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public void ChangePossition(Possition possition)
        {
            this.X += possition.X;
            this.Y += possition.Y;
        }

        public bool Equals([AllowNull] Possition other)
        {
            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Possition GetNewPossition(Possition possition)
        {
            return new Possition(this.X + possition.X, this.Y + possition.Y);
        }

        public static bool operator ==(Possition first, Possition second)
        {
            if (first.X == second.X && first.Y == second.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Possition first, Possition second)
        {
            throw new NotImplementedException();
        }
    }
}
