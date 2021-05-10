namespace IOfThings.Spatial.Text.GeoJson
{
    public struct Position
    {
        public static implicit operator Position(float[] coordinates) => new Position(coordinates);
        public static implicit operator float[](Position point) => point._alt.HasValue ? new float[] { point._lon, point._lat, point._alt.Value } : new float[] { point._lon, point._lat };

        float _lat;
        float _lon;
        float? _alt;

        public Position(float lat, float lon, float? alt = null)
        {
            _lat = lat;
            _lon = lon;
            _alt = alt;
        }
        public Position(float[] src, int i = 0) :this(0,0)
        {
            SetInPlace(src, i);
        }

        public void SetInPlace(float[] coordinates, int i = 0)
        {
            var l = coordinates.Length;
            _lon = l > i ? coordinates[i++] : 0;
            _lat = l > i ? coordinates[i++] : 0;
            _alt = l > i ? (float?)coordinates[i] : null;
        }

        public float Latitude { get => _lat; set => _lat = value; }
        public float Longitude { get => _lon; set => _lon = value; }
        public float? Altitude { get => _alt; set => _alt = value; }
        public bool HasAltitude => _alt.HasValue;

    }
}
