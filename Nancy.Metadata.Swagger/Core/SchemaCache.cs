using NJsonSchema;
using System.Collections.Generic;

namespace Nancy.Metadata.Swagger.Core
{
    public static class SchemaCache
    {
        public static Dictionary<string, JsonSchema4> Cache = new Dictionary<string, JsonSchema4>();
    }
}
