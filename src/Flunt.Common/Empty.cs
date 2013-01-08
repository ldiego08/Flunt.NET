using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Empty
    {
        public static IDictionary<TKey, TValue> DictionaryOf<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }
    }
}
