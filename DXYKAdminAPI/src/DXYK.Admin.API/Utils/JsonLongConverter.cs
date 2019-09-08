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
    /// 解决前端加载数据long类型精度丢失的问题
    /// </summary>
    public class JsonLongConverter : JsonConverter
    {
        /// <summary>
        /// ReadJson
        /// </summary>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken jt = JValue.ReadFrom(reader);
            if (reader.Path.ToLower() == "id")
            {
                if (!string.IsNullOrEmpty(reader.Value.ToString()))
                {
                    return jt.Value<long>();
                }
                else
                {
                    return null;
                }
            }
            return reader.Value;
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
