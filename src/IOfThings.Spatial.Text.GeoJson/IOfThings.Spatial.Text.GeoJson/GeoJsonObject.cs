using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public abstract class GeoJsonObject : IGeoJsonObject
    {
        BBox _bbox;
        
        [JsonPropertyName(Json.PropertyNames.bbox)]
        public float[][] BBoxCoordinates { get=> _bbox;   set =>_bbox = value; }
        
        [JsonPropertyName(Json.PropertyNames.type)]
        public abstract GeoJsonType Type { get; }

        [JsonIgnore]
        public BBox BBox { get => _bbox; set => _bbox = value; }
        public abstract BBox BuildBBox() ;
    }
}
