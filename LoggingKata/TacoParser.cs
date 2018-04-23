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

            double longitude = 0;
            double latitude = 0;
            var name = "";
            try
            {
                longitude = double.Parse(cells[0]);
                latitude = double.Parse(cells[1]);
                if (cells.Length == 3)
                {
                    name = cells[2];
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Longitude or Latitude were not a valid number", e);
                return null;
            }

            if (longitude > 180 || longitude < -180 || latitude > 90 || latitude < -90)
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