using NJsonSchema;
using System;
using System.Collections.Generic;

namespace Nancy.Metadata.Swagger.Core
{
    public class TypeNameGenerator : ITypeNameGenerator, ISchemaNameGenerator
    {
        public string Generate(Type type) => type.FullName;

        public string Generate(JsonSchema4 schema, string typeNameHint) => typeNameHint;

        public string Generate(JsonSchema4 schema, string typeNameHint, IEnumerable<string> reservedTypeNames) => typeNameHint;
    }
}
