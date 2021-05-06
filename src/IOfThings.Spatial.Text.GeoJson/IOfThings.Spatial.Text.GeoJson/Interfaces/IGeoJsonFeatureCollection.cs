using IOfThings.Spatial.Text.Json;
using System.Collections.Generic;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonFeatureCollection<double,object>, double, object>))]
    public interface IGeoJsonFeatureCollection<T,P> : IGeoJsonObject<T>
    {
        IEnumerable<IGeoJsonFeature<T,P>> Features { get; set; }
    }
}
