using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Thalus.Forma.Parser.Json
{
    internal class DtoConverter : JsonConverter
    {
        private IDictionary<string, Func<Part>> _creators = new Dictionary<string, Func<Part>>
        {
            {"double-param", () => new DoubleParam()},
            {"int-param", () => new IntParam()},
            {"char-param", () => new CharParam()},
            {"string-param", () => new StringParam()},
            {"string-meta", () => new StringEnumMeta()},
            {"char-meta", () => new CharEnumMeta()},
            {"int-meta", () => new IntEnumMeta()},
            {"double-meta", () => new DoubleEnumMeta()},
            {"int-range", () => new IntRange()},
            {"double-range", () => new DoubleRange()},
            {"string-enum-meta", () => new StringEnumMeta()},
            {"int-enum-meta", () => new IntEnumMeta()},
            {"double-enum-meta", () => new DoubleEnumMeta()},
            {"char-enum-meta", () => new CharEnumMeta()},
            {"group", () => new GroupParam()},
            {"group-meta", () => new GroupParamMeta()},
            {"unit", () => new UnitParam()},
        };

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var t = jsonObject["Type"].Value<string>();

            var thepart = _creators[t]();

            serializer.Populate(jsonObject.CreateReader(), thepart);
            return thepart;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Part) == objectType;
        }

        public override bool CanWrite => false;
        public override bool CanRead => true;
    }
}