using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SessionInMemoy
{
    public static class SessionExtention
    {
        public static void Set<T>(this ISession session, string key, T val)
        {
            session.SetString(key, JsonConvert.SerializeObject(val));
        }

        public static T Get<T>(this ISession session, string key)
        {
            return JsonConvert.DeserializeObject<T>(session.GetString(key));
        }
    }
}
