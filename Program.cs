using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Models;

namespace air_garage_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            FindParkingSpots();
        }

        private static void FindParkingSpots()
        {
            var locationData = CreateLocationData();

            Console.WriteLine("Input Command: ");
            // Get User Input
            var userInput = Console.ReadLine();

            var data = userInput.Split(" ");
            var cmd = Regex.Replace(data[0], @"[^0-9a-zA-Z]+", "");
            var variable = data[1];
            
            // Create empty list to add locations to
            var locations = new List<ParkingSpots>();
            if(Command.locate.ToString() == cmd)
            {
                locations = locationData.Where(location => location.State.ToLower() == variable.ToLower()).ToList();
                PrintLocations(locations);
            }
            else if(Command.findpricehourlylte.ToString() == cmd)
            {
                var amt = Convert.ToDecimal(variable);
                locations = GetLocations(amt, locationData);
                PrintLocations(locations);

            }
            else if(Command.findpricehourlygt.ToString() == cmd)
            {
                var amt = Convert.ToDecimal(variable);
                Console.WriteLine(amt);
                locations = GetLocations(amt, locationData, true);
                PrintLocations(locations);
            }
            else
            {
                Console.WriteLine("Not a valid command");
                FindParkingSpots();
            }

            Console.WriteLine("Would you like to continue? Y / N?");
            var keepGoing = Console.ReadLine();
            if(keepGoing.ToLower() == "y")
                FindParkingSpots();
            else
                Console.WriteLine("Program End");
                
        }

        private static List<ParkingSpots> CreateLocationData()
        {
            return new List<ParkingSpots>()
            {
                new ParkingSpots { Name = "AirGarage HQ", PriceHourly = 1.00M, State = "CA" },
                new ParkingSpots { Name = "Tempe Beach Park", PriceHourly = 1.50M, State = "AZ" },
                new ParkingSpots { Name = "Church of 8 Wheels", PriceHourly = 2.00M, State = "CA" },
                new ParkingSpots { Name = "SafeWay", PriceHourly = 2.00M, State = "AZ" },
                new ParkingSpots { Name = "Walgreens", PriceHourly = 2.00M, State = "CA" },
                new ParkingSpots { Name = "Goldilocks Pizza", PriceHourly = 2.00M, State = "NY" },
                new ParkingSpots { Name = "The Salon", PriceHourly = 2.00M, State = "CA" },
                new ParkingSpots { Name = "Archer Salon", PriceHourly = 2.00M, State = "CA" },
                new ParkingSpots { Name = "Sweetgreen", PriceHourly = 5.00M, State = "CA" },
                new ParkingSpots { Name = "Azusa Ramen", PriceHourly = 8.00M, State = "AZ" },
            };
        }

        private static void PrintLocations(List<ParkingSpots> locations)
        {
            Console.WriteLine("These locations fit your query:");
            foreach(var l in locations)
            {
                Console.WriteLine(l.Name);
            }
        }

        private static List<ParkingSpots> GetLocations(decimal amt, List<ParkingSpots> locationData, bool isGreaterThan = false)
        {
            if(isGreaterThan)
                return locationData.Where(location => location.PriceHourly > amt).ToList();
            else
                return locationData.Where(location => location.PriceHourly <= amt).ToList();
        }
    }
}
