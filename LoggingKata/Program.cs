using System;
using System.Linq;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Logger.Info("Log initialized");

            var file = Path.Combine(Environment.CurrentDirectory, "Taco_Bell-US-AL-Alabama.csv");

            var lines = File.ReadAllLines(file);

            if (lines.Length == 0)
            {
                //Log Error
                return;
            }

            if (lines.Length == 1)
            {
                //Log Warning
                return;
            }

            Logger.Error("Nothing to read from file.");
            Logger.Warn("Only 1 line read from file.");
            Logger.Debug($"(lines.Length) lines read from file.");


            // Create a new instance of your TacoParser class
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse).ToList();


            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable LocA = null;
            ITrackable LocB = null;
            var distance = 0.0;

            foreach (var a in locations)
            {
                var origin = new Coordinate {Latitude = a.Location.Latitude, Longitude = a.Location.Longitude};

                foreach (var b in locations)
                {
                    var destination = new Coordinate {Latitude = b.Location.Latitude, Longitude = b.Location.Longitude};

                    var dist = GeoCalculator.GetDistance(origin, destination);

                    if (dist <= distance)
                    {
                        continue;
                    }

                    distance = dist;
                    LocA = a;
                    LocB = b;
                }

                Console.ReadKey();
            }
        }
    }
}