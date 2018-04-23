using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);

            ITrackable Location1 = null;
            ITrackable Location2 = null;
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
                        distanceMax = currentDistance
                    }
                }
            }

            // TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}