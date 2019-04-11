using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pipedrive
{
    internal static class ReflectionExtensions
    {
        public static bool IsDateTimeOffset(this Type type)
        {
            return type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?);
        }

        public static IEnumerable<PropertyInfo> GetAllProperties(this Type type)
        {
            var typeInfo = type.GetTypeInfo();
            var properties = typeInfo.DeclaredProperties;

            var baseType = typeInfo.BaseType;

            return baseType == null ? properties : properties.Concat(baseType.GetAllProperties());
        }

        public static bool IsEnumeration(this Type type)
        {
            return type.GetTypeInfo().IsEnum;
        }
    }
}
