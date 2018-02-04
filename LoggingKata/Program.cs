using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var parser = new TacoParser();

            var locations = lines.Select(line => parser.Parse(line));

            foreach (var location in locations)
            {
                Console.WriteLine("location: " + location.Name);
            }

            Console.ReadKey();
            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            //HINT:  You'll need two nested forloops
            /*for ( init; condition; increment ) {
                for ( init; condition; increment ) {
                    statement(s);
                   }
                    statement(s);
                   } */
        }
    }
}