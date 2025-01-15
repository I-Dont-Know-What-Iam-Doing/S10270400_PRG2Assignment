using PRG2_Project;

// Dictionary for flight details
Dictionary<string, Flight> FlightDetails = new Dictionary<string, Flight>();

// flights csv file reading
string[] lines = File.ReadAllLines("Flights.csv");
{
    for (int i = 1; i <  lines.Length; i++)
    {
        string line = lines[i];
        string[] section = line.Split(',');
        string fn = section[0];
        string or = section[1];
        string des = section[2];
        DateTime et = Convert.ToDateTime(section[3]);
        if (section[4] == "CFFT")
        {
            CFFTFlight flight = new CFFTFlight(fn, or, des, et, section[4], 0);
            FlightDetails.Add(fn, flight);
        }

        else if (section[4] == "DDJB")
        {
            DDJBFlight flight = new DDJBFlight(fn, or, des, et, section[4], 0);
            FlightDetails.Add(fn, flight);
        }

        else if (section[4] == "LWTT")
        {
            LWTTFlight flight = new LWTTFlight(fn, or, des, et, section[4], 0);
            FlightDetails.Add(fn, flight);
        }

        else if (section[4] == null)
        {
            NORMFlight flight = new NORMFlight(fn, or, des, et, "");
            FlightDetails.Add(fn, flight);
        }
    }
}

// Menu
void Menu()
{
    Console.WriteLine("=============================================");
    Console.WriteLine("Welcome to Changi Airport Terminal 5");
    Console.WriteLine("=============================================");
    Console.WriteLine("1. List All Flights");
    Console.WriteLine("2. List Boarding Gates");
    Console.WriteLine("3. Assign a Boarding Gate to a Flight");
    Console.WriteLine("4. Create Flight");
    Console.WriteLine("5. Display Airline Flights");
    Console.WriteLine("6. Modify Flight Details");
    Console.WriteLine("7. Display Flight Schedule");
    Console.WriteLine("0. Exit");
    Console.WriteLine("");
    Console.WriteLine("Please select your option:");
}

// running menu
while (true)
{
    Menu();
    string option = Console.ReadLine();
    {
        if (option == "1")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Flights for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-18}{1,-25}{2,-25}{3,-25}{4,-20}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");

            foreach (KeyValuePair<string, Flight> kvp in FlightDetails)
            {
                Flight flight = kvp.Value;
                Console.WriteLine("{0,-18}{1,-25}{2,-25}{3,-25}{4,-20}", flight.FlightNumber, "Fill this in morgen", flight.Origin, flight.Destination, flight.ExpectedTime);
                // Hi Morgen, remember to replace the airline name string when youre done with the csv and stuff, delete this comment once done :)
                // If you configure this code into something differnt, let me know in telegram fam.
            }
        }

        else if (option == "0")
        {
            break;
        }

        else
        {
            Console.WriteLine("Invalid option");
        }
    }
}
