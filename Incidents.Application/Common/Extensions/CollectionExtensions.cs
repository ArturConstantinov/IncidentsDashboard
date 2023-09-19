using System;
using System.Collections.Generic;
using System.Linq;

namespace Incidents.Application.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<int> ToInt(this IEnumerable<string> source)
        {
            if (source == null)
            {
                yield break;
            }

            foreach (var item in source)
            {
                bool isParsed = int.TryParse(item, out int parsedItem);

                if (isParsed)
                {
                    yield return parsedItem;
                }
            }
        }

        public static IEnumerable<TSource> DistinctByImpl<TSource, TKey>(IEnumerable<TSource> source,
              Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            HashSet<TKey> knownKeys = new HashSet<TKey>(comparer);
            foreach (TSource element in source)
            {
                if (knownKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
