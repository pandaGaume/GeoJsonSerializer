using IOfThings.Spatial.Text.Json;
using System.Collections.Generic;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonFeature<object>, object>))]
    public interface IGeoJsonFeature<P> : IGeoJsonObject
    {
        IGeoJsonGeometry Geometry { get; set; }
        IGeoJsonProperties<P> Properties { get; }
    }

}
