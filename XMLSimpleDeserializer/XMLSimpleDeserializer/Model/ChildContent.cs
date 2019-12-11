using Newtonsoft.Json;

namespace XMLSimpleDeserializer.Model
{
    public class ChildContent
    {
        [JsonProperty("@alias")]
        public string Alias { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Required")]
        public bool Required { get; set; }

        public override string ToString() => $"{GetType().Name}: ChildContent: [@Alias: {Alias}, Name: {Name}, Required: {Required}]";
    }
}