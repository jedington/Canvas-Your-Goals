using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
 
namespace SportsStore.Infrastructure
{
    public static class SessionExtensions
    {
        // fields


        // constructors
 

        // methods
        public static T GetJson<T>(this ISession session,
            string key)
        {
            string sessionJsonString = session.GetString(key);
            if (sessionJsonString == null)
            {
                return default(T);
            }
 
            T result =
                JsonConvert.DeserializeObject<T>(sessionJsonString);
            return result;
        }
 
        public static void SetJson(this ISession session,
            string key, object value)
        {
            string valueJsonString =
                JsonConvert.SerializeObject(value);
            session.SetString(key, valueJsonString);
        }
    }
}