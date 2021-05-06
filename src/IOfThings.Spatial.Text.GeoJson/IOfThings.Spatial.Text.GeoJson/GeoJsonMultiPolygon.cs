
using System.Text.Json;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonMultiPolygon<T> : GeoJsonCompoundGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.MultiPolygon;
    }
}
