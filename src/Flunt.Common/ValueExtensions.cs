namespace System
{
    public static class ValueExtensions
    {
        public static TSource OrIfIsNull<TSource>(this TSource source, TSource other) where TSource : class
        {
            return source ?? other;
        }
    }
}
