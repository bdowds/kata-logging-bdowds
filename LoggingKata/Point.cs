using System;

namespace LoggingKata
{
    public struct Point
    {
        public static readonly double MaxLon = 180;
        public static readonly double MaxLat = 90;

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}