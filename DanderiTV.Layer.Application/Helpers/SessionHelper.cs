using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;


namespace DanderiTV.Layer.Application.Helpers
{
    public static class SessionHelper
    {
        public static void SetUserApp<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T? GetUserApp<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
