using System;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            ITrackable location1 = null;
            ITrackable location2 = null;
            double distanceMax = 0.0;
            double currentDistance = 0.0;

            foreach (var LocA in locations)
            {
                var origin = new GeoCoordinate();
                origin.Longitude = LocA.Location.Longitude;
                origin.Latitude = LocA.Location.Latitude;

                foreach (var LocB in locations)
                {
                    var destination = new GeoCoordinate();
                    destination.Longitude = LocB.Location.Longitude;
                    destination.Latitude = LocB.Location.Latitude;

                    currentDistance = origin.GetDistanceTo(destination);

                    if (currentDistance > distanceMax)
                    {
                        distanceMax = currentDistance;
                        location1 = LocA;
                        location2 = LocB;
                    }
                }
            }

            Console.WriteLine($"Location 1 : {location1.Name}");
            Console.WriteLine($"Location 2 : {location2.Name}");

            Console.ReadKey();
        }
    }
}