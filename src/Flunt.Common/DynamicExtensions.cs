using System.Dynamic;
using System.Linq;

namespace System
{
    public static class DynamicExtensions
    {
        public static bool Has(this object source, string propertyName)
        {
            var dynamic = source as DynamicObject;

            if (dynamic == null)
            {
                return false;
            }

            var containsProperty = dynamic.GetDynamicMemberNames().Contains(propertyName);

            return containsProperty;
        }
    }
}
