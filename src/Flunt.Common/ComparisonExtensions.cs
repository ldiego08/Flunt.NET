namespace System
{
    public static class ComparisonExtensions
    {
        public static bool Or(this bool value, bool other)
        {
            return value || other;
        }

        public static bool And(this bool value, bool other)
        {
            return value && other;
        }

        public static bool IsEqualTo(this object value, object other)
        {
            if (other != null)
            {
                return other.Equals(value);
            }
            else if (value != null)
            {
                return value.Equals(other);
            }
            else
            {
                return value == other;
            }
        }

        public static bool IsDifferentTo(this object value, object other)
        {
            return value.IsEqualTo(other).IsFalse();
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

        public static bool IsTrue(this bool value)
        {
            return value.IsEqualTo(true);
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
