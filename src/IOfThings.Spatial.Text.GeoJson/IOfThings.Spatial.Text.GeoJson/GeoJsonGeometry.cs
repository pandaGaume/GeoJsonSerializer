using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace IOfThings.Spatial.Text.GeoJson
{
    public abstract class GeoJsonGeometry<T> : GeoJsonObject<T>, IGeoJsonGeometry<T>
    {
    }

    public abstract class GeoJsonSimpleGeometry<T> : GeoJsonGeometry<T>, ISimpleGeometry<T>
    {
        T[] _coordinates;

        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public T[] Coordinates { get => _coordinates; set => _coordinates = value; }
    }

    public abstract class GeoJsonCompoundGeometry<T> : GeoJsonGeometry<T>, ICompoundGeometry<T>
    {
        T[][] _coordinates;

        [JsonPropertyName(Json.PropertyNames.coordinates)]
        public T[][] Coordinates { get => _coordinates; set => _coordinates = value; }
    }
}
