using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class PolymorphicJsonConverter<T,P> : JsonConverter<T>
    {
        static string[] TypeDiscriminatorDefault = { "type", "@type" };

        static readonly Type[] __Types =
        {
            typeof(GeoJsonPoint),
            typeof(GeoJsonLineString),
            typeof(GeoJsonPolygon),
            typeof(GeoJsonMultiPoint),
            typeof(GeoJsonMultiLineString),
            typeof(GeoJsonMultiPolygon),
            typeof(GeoJsonFeature<P>),
            typeof(GeoJsonFeatureCollection<P>)
        };

        string[] _td;
        public PolymorphicJsonConverter() : this(null) { }
        public PolymorphicJsonConverter(string[] typeDescriminator)
        {
            _td = typeDescriminator ?? TypeDiscriminatorDefault;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            var r = (typeToConvert.IsInterface && typeToConvert == typeof(T)) ||
                    typeToConvert.GetInterfaces().Any(i => i == typeof(T));
            if(r)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

            var snapshot = reader;

            if (!reader.Read() || reader.TokenType != JsonTokenType.PropertyName || !_td.Contains(reader.GetString())) throw new JsonException();
            if (!reader.Read()) throw new JsonException();

            Type t = default;

            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    {
                        t = GetType(reader.GetString());
                        break;
                    }
                default: throw new JsonException();
            }

            if (t == default) throw new JsonException();

            if (typeof(T).IsAssignableFrom(t))
            {
                var result = JsonSerializer.Deserialize(ref snapshot, t, options);
                // copy back
                reader = snapshot;
                return (T)result;
            }
            reader.Skip();

            if (reader.TokenType != JsonTokenType.EndObject) throw new JsonException();

            return default;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }

        public virtual Type GetType(string typeName)
        {
            if (Enum.TryParse<GeoJsonType>(typeName,out var geojsontype))
            {
                return __Types[(int)geojsontype];
            }
            return default;
        }
    }
}
