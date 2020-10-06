/*************************************************************************
 * Author: DCoreyDuke
 * Description: Contains Dictionary Extensions
 * Version: 1.0.0.0
 * Contents:
 *     ConvertToString<TKey,TValue>(this IDictionary<TKey,TValue> dictionary)
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace FortyThreeLime.API.Extensions
{
    public static class DictionaryExtensions
    {
        public static string ConvertToString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            var items = from kvp in dictionary
                        select kvp.Key + "=" + kvp.Value;

            return "{" + string.Join(",", items) + "}";
        }
    }
}