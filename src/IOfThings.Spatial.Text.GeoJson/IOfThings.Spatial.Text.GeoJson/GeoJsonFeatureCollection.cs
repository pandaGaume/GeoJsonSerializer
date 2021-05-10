using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonFeatureCollection<P>: GeoJsonObject, IGeoJsonFeatureCollection<P>
    {
        List<IGeoJsonFeature<P>> _features;

        public override GeoJsonType Type => GeoJsonType.FeatureCollection;

        [JsonPropertyName(Json.PropertyNames.features)]
        public IEnumerable<IGeoJsonFeature<P>> Features { get => _features; set => _features = value.ToList(); }
        public override Position[] BuildBBox() => _features.Select(f=>f.BuildBBox()).Aggregate();
    }
}
