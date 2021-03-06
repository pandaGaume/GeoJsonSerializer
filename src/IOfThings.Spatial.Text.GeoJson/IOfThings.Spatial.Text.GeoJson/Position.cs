using System.Linq;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class Position
    {
        public static readonly Position Min = new Position(float.MinValue, float.MinValue, float.MinValue);
        public static readonly Position Max = new Position(float.MaxValue, float.MaxValue, float.MaxValue);


        public static implicit operator Position(float[] coordinates) => coordinates == null ? null : new Position(coordinates);
        public static implicit operator float[](Position point) => point == null ? null : point._alt.HasValue ? new float[] { point._lon, point._lat, point._alt.Value } : new float[] { point._lon, point._lat };

        float _lat;
        float _lon;
        float? _alt;

        public Position(float lat, float lon, float? alt = null)
        {
            _lat = lat;
            _lon = lon;
            _alt = alt;
        }
        public Position(float[] coordinates, int i = 0) :this(0,0)
        {
            SetInPlace(coordinates, i);
        }

        public void SetInPlace(float[] coordinates, int i = 0)
        {
            if (coordinates == null)
            {
                _lat = 0;
                _lon = 0;
                _alt = null;
            }
            else
            {
                var l = coordinates.Length;
                _lon = l > i ? coordinates[i++] : 0;
                _lat = l > i ? coordinates[i++] : 0;
                _alt = l > i ? (float?)coordinates[i] : null;
            }
        }

        public float Latitude { get => _lat; set => _lat = value; }
        public float Longitude { get => _lon; set => _lon = value; }
        public float? Altitude { get => _alt; set => _alt = value; }
        public bool HasAltitude => _alt.HasValue;

    }
}
