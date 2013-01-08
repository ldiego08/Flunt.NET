using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ComparisonExtensions
    {
        public static bool IsEqualTo(this object value, object other)
        {
            return value.Equals(other);
        }

        public static bool IsNull(this object value)
        {
            return value.IsEqualTo(null);
        }

        public static bool IsNotNull(this object value)
        {
            return value.IsNull().IsFalse();
        }

        public static bool IsFalse(this bool value)
        {
            return value.IsEqualTo(false);
        }

        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return value.IsNullOrEmpty().IsFalse();
        }

        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return value.IsNullOrWhiteSpace().IsFalse();
        }
    }
}
