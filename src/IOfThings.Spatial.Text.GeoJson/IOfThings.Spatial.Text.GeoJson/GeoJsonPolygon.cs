
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonPolygon<T> : GeoJsonSimpleGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.Polygon;
    }
}
