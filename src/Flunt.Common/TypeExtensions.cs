namespace System
{
    public static class TypeExtensions
    {
        public static bool IsDerivedOfGenericType(this object source, Type genericType)
        {
            var currentType = genericType;
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
    }
}
