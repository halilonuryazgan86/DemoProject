using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Core
{
    public static class SerializationExtension
    {
        public static T DeSerialize<T>(this string objectStr)
        {
            if (string.IsNullOrEmpty(objectStr)) return Activator.CreateInstance<T>();
            return JsonConvert.DeserializeObject<T>(objectStr);
        }

        public static string Serialize<T>(this T obj)
        {
            if (obj == null) return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }
    }
}
