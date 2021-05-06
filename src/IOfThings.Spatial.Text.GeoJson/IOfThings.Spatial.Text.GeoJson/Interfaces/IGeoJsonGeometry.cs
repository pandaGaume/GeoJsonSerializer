using IOfThings.Spatial.Text.Json;

namespace IOfThings.Spatial.Text.GeoJson
{
    [JsonInterfaceConverter(typeof(PolymorphicJsonConverter<IGeoJsonGeometry<double>, double, object>))]
    public interface IGeoJsonGeometry<T> : IGeoJsonObject<T>
    {
    }

    public interface ISimpleGeometry<T> : IGeoJsonGeometry<T>
    {
        T[] Coordinates { get; set; }
    }

    public interface ICompoundGeometry<T> : IGeoJsonGeometry<T>
    {
        T[][] Coordinates { get; set; }
    }

}
