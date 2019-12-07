using System;
using System.Collections.Generic;
using NJsonSchema;

namespace Nancy.Metadata.Swagger.Core
{
    public class TypeNameGenerator : ITypeNameGenerator
    {
        public string Generate(Type type) => type.GetFriendlyName();

        public string Generate(JsonSchema schema, string typeNameHint) => typeNameHint;

        public string Generate(JsonSchema schema, string typeNameHint, IEnumerable<string> reservedTypeNames) => typeNameHint;
    }
}
