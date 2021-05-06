using IOfThings.Spatial.Text.Json;
using System.Collections.Generic;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonFeature<double,object>, double, object>))]
    public interface IGeoJsonFeature<T,P> : IGeoJsonObject<T>
    {
        IGeoJsonGeometry<T> Geometry { get; set; }
        IGeoJsonProperties<P> Properties { get; }
    }

}
