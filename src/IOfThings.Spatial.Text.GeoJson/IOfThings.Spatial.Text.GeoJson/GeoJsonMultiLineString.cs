
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonMultiLineString<T> : GeoJsonCompoundGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.MultiLineString;
    }
}
