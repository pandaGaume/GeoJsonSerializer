using System.Collections.Generic;
using System.Linq;

namespace IOfThings.Spatial.Text.GeoJson
{
    public static class PositionExtensions
    {
        public static Position[] FromSingleArray(this float[][] pos) => pos.Select(p => (Position)p).ToArray();
        public static Position[][] FromSingleArray(this float[][][] pos) => pos.Select(p => FromSingleArray(p)).ToArray();
        public static Position[][][] FromSingleArray(this float[][][][] pos) => pos.Select(p => FromSingleArray(p)).ToArray();
        public static float[][] ToSingleArray(this IEnumerable<Position> pos) => pos.Select(p => (float[])p).ToArray();
        public static float[][][] ToSingleArray(this IEnumerable<IEnumerable<Position>> pos) => pos.Select(p => p.ToSingleArray()).ToArray();
        public static float[][][][] ToSingleArray(this IEnumerable<IEnumerable<IEnumerable<Position>>> pos) => pos.Select(p => p.ToSingleArray()).ToArray();

        public static bool IsLinearRing(this Position[] polyline) => polyline != null && polyline.Length > 2 && polyline[0].Equals(polyline[polyline.Length - 1]);
        public static bool IsLinearRing(this GeoJsonLineString polyline) => IsLinearRing(polyline.Positions);

        public static Position[] Aggregate(this IEnumerable<Position> locations)
        {
            Position[] e = null;
            foreach (var l in locations)
            {
                e = e == null ? l.BuildBBox() : e.AddInPlace(l);
            }
            return e;
        }
    }
}
