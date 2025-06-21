using System.Collections.Generic;
using System;
using System.Linq;

namespace Libs.CSharp
{
    public class EnumUtils
    {
        public static List<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
