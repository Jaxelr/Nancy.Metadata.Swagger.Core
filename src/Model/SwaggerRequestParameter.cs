using System.Collections.Generic;
using Newtonsoft.Json;

namespace Nancy.Metadata.Swagger.Model
{
    public class SwaggerRequestParameter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("in")]
        public string In { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("schema")]
        public SchemaRef Schema { get; set; }

        [JsonProperty("items")]
        public Item Item { get; set; }

        [JsonProperty("default")]
        public object Default { get; set; }

        [JsonProperty("maximum")]
        public long? Maximum { get; set; }

        [JsonProperty("exclusiveMaximum")]
        public bool? ExclusiveMaximum { get; set; }

        [JsonProperty("minimum")]
        public long? Minimum { get; set; }

        [JsonProperty("exclusiveMinimum")]
        public bool? ExclusiveMinimum { get; set; }

        [JsonProperty("maxLength")]
        public long? MaxLength { get; set; }

        [JsonProperty("minLength")]
        public long? MinLength { get; set; }

        [JsonProperty("pattern")]
        public string Pattern { get; set; }

        [JsonProperty("maxItems")]
        public int? MaxItems { get; set; }

        [JsonProperty("minItems")]
        public int? MinItems { get; set; }

        [JsonProperty("uniqueItems")]
        public bool? UniqueItems { get; set; }

        [JsonProperty("enum")]
        public IEnumerable<string> Enum { get; set; }

        [JsonProperty("multipleOf")]
        public int? MultipleOf { get; set; }
    }

    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class SchemaRef
    {
        [JsonProperty("$ref")]
        public string Ref { get; set; }
    }
}
