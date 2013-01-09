using System.Diagnostics.CodeAnalysis;

namespace System
{
    public static class TypeExtensions
    {
        public static bool IsDerivedOfGenericType(this object source, Type expectedType)
        {
            if (source.IsNotNull())
            {
                var currentType = expectedType;
                var sourceType = source.GetType();

                while (currentType.IsNotNull().And(currentType.IsDifferentTo(typeof(object))))
                {
                    var currentGenericType = currentType.IsGenericType ? currentType.GetGenericTypeDefinition() : currentType;

                    if (currentGenericType.IsEqualTo(sourceType))
                    {
                        return true;
                    }

                    currentType = currentType.BaseType;
                }

                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
