using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cw2
{
    class OwnComparator : IEqualityComparer<Student>
    {
        bool IEqualityComparer<Student>.Equals(Student x, Student y)
        {
            return StringComparer
                .CurrentCultureIgnoreCase
                .Equals($"{x.fName}{x.lName}{x.index}", $"{y.fName}{y.lName}{y.index}");
        }

        int IEqualityComparer<Student>.GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase
                             .GetHashCode($"{obj.fName}{obj.lName}{obj.index}");
        }
    }
}
