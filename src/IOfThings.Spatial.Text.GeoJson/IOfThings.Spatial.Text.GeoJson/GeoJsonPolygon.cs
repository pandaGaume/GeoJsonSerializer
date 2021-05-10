using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonPolygon : GeoJsonGeometry
    {
        Position[][] _coordinates;

        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public float[][][] Coordinates { get => _coordinates.ToSingleArray(); set => _coordinates = value.FromSingleArray(); }
        public override GeoJsonType Type => GeoJsonType.Polygon;

        [JsonIgnore]
        public Position[][] Positions => _coordinates;
    }
}
