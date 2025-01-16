//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

using S10270400_PRG2Assignment;
using System.Xml.Linq;


static void Main(string[] args)
{
    // Dictionary for airline details (Morgen)
    Dictionary<string, Airline> airlinesDetails = new Dictionary<string, Airline>();

    try
    {
        // airlines.csv file reading (Morgen)
        string[] airlineLines = File.ReadAllLines("airlines.csv"); // Read all lines from csv file

        for (int i = 1; i < airlineLines.Length; i++) // skip first line of data (header)
        {
            string line = airlineLines[i];
            string[] section = line.Split(',');

            // Airline details
            string name = section[0]; // airline name
            string code = section[1]; // airline code

            // Create the airline objects and add it to the dictionary
            if (!airlinesDetails.ContainsKey(code))
            {
                Airline airline = new Airline(name, code);
                airlinesDetails.Add(code, airline);
            }
            else
            {
                Console.WriteLine($"Duplicate airline code found: {code}. Entry will be skipped.");
            }
        }
        Console.WriteLine("Airlines loaded successfully!");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Error: File airlines.csv not found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading airlines: {ex.Message}");
    }

    // Load airlines.csv file (Morgen)
    Console.WriteLine("\nLoaded Airlines:");
    foreach (var airline in airlinesDetails.Values)
    {
        Console.WriteLine(airline.ToString());
    }


    // Dictionary for boarding gate details (Morgen)
    Dictionary<string, BoardingGate> boardingGatesDetails = new Dictionary<string, BoardingGate>();

    // Load boardinggates.csv file
    try
    {
        string[] airlineLines = File.ReadAllLines("boardinggates.csv"); // Read all lines from csv file

        for (int i = 1; i < airlineLines.Length; i++) // skip first line of data (header)
        {
            string line = airlineLines[i];
            string[] section = line.Split(',');

            // Boarding gate details
            string gateName = section[0]; // gate name
            bool supportsCFFT = bool.Parse(section[1]); // supports CFFT
            bool supportsDDJB = bool.Parse(section[2]); // supports DDJB
            bool supportsLWTT = bool.Parse(section[3]); // supports LWTT

            // Create the boarding gate objects and add it to the dictionary
            if (!boardingGatesDetails.ContainsKey(gateName))
            {
                BoardingGate gate = new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT);
                boardingGatesDetails.Add(gateName, gate);
            }
            else
            {
                Console.WriteLine($"Duplicate boarding gate found: {gateName}. Entry will be skipped.");
            }
        }
        Console.WriteLine("Boarding gate loaded successfully!");
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine($"Error: File boardinggate.csv not found.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while loading boarding gates: {ex.Message}");
    }

    // Load boarding gate.csv file (Morgen)
    Console.WriteLine("\nLoaded Airlines:");
    foreach (var gate in boardingGatesDetails.Values)
    {
        Console.WriteLine(gate.ToString());
    }

    // Dictionary for flight details (Yao Xiang)
    Dictionary<string, Flight> FlightDetails = new Dictionary<string, Flight>();

    // flights csv file reading (Yao Xiang)
    string[] lines = File.ReadAllLines("Flights.csv");
    {
        for (int i = 1; i < lines.Length; i++)
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

            else
            {
                NORMFlight flight = new NORMFlight(fn, or, des, et, section[4]);
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
            // Incomplete
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

            // Incomplete
            else if (option == "2")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
            }

            // Incomplete
            else if (option == "3")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                Console.WriteLine("Enter Flight Number: ");
                string flnum = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter Boarding Gate Name: ");
                string gname = Console.ReadLine().ToUpper();

                foreach (KeyValuePair<string, Flight> kvp in FlightDetails)
                {
                    if (flnum == kvp.Key)
                    {
                        Flight flight = kvp.Value;
                        Console.WriteLine($"Flight Number: {flight.FlightNumber}");
                        Console.WriteLine($"Origin: {flight.Origin}");
                        Console.WriteLine($"Destination {flight.Destination}");
                        Console.WriteLine($"Expected Time: {flight.ExpectedTime}");

                        if (flight.Status == "")
                        {
                            Console.WriteLine($"Special Request Code: None");

                        }

                        else
                        {
                            Console.WriteLine($"Special Request Code: {flight.Status}");
                        }

                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Flight Number.");
                        break;
                    }
                }

                // Morgen please make the dictionary!!!!! I need it to do this part :'(

                Console.WriteLine("Would you like to update the status of the flight? (Y/N)");
                string upd_stat = Console.ReadLine().ToUpper();
                if (upd_stat == "Y")
                {
                    Console.WriteLine("1. Delayed");
                    Console.WriteLine("2. Boarding");
                    Console.WriteLine("3. On Time");
                    Console.WriteLine("Please select the new status of the flight: ");
                    string new_stat = Console.ReadLine();
                    {
                        if (new_stat == "1")
                        {
                            // append dict
                            Console.WriteLine($"Flight {flnum} has been assigned to Boarding Gate {gname}!");
                        }

                        else if (new_stat == "2")
                        {
                            // append dict
                            Console.WriteLine($"Flight {flnum} has been assigned to Boarding Gate {gname}!");
                        }

                        else if (new_stat == "3")
                        {
                            // append dict
                            Console.WriteLine($"Flight {flnum} has been assigned to Boarding Gate {gname}!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option.");
                        }

                    }
                }
                else if (upd_stat == "N")
                {
                    Console.WriteLine("Flight status not updated.");
                }

                else
                {
                    Console.WriteLine("Invalid Option.");
                }

            }

            // Incomplete
            else if (option == "4")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("Flight Creation for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
                while (true)
                {
                    Console.WriteLine("Enter Flight Number: ");
                    string flnum = Console.ReadLine();
                    Console.WriteLine("Enter Flight Origin: ");
                    string flor = Console.ReadLine();
                    Console.WriteLine("Enter Flight Destination: ");
                    string fldes = Console.ReadLine();
                    Console.WriteLine("Enter Expected Departure/Arrival Time: ");
                    DateTime flet = Convert.ToDateTime(Console.ReadLine());


                    Console.WriteLine("Would you like to enter a Special Request Code? (Y/N): ");
                    string src_opt = Console.ReadLine().ToUpper();

                    string src_code = "";
                    if (src_opt == "Y")
                    {
                        Console.WriteLine("Specify the Special Request Code (DDJB/CFFT/LWTT)");
                        src_code = Console.ReadLine().ToUpper();
                        if (src_code == "DDJB")
                        {
                            DDJBFlight flight = new DDJBFlight(flnum, flor, fldes, flet, src_code, 0);
                            FlightDetails.Add(flnum, flight);
                        }
                        else if (src_code == "CFFT")
                        {
                            CFFTFlight flight = new CFFTFlight(flnum, flor, fldes, flet, src_code, 0);
                            FlightDetails.Add(flnum, flight);
                        }
                        else if (src_code == "LWTT")
                        {
                            LWTTFlight flight = new LWTTFlight(flnum, flor, fldes, flet, src_code, 0);
                            FlightDetails.Add(flnum, flight);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Code.");
                        }

                    }
                    else if (src_opt == "N")
                    {
                        src_code = "";
                        NORMFlight flight = new NORMFlight(flnum, flor, fldes, flet, src_code);
                        FlightDetails.Add(flnum, flight);
                    }

                    string flightinfo = $"{flnum},{flor},{fldes},{flet},{src_code}";

                    File.AppendAllText("flights.csv", flightinfo);

                    Console.WriteLine("Would you like to add more flights? (Y/N) ");
                    string flopt = Console.ReadLine();
                    {
                        if (flopt == "Y")
                        {
                            continue;
                        }
                        else if (flopt == "N")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Option");
                        }
                    }
                }

            }

            // Incomplete
            else if (option == "5")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
            }

            // Incomplete
            else if (option == "6")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
            }

            // Incomplete
            else if (option == "7")
            {
                Console.WriteLine("=============================================");
                Console.WriteLine("Flight Schedule for Changi Airport Terminal 5");
                Console.WriteLine("=============================================");
            }

            else if (option == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }

            else
            {
                Console.WriteLine("Invalid option!");
            }
        }
    }
}
