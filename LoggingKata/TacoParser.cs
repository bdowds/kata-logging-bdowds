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

            try
            {
                var longitude = double.Parse(cells[0]);
                var latitude = double.Parse(cells[1]);
                var name = (cells.Length == 3) ? cells[2] : "";

                if (Math.Abs(longitude) > Point.MaxLon || Math.Abs(latitude) > Point.MaxLat)
                {
                    _logger.LogWarning("Longitude or Latitude out of bounds");
                    return null;
                }

                var point = new Point
                {
                    Longitude = longitude,
                    Latitude = latitude
                };

                var taco = new TacoBell
                {
                    Name = name,
                    Location = point
                };

                return taco;
            }
            catch (Exception e)
            {
                _logger.LogError("Longitude or Latitude were not a valid number", e);
                return null;
            }
        }
    }
}