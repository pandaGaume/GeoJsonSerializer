
using System;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonLineString : GeoJsonGeometry
    {
        internal Position[] _coordinates;

        /// <summary>
        /// For type "LineString", the "coordinates" member is an array of two or more positions.
        /// </summary>
        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public float[][] Coordinates { get => _coordinates.ToSingleArray(); set => _coordinates = value.FromSingleArray(); }
        public override GeoJsonType Type => GeoJsonType.LineString;

        [JsonIgnore]
        public Position[] Positions => _coordinates;
    }
}
