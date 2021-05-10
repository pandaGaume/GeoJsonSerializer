using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace IOfThings.Spatial.Text.GeoJson
{
    public static class TypeExtensions
    {
        internal static bool IsNumericType(this Type t)
        {
            switch(Type.GetTypeCode(t))
            {
                case TypeCode.Double:
                case TypeCode.Int32:
                case TypeCode.Single:
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int64:
                case TypeCode.Decimal: return true;
                default: return false;
            };
        }

    }
}
