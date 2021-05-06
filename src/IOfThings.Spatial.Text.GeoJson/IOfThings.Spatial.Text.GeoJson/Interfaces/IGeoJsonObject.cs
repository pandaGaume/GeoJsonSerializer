using IOfThings.Spatial.Text.Json;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonObject<double>,double, object>))]
    public interface IGeoJsonObject<T>
    {
        /// <summary>
        /// A GeoJSON object has a member with the name "type".  The value of the member MUST be one of the GeoJSON types.
        /// </summary>
        GeoJsonType Type { get; }

        /// <summary>
        /// A GeoJSON object MAY have a "bbox" member, the value of which MUST be a bounding box array
        /// </summary>
        T[] BBox { get; }
    }
}
