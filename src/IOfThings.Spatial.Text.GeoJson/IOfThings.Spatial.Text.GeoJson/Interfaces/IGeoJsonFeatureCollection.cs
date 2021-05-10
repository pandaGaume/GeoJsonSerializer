using IOfThings.Spatial.Text.Json;
using System.Collections.Generic;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonFeatureCollection<object>, object>))]
    public interface IGeoJsonFeatureCollection<P> : IGeoJsonObject
    {
        IEnumerable<IGeoJsonFeature<P>> Features { get; set; }
    }
}
