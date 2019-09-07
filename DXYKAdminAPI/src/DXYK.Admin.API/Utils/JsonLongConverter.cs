using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DXYK.Admin.API.Utils
{
    /// <summary>
    /// long 类型转为string
    /// </summary>
    public class JsonLongConverter : JsonConverter
    {
        /// <summary>
        /// ReadJson
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jt = JValue.ReadFrom(reader);

            return jt.Value<long>();
        }

        /// <summary>
        /// CanConvert
        /// </summary>
        public override bool CanConvert(Type objectType)
        {
            return typeof(System.Int64).Equals(objectType);
        }

        /// <summary>
        /// WriteJson
        /// </summary>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value.ToString());
        }
        
    }
}
