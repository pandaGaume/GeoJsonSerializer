using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonFeature<P> : GeoJsonObject, IGeoJsonFeature<P>
    {
        IGeoJsonGeometry _geometry;
        IGeoJsonProperties<P> _properties;
        public override GeoJsonType Type => GeoJsonType.Feature;
        
        [JsonPropertyName(Json.PropertyNames.geometry)]
        public IGeoJsonGeometry Geometry { get => _geometry; set => _geometry = value; }
        
        [JsonPropertyName(Json.PropertyNames.properties)]
        public IGeoJsonProperties<P> Properties { get => _properties; set => _properties = value; }
        public override Position[] BuildBBox() => _geometry.BuildBBox();
    }
}
