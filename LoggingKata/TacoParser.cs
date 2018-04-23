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
            _logger.LogInfo("Begin parsing");

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
                if (cells.Length == 3)
                {
                    var name = cells[2];
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Longitude or Latitude were not a valid number", e);
                return null;
            }
            //DO not fail if one record parsing fails, return null
            return null; //TODO Implement
        }
    }
}