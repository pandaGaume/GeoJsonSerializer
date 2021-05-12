using IOfThings.Spatial.Text.Json;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonFeature<object>, object>))]
    public interface IGeoJsonFeature<P> : IGeoJsonObject
    {
        IGeoJsonGeometry Geometry { get; set; }
        IGeoJsonProperties<P> Properties { get; }
    }

}
