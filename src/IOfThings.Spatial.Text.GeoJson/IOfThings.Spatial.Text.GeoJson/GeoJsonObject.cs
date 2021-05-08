using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public abstract class GeoJsonObject<T> : IGeoJsonObject<T>
    {
        T[] _bbox;
        
        [JsonPropertyName(Json.PropertyNames.bbox)]
        public T[] BBox { get => ValidateBBox() ; set =>_bbox = value; }
        
        [JsonPropertyName(Json.PropertyNames.type)]
        public abstract GeoJsonType Type { get; }

        internal T[] ValidateBBox()
        {
            return _bbox = _bbox??BuildBBox();
        }

        protected virtual T[] BuildBBox() => default;
    }
}
