﻿
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonMultiPoint : GeoJsonGeometry
    {
        internal Position[] _coordinates;

        /// <summary>
        /// For type "MultiPoint", the "coordinates" member is an array of positions.
        /// </summary>
        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public float[][] Coordinates { get => _coordinates.ToSingleArray(); set => _coordinates = value.FromSingleArray(); }
        public override GeoJsonType Type => GeoJsonType.MultiPoint;

        [JsonIgnore]
        public Position[] Positions => _coordinates;
        public override BBox BuildBBox() => BBoxExtensions.BuildBBox(this);

    }
}
