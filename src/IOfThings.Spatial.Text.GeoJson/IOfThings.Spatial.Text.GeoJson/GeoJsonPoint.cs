using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonPoint : GeoJsonGeometry
    {
        internal Position _pos;

        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public float[] Coordinates
        {
            get => _pos;
            set => _pos = value;
        }

        public override GeoJsonType Type => GeoJsonType.Point;

        [JsonIgnore]
        public Position Position { get => _pos; set => _pos = value; }
    }
}
