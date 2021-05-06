using System;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.Json
{
    /// <summary>
    /// Utility Attribute to allow decorate interfaces
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface, AllowMultiple = false)]
    public class JsonInterfaceConverterAttribute : JsonConverterAttribute
    {
        public JsonInterfaceConverterAttribute(Type converterType)
            : base(converterType)
        {
        }
    }
}
