
namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonPoint<T> : GeoJsonSimpleGeometry<T>
    {
        public override GeoJsonType Type => GeoJsonType.Point;

        protected override T[] BuildBBox() {

            var box = new T[Coordinates.Length*2];
            Coordinates.CopyTo(box, 0);
            Coordinates.CopyTo(box, Coordinates.Length);
            return box;
        }
    }
}
