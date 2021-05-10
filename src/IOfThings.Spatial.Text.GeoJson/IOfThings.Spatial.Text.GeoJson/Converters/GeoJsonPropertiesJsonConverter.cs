using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson.Converters
{
    /// <summary>
    ///  Allow user to bind Serialization Type with PropertyName. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GeoJsonPropertiesJsonConverter<T> : JsonConverter<IGeoJsonProperties<T>>
    {
        IDictionary<string, Type> propertyTypes;

        public override bool CanConvert(Type typeToConvert)
        {
            return (typeToConvert.IsInterface && typeToConvert.IsGenericType && typeof(IDictionary<string, T>).IsAssignableFrom(typeToConvert.GetGenericTypeDefinition()) ||
                    typeToConvert.GetInterfaces().Any(i => i.IsGenericType && typeof(IDictionary<string, T>).IsAssignableFrom(i.GetGenericTypeDefinition())));
        }

        public override IGeoJsonProperties<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();
            var ppt = CreateProperties();
            while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    string propertyName = reader.GetString();
                    ppt.Add(propertyName, ReadContent(ref reader, propertyName, options));
                }
            }
            return ppt;

        }
        public override void Write(Utf8JsonWriter writer, IGeoJsonProperties<T> value, JsonSerializerOptions options)
        {
            // basically this is a dictionary
            JsonSerializer.Serialize(writer, value, typeof(IDictionary<string, T>), options);
        }

        public void BindType(string propertyName, Type converter)
        {
            var tmp = propertyTypes ?? new Dictionary<string, Type>();
            tmp.Add(propertyName, converter);
            propertyTypes = tmp;
        }

        protected virtual IGeoJsonProperties<T> CreateProperties() => new GeoJsonProperties<T>();
        protected virtual T ReadContent(ref Utf8JsonReader reader, string propertyName, JsonSerializerOptions options)
        {
            if(propertyTypes.TryGetValue(propertyName, out var type))
            {
                return (T) JsonSerializer.Deserialize(ref reader, type, options);
            }
            return JsonSerializer.Deserialize<T>(ref reader, options);
        }
    }
}
