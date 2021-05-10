using System;
using System.Collections.Generic;
using System.Linq;

namespace IOfThings.Spatial.Text.GeoJson
{
    public static class BBoxExtension
    {
        public static Position[] BuildBBox(this GeoJsonPoint pos) => BuildBBox(pos.Position);
        public static Position[] BuildBBox(this GeoJsonMultiPoint pos) => BuildBBox(pos.Positions);
        public static Position[] BuildBBox(this GeoJsonLineString pos) => BuildBBox(pos.Positions);
        public static Position[] BuildBBox(this GeoJsonMultiLineString pos) => BuildBBox(pos.Positions);
        public static Position[] BuildBBox(this GeoJsonPolygon pos) => BuildBBox(pos.Positions);
        public static Position[] BuildBBox(this GeoJsonMultiPolygon pos) => BuildBBox(pos.Positions);
        public static Position[] BuildBBox(this Position pos) => new Position[] { pos, pos };
        public static Position[] BuildBBox(this IEnumerable<Position> pos) => pos.Aggregate();
        public static Position[] BuildBBox(this IEnumerable<IEnumerable<Position>> pos) => pos.Select(p => p.BuildBBox()).Aggregate();
        public static Position[] BuildBBox(this IEnumerable<IEnumerable<IEnumerable<Position>>> pos) => pos.Select(p => p.BuildBBox()).Aggregate();


        public static Position[] AddInPlace(this Position[] a, Position[] b)
        {
            if (b != null)
            {
                a[0].Longitude = Math.Min(a[0].Longitude, b[0].Longitude);
                a[0].Latitude = Math.Min(a[0].Latitude, b[0].Latitude);
                a[1].Longitude = Math.Max(a[1].Longitude, b[1].Longitude);
                a[1].Latitude = Math.Max(a[1].Latitude, b[1].Latitude);

                if (a.HasAltitude() && b.HasAltitude())
                {
                    a[0].Altitude = Math.Min(a[0].Altitude.Value, b[0].Altitude.Value);
                    a[1].Altitude = Math.Max(a[1].Altitude.Value, b[1].Altitude.Value);
                 }
            }
            return a;
        }

        public static Position[] AddInPlace(this Position[] a, Position b)
        {
            a[0].Longitude = Math.Min(a[0].Longitude, b.Longitude);
            a[0].Latitude = Math.Min(a[0].Latitude, b.Latitude);
            a[1].Longitude = Math.Max(a[1].Longitude, b.Longitude);
            a[1].Latitude = Math.Max(a[1].Latitude, b.Latitude);

            if (a.HasAltitude() && b.HasAltitude)
            {
                a[0].Altitude = Math.Min(a[0].Altitude.Value, b.Altitude.Value);
                a[1].Altitude = Math.Max(a[1].Altitude.Value, b.Altitude.Value);
            }
            return a;
        }

        public static Position[] Aggregate(this IEnumerable<Position[]> envelopes)
        {
            if (envelopes != null || !envelopes.Any())
            {
                return envelopes.Aggregate((a, b) => a.AddInPlace(b));
            }
            return null;
        }
        public static bool HasAltitude(this Position[] a) => a[0].Altitude.HasValue && a[1].Altitude.HasValue;

    }
}