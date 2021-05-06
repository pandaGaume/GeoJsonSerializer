
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonLineString<T> : GeoJsonSimpleGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.LineString;
    }
}
