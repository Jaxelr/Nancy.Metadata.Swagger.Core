using System.Collections.Generic;
using NJsonSchema;

namespace Nancy.Metadata.Swagger.Core
{
    public static class SchemaCache
    {
        public static Dictionary<string, JsonSchema4> Cache = new Dictionary<string, JsonSchema4>();
    }
}