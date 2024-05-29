using System;
using System.Linq;
using System.IO;
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

            
            var locations = lines.Select(parser.Parse).ToArray();

            ITrackable tacobell1 = null;
            ITrackable tacobell2 = null;

            double distance=0;
           
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int x=0;x <locations.Length; x++)
                {
                    var locB = locations[x];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);

                    double newDistance = corA.GetDistanceTo(corB);

                    if (newDistance > distance)
                    {
                        distance = newDistance;
                        tacobell1 = locA;
                        tacobell2 = locB;
                    }
                }
            }
            

            Console.WriteLine($"The two taco bells farthest apart at {tacobell1.Name}and {tacobell2.Name}");
            
        }
    }
}
