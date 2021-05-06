
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonPoint<T> : GeoJsonSimpleGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.Point;
    }
}
