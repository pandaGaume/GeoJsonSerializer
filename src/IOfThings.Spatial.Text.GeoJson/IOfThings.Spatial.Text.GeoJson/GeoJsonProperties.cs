using System.Collections.Generic;

namespace IOfThings.Spatial.Text.GeoJson
{
    public class GeoJsonProperties<T> : Dictionary<string,T>, IGeoJsonProperties<T>
    {
    }
}
