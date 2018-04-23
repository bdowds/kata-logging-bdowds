using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog _logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {

            if (string.IsNullOrEmpty(line))
            {
                _logger.LogWarning("String was empty or null");
                return null;
            }

            var cells = line.Split(',');

            if (cells.Length < 2)
            {
                _logger.LogWarning("Missing Longitude or Latitude");
                return null;
            }

            var longitude = 0.0;
            var latitude = 0.0;
            var name = "";

            try
            {
                longitude = double.Parse(cells[0]);
                latitude = double.Parse(cells[1]);
                name = (cells.Length == 3) ? cells[2] : "";
            }
            catch (Exception e)
            {
                _logger.LogError("Longitude or Latitude were not a valid number", e);
                return null;
            }

            if (Math.Abs(longitude) > Point.MaxLon || Math.Abs(latitude) > Point.MaxLat)
            {
                _logger.LogWarning("Longitude or Latitude out of bounds");
                return null;
            }

            var taco = new TacoBell();
            var point = new Point
            {
                Longitude = longitude,
                Latitude = latitude
            };

            taco.Name = name;
            taco.Location = point;

            return taco;
        }
    }
}