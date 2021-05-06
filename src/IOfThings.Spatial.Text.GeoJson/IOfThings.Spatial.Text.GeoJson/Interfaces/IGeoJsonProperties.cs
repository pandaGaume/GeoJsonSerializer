using System;
using System.Collections.Generic;
using System.Text;

namespace IOfThings.Spatial.Text.GeoJson
{
    /// <summary>
    /// We introduce this interface to let user sepcify custom converter for 
    /// the properties bag. Ie - register the JsonConverter to the JsonSerializerOptions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGeoJsonProperties<T> : IDictionary<string,T>
    {
    }
}
