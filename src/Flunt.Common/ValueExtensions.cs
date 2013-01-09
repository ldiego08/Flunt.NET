using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
