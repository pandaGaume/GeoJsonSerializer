using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonFeatureCollection<T,P>: GeoJsonObject<T>, IGeoJsonFeatureCollection<T, P>
    {
        List<IGeoJsonFeature<T, P>> _features;

        public override GeoJsonType Type => GeoJsonType.FeatureCollection;

        [JsonPropertyName(Json.PropertyNames.features)]
        public IEnumerable<IGeoJsonFeature<T, P>> Features { get => _features; set => _features = value.ToList(); }
    }
}
