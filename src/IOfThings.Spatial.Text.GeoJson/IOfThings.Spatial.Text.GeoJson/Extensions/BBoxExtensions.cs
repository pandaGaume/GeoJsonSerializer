using System;
using System.Collections.Generic;
using System.Linq;

namespace IOfThings.Spatial.Text.GeoJson
{
    public static class BBoxExtensions
    {
        public static BBox BuildBBox(this GeoJsonPoint pos) => BuildBBox(pos.Position);
        public static BBox BuildBBox(this GeoJsonMultiPoint pos) => BuildBBox(pos.Positions);
        public static BBox BuildBBox(this GeoJsonLineString pos) => BuildBBox(pos.Positions);
        public static BBox BuildBBox(this GeoJsonMultiLineString pos) => BuildBBox(pos.Positions);
        public static BBox BuildBBox(this GeoJsonPolygon pos) => BuildBBox(pos.Positions);
        public static BBox BuildBBox(this GeoJsonMultiPolygon pos) => BuildBBox(pos.Positions);
        public static BBox BuildBBox(this Position pos) => new BBox( pos, pos);
        public static BBox BuildBBox(this IEnumerable<Position> pos) => pos.Aggregate();
        public static BBox BuildBBox(this IEnumerable<IEnumerable<Position>> pos) => pos.Select(p => p.BuildBBox()).Aggregate();
        public static BBox BuildBBox(this IEnumerable<IEnumerable<IEnumerable<Position>>> pos) => pos.Select(p => p.BuildBBox()).Aggregate();


        public static BBox AddInPlace(this BBox a, BBox b)
        {
            a.SouthWest.Longitude = Math.Min(a.SouthWest.Longitude, b.SouthWest.Longitude);
            a.SouthWest.Latitude = Math.Min(a.SouthWest.Latitude, b.SouthWest.Latitude);
            a.NorthEast.Longitude = Math.Max(a.NorthEast.Longitude, b.NorthEast.Longitude);
            a.NorthEast.Latitude = Math.Max(a.NorthEast.Latitude, b.NorthEast.Latitude);

            if (a.HasAltitude() && b.HasAltitude())
            {
                a.SouthWest.Altitude = Math.Min(a.SouthWest.Altitude.Value, b.SouthWest.Altitude.Value);
                a.NorthEast.Altitude = Math.Max(a.NorthEast.Altitude.Value, b.NorthEast.Altitude.Value);
            }
            return a;
        }

        public static BBox AddInPlace(this BBox a, Position b)
        {
            a.SouthWest.Longitude = Math.Min(a.SouthWest.Longitude, b.Longitude);
            a.SouthWest.Latitude = Math.Min(a.SouthWest.Latitude, b.Latitude);
            a.NorthEast.Longitude = Math.Max(a.NorthEast.Longitude, b.Longitude);
            a.NorthEast.Latitude = Math.Max(a.NorthEast.Latitude, b.Latitude);

            if (a.HasAltitude() && b.HasAltitude)
            {
                a.SouthWest.Altitude = Math.Min(a.SouthWest.Altitude.Value, b.Altitude.Value);
                a.NorthEast.Altitude = Math.Max(a.NorthEast.Altitude.Value, b.Altitude.Value);
            }
            return a;
        }

        public static BBox Aggregate(this IEnumerable<BBox> envelopes)
        {
            if (envelopes != null || !envelopes.Any())
            {
                return envelopes.Aggregate((a, b) => a.AddInPlace(b));
            }
            return null;
        }
        public static bool HasAltitude(this BBox a) => a.SouthWest.Altitude.HasValue && a.NorthEast.Altitude.HasValue;

    }
}