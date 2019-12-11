using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace XMLSimpleDeserializer.Model
{
    public class MainContent
    {
        [JsonProperty("Content")]
        [JsonConverter(typeof(SingleOrArrayConverter<ChildContent>))]
        public IList<ChildContent> Content { get; set; }

        [JsonProperty("Value")]
        public int Value { get; set; }

        public override string ToString() => $"{GetType().Name}: [Value: {Value}, ChildContent: [{Content.Count} Items]]";

        private class SingleOrArrayConverter<T> : JsonConverter
        {
            public override bool CanConvert(Type objectType) => (objectType == typeof(List<T>));

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JToken token = JToken.Load(reader);
                if (token.Type == JTokenType.Array)
                {
                    return token.ToObject<List<T>>();
                }
                return new List<T> { token.ToObject<T>() };
            }

            public override bool CanWrite => false;

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
        }
    }
}
