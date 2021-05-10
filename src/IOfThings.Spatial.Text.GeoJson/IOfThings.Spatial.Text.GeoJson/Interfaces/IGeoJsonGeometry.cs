using IOfThings.Spatial.Text.Json;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonGeometry,object>))]
    public interface IGeoJsonGeometry : IGeoJsonObject
    {
    }
}
