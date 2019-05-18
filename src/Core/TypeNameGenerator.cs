using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Nancy.Metadata.Swagger.Core
{
    //https://stackoverflow.com/a/41961738
    public static class TypeTranslator
    {
        private static readonly ReadOnlyDictionary<Type, string> DefaultDictionary = new ReadOnlyDictionary<Type, string>(new Dictionary<Type, string>
        {
            {typeof(int), "int"},
            {typeof(uint), "uint"},
            {typeof(long), "long"},
            {typeof(ulong), "ulong"},
            {typeof(short), "short"},
            {typeof(ushort), "ushort"},
            {typeof(byte), "byte"},
            {typeof(sbyte), "sbyte"},
            {typeof(bool), "bool"},
            {typeof(float), "float"},
            {typeof(double), "double"},
            {typeof(decimal), "decimal"},
            {typeof(char), "char"},
            {typeof(string), "string"},
            {typeof(object), "object"},
            {typeof(void), "void"}
        });

        private static string GetFriendlyName(this Type type, IDictionary<Type, string> translations)
        {
            if (translations.ContainsKey(type))
                return translations[type];
            if (type.IsArray)
                return GetFriendlyName(type.GetElementType(), translations) + "[]";
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments()[0].GetFriendlyName() + "?";
            if (type.IsGenericType)
                return type.FullName.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(GetFriendlyName).ToArray()) + ">";
            
            return type.FullName;
        }

        public static string GetFriendlyName(this Type type) => type.GetFriendlyName(DefaultDictionary);
    }

    public class TypeNameGenerator : ITypeNameGenerator, ISchemaNameGenerator
    {
        public string Generate(Type type) => type.GetFriendlyName();

        public string Generate(JsonSchema4 schema, string typeNameHint) => typeNameHint;

        public string Generate(JsonSchema4 schema, string typeNameHint, IEnumerable<string> reservedTypeNames) => typeNameHint;
    }
}