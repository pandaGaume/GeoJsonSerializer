using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonFeature<T,P> : GeoJsonObject<T>, IGeoJsonFeature<T,P>
    {
        IGeoJsonGeometry<T> _geometry;
        IGeoJsonProperties<P> _properties;
        public override GeoJsonType Type => GeoJsonType.Feature;
        
        [JsonPropertyName(Json.PropertyNames.geometry)]
        public IGeoJsonGeometry<T> Geometry { get => _geometry; set => _geometry = value; }
        
        [JsonPropertyName(Json.PropertyNames.properties)]
        public IGeoJsonProperties<P> Properties { get => _properties; set => _properties = value; }
    }
}
