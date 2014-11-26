using System;
using System.Globalization;
using Newtonsoft.Json;

namespace RedDog.Search.Model
{
    public static class PopulateOperationExtensions
    {
        public static IndexOperation WithProperty(this IndexOperation operation, string name, object value)
        {
            operation.Properties.Add(name, value);
            return operation;
        }

        public static IndexOperation WithGeographyPoint(this IndexOperation operation, string name, double longitude, double latitude)
        {
            operation.Properties.Add(name, new GeoPointField(longitude, latitude));
            return operation;
        }

    }
    internal class GeoPointField
    {
        [JsonProperty(PropertyName =  "type")]
        public string Type
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "coordinates")]
        public Double[] Coordinates
        {
            get;
            set;
        }

        public GeoPointField(params double[] coordinates)
        {
            Type = "Point";
            Coordinates = coordinates;
        }
    }
}