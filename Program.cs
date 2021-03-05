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

            // Split the input into a string array. The command will be the first element and the state or $ amount will be the second element.
            var data = userInput.Split(" ");
            // Removing the underscores from the command so that the condition statements can properly compare.
            var cmd = Regex.Replace(data[0], @"[^0-9a-zA-Z]+", "");
            // Getting the second element in the array.
            var variable = data[1];
            
            // Create empty list to add locations to.
            var locations = new List<ParkingSpots>();
            if(Command.locate.ToString() == cmd)
                // Getting locations by comparing the variable to the locations in the list.
                locations = locationData.Where(location => location.State.ToLower() == variable.ToLower()).ToList();
            else if(Command.findpricehourlylte.ToString() == cmd)
            {
                // Getting locations by comparing the variable to the locations in the list.
                var amt = Convert.ToDecimal(variable);
                
                if(Command.findpricehourlygt.ToString() == cmd)
                    locations = GetLocations(amt, locationData, true);
                else
                    locations = GetLocations(amt, locationData);
            }
            else
            {
                // If the input isn't recognized.
                Console.WriteLine("Not a valid command");
                FindParkingSpots();
            }
            
            // Writing locations to the console.
            PrintLocations(locations);
            WhatToDoNext();
        }

        private static void WhatToDoNext()
        {
            // Asks the user what they want to do next after the app gives the information requested.
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
                Console.WriteLine(l.Name);
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
