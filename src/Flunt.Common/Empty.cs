using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class Empty
    {
        public static string String
        {
            get { return string.Empty; }
        }

        public static object Dynamic
        {
            get { return new { }; }
        }

        public static IEnumerable<TItem> EnumerableOf<TItem>()
        {
            return new TItem[0];
        }

        public static IList<TItem> ListOf<TItem>()
        {
            return new List<TItem>();
        }

        public static IDictionary<TKey, TValue> DictionaryOf<TKey, TValue>()
        {
            return new Dictionary<TKey, TValue>();
        }
    }
}
