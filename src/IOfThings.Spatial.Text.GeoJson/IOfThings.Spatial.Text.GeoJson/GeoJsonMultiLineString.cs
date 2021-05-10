using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonMultiLineString : GeoJsonGeometry
    {
        internal Position[][] _coordinates;

        /// <summary>
        /// For type "MultiLineString", the "coordinates" member is an array of LineString coordinate arrays.
        /// </summary>
        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public float[][][] Coordinates { get => _coordinates.ToSingleArray(); set => _coordinates = value.FromSingleArray(); }
        public override GeoJsonType Type => GeoJsonType.MultiLineString;

        [JsonIgnore]
        public Position[][] Positions => _coordinates;
        public override Position[] BuildBBox() => BBoxExtensions.BuildBBox(this);
    }
}
