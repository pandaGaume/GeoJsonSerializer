using System;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public abstract class GeoJsonObject : IGeoJsonObject
    {
        float[] _bbox;
        
        [JsonPropertyName(Json.PropertyNames.bbox)]
        public float[] BBox { get=> _bbox;   set =>_bbox = value; }
        
        [JsonPropertyName(Json.PropertyNames.type)]
        public abstract GeoJsonType Type { get; }

        protected virtual float[] BuildBBox() => default;
    }
}
