
namespace IOfThings.Spatial.Text.GeoJson
{
    public class BBox
    {
        public static BBox Empty()=>new BBox(Position.Max, Position.Min);

        public static implicit operator BBox(float[][] coordinates) => new BBox(coordinates[0], coordinates[1]);
        public static implicit operator float[][](BBox box) => new float[][] { box.SouthWest, box.NorthEast };
        
        public Position SouthWest, NorthEast;

        public BBox(Position a, Position b)
        {
            SouthWest = a;
            NorthEast = b;
        }
    }
}
