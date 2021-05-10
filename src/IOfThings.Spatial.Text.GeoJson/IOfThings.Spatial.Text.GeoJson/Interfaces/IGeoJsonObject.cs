using IOfThings.Spatial.Text.Json;
using System;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonObject,object>))]
    public interface IGeoJsonObject
    {
        /// <summary>
        /// A GeoJSON object has a member with the name "type".  The value of the member MUST be one of the GeoJSON types.
        /// </summary>
        GeoJsonType Type { get; }

        /// <summary>
        /// A GeoJSON object MAY have a "bbox" member, the value of which MUST be a bounding box array
        /// </summary>
        float[] BBox { get; }
    }
}
