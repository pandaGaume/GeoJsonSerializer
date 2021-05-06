
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonMultiPoint<T> : GeoJsonCompoundGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.MultiPoint;
    }
}
