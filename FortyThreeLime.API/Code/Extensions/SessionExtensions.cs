/*************************************************************************
 * Author: DCoreyDuke
 * Description: Contains Session Extensions
 * Version: 1.0.0.0
 ************************************************************************/
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FortyThreeLime.API.Extensions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
