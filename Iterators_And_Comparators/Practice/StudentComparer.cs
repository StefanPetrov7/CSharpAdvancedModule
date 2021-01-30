using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Practice
{
    public class StudentComparer : IComparer<Student>
    {
        public int Compare([AllowNull] Student x, [AllowNull] Student y)
        {
            return x.Grade.CompareTo(y.Grade); // (* -1) to order by descending.
        }
    }
}
