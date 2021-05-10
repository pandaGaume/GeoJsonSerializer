using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public abstract class GeoJsonObject : IGeoJsonObject
    {
        Position[] _bbox;
        
        [JsonPropertyName(Json.PropertyNames.bbox)]
        public Position[] BBox { get=> _bbox;   set =>_bbox = value; }
        
        [JsonPropertyName(Json.PropertyNames.type)]
        public abstract GeoJsonType Type { get; }
    }
}
