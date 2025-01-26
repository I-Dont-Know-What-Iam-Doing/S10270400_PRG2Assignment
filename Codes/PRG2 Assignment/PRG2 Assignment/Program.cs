//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

using Microsoft.VisualBasic;
using S10270400_PRG2Assignment;
using System.ComponentModel.Design;

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
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: File airlines.csv not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while loading airlines: {ex.Message}");
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
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Error: File boardinggate.csv not found.");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while loading boarding gates: {ex.Message}");
}

// Dictionary for flight details (Yao Xiang)
Dictionary<string, Flight> FlightDetails = new Dictionary<string, Flight>();

// flights csv file reading (Yao Xiang)
string[] lines = File.ReadAllLines("flights.csv");
{
    for (int i = 1; i < lines.Length; i++)
    {
        string line = lines[i];
        string[] section = line.Split(',');
        string fn = section[0];
        string or = section[1];
        string des = section[2];
        DateTime et = Convert.ToDateTime(section[3]);
        string airlineCode = fn.Substring(0, 2); // Extract airline code (e.g., "SQ")

        Flight flight; // declaring of flight obj 


        if (section[4] == "CFFT")
        {
            flight = new CFFTFlight(fn, or, des, et, section[4], 0);
        }

        else if (section[4] == "DDJB")
        {
            flight = new DDJBFlight(fn, or, des, et, section[4], 0);
        }

        else if (section[4] == "LWTT")
        {
            flight = new LWTTFlight(fn, or, des, et, section[4], 0);
        }

        else
        {
            flight = new NORMFlight(fn, or, des, et, section[4]);
        }

        FlightDetails.Add(fn, flight); // add flight to dict

        if (airlinesDetails.ContainsKey(airlineCode))
        {
            Airline airline = airlinesDetails[airlineCode];
            airline.Flights.Add(fn, flight); // Add the flight to the airline's Flights dictionary
        }
        else
        {
            Console.WriteLine($"Warning: Airline code {airlineCode} not found for flight {fn}.");
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
            Console.WriteLine("{0,-17}{1,-25}{2,-25}{3,-25}{4,-20}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");

            foreach (KeyValuePair<string, Flight> kvp in FlightDetails)
            {
                Flight flight = kvp.Value;
                string airlineName = "Unknown"; // default if no airline that matches is found

                foreach (var airline in airlinesDetails.Values)
                {
                    if (airline.Flights.ContainsKey(flight.FlightNumber))
                    {
                        airlineName = airline.Name;
                        break;
                    }
                }
                Console.WriteLine("{0,-17}{1,-25}{2,-25}{3,-25}{4,-20}", flight.FlightNumber, airlineName, flight.Origin, flight.Destination, flight.ExpectedTime);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }

        else if (option == "2")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Boarding Gates for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-18}{1,-29}{2,-29}{3,-10}", "Gate Name", "DDJB", "CFFT", "LWTT");

            foreach (KeyValuePair<string, BoardingGate> kvp in boardingGatesDetails)
            {
                BoardingGate gate = kvp.Value;
                Console.WriteLine("{0,-18}{1,-29}{2,-29}{3,-10}", gate.GateName, gate.SupportsDDJB, gate.SupportsCFFT, gate.SupportsLWTT);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }





        // ==============================================================================================================================================================================
        // INCOMPLETE
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

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
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
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                }
            }
        }

        // Completed
        else if (option == "5")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-14}{1,-30}", "Airline Code", "Airline Name");

            foreach (var airline in airlinesDetails.Values) // display the airlines 
            {
                Console.WriteLine("{0,-14}{1,-30}", airline.Code, airline.Name);
            }

            Console.Write("Enter Airline Code: "); // prompt user to key 2 letter airline code
            string selectedCode = Console.ReadLine().ToUpper();

            // Validate the airline code
            if (!airlinesDetails.ContainsKey(selectedCode))
            {
                Console.WriteLine("Invalid Airline Code.");
            }
            else
            {
                Airline selectedAirline = airlinesDetails[selectedCode];
                Console.WriteLine("=============================================");
                Console.WriteLine($"List of Flights for {selectedAirline.Name}");
                Console.WriteLine("=============================================");
                Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected \nDeparture/Arrival Time");

                foreach (var flight in selectedAirline.Flights.Values)
                {
                    Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", flight.FlightNumber, selectedAirline.Name, flight.Origin, flight.Destination, flight.ExpectedTime);
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                }
            }
        }


        // Completed
        else if (option == "6")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-14}{1,-30}", "Airline Code", "Airline Name");

            foreach (var airline in airlinesDetails.Values) // display the airlines 
            {
                Console.WriteLine("{0,-14}{1,-30}", airline.Code, airline.Name);
            }

            Console.Write("Enter Airline Code: "); // prompt user to key 2 letter airline code
            string selectedCode = Console.ReadLine().ToUpper();

            // Validate the airline code
            if (!airlinesDetails.ContainsKey(selectedCode))
            {
                Console.WriteLine("Invalid Airline Code.");
                return;
            }
            else
            {
                Airline selectedAirline = airlinesDetails[selectedCode];
                Console.WriteLine("=============================================");
                Console.WriteLine($"List of Flights for {selectedAirline.Name}");
                Console.WriteLine("=============================================");
                Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected \nDeparture/Arrival Time");

                foreach (var flight in selectedAirline.Flights.Values)
                {
                    Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", flight.FlightNumber, selectedAirline.Name, flight.Origin, flight.Destination, flight.ExpectedTime);
                }

                Console.WriteLine("Choose an existing Flight to modify or delete:");
                string flightOption = Console.ReadLine().ToUpper();

                if (!selectedAirline.Flights.ContainsKey(flightOption)) // validate flight no
                {
                    Console.WriteLine("Invalid Flight Number.");
                    return;
                }

                Flight selectedFlight = selectedAirline.Flights[flightOption];

                // Modify or delete flight
                Console.WriteLine("1. Modify Flight");
                Console.WriteLine("2. Delete Flight");
                Console.WriteLine("Choose an Option: ");
                string modifyOrDeleteOption = Console.ReadLine().ToUpper();

                if (modifyOrDeleteOption == "1") // modify flight 
                {
                    Console.WriteLine("1. Modify Basic Information");
                    Console.WriteLine("2. Modify Status");
                    Console.WriteLine("3. Modify Special Request Code");
                    Console.WriteLine("4. Modify Boarding Gate");
                    Console.WriteLine("Choose an option: ");
                    string modifyOption = Console.ReadLine();

                    if (modifyOption == "1")
                    {
                        Console.Write("Enter new Origin: ");
                        string newOrigin = Console.ReadLine();
                        Console.Write("Enter new Destination: ");
                        string newDestination = Console.ReadLine();
                        Console.Write("Enter new Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
                        DateTime newExpectedTime;

                        // Valid time input by user
                        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out newExpectedTime))
                        {
                            Console.Write("Invalid date/time format. Please enter again (dd/MM/yyyy HH:mm): ");
                        }

                        // Updated flight details
                        selectedFlight.Origin = newOrigin;
                        selectedFlight.Destination = newDestination;
                        selectedFlight.ExpectedTime = newExpectedTime;

                        Console.WriteLine("Flight updated!");
                        Console.WriteLine($"Flight Number: {selectedFlight.FlightNumber}");
                        Console.WriteLine($"Airline Name: {selectedAirline.Name}");
                        Console.WriteLine($"Origin: {selectedFlight.Origin}");
                        Console.WriteLine($"Destination: {selectedFlight.Destination}");
                        Console.WriteLine($"Expected Departure/Arrival Time: {selectedFlight.ExpectedTime}");

                        string flightStatus = selectedFlight.Status;
                        if (string.IsNullOrEmpty(flightStatus))
                        {
                            flightStatus = "Unscheduled";
                        }
                        Console.WriteLine($"Status: {flightStatus}");

                        string specialRequestCode = selectedFlight.Status;
                        if (string.IsNullOrEmpty(specialRequestCode))
                        {
                            specialRequestCode = "None";
                        }
                        Console.WriteLine($"Special Request Code: {specialRequestCode}");

                        string assignedGate = "Unassigned";
                        foreach (var gate in boardingGatesDetails.Values)
                        {
                            if (gate.Flight != null && gate.Flight.FlightNumber == selectedFlight.FlightNumber)
                            {
                                assignedGate = gate.GateName;
                                break;
                            }
                        }
                        Console.WriteLine($"Boarding Gate: {assignedGate}");
                    }
                    else if (modifyOption == "2") // modify status
                    {
                        Console.WriteLine("Choose a new Status:");
                        Console.WriteLine("1. Scheduled");
                        Console.WriteLine("2. Delayed");
                        Console.WriteLine("3. Cancelled");
                        Console.Write("Enter your option: ");
                        string statusOption = Console.ReadLine();

                        if (statusOption == "1")
                        {
                            selectedFlight.Status = "Scheduled";
                        }
                        else if (statusOption == "2")
                        {
                            selectedFlight.Status = "Delayed";
                        }
                        else if (statusOption == "3")
                        {
                            selectedFlight.Status = "Cancelled";
                        }
                        else
                        {
                            Console.WriteLine("Invalid option. Status unchanged.");
                            return;
                        }

                        Console.WriteLine($"Flight status updated to: {selectedFlight.Status}");
                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine();
                        }
                    }
                    else if (modifyOption == "3") // modify special req code
                    {
                        Console.Write("Enter new Special Request Code (CFFT/DDJB/LWTT): ");
                        string newRequestCode = Console.ReadLine().ToUpper();

                        if (newRequestCode == "DDJB")
                        {
                            selectedFlight.Status = newRequestCode;
                        }
                        else if (newRequestCode == "CFFT")
                        {
                            selectedFlight.Status = newRequestCode;
                        }
                        else if (newRequestCode == "LWTT")
                        {
                            selectedFlight.Status = newRequestCode;
                        }
                        Console.WriteLine($"Special Request Code updated to: {newRequestCode}.");

                        for (int i = 0; i < 2; i++)
                        {
                            Console.WriteLine();
                        }
                    }
                    else if (modifyOption == "4") // modify boarding gate
                    {
                        Console.Write("Enter new Boarding Gate Name: ");
                        string newGateName = Console.ReadLine().ToUpper();

                        if (boardingGatesDetails.ContainsKey(newGateName))
                        {
                            BoardingGate newGate = boardingGatesDetails[newGateName];

                            if (newGate.Flight == null)
                            {
                                // Unassign the flight from the current gate
                                foreach (var gate in boardingGatesDetails.Values)
                                {
                                    if (gate.Flight == selectedFlight)
                                    {
                                        gate.Flight = null;
                                        break;
                                    }
                                }

                                // Assign the flight to the new gate
                                newGate.Flight = selectedFlight;
                                Console.WriteLine($"Flight {selectedFlight.FlightNumber} has been reassigned to Gate {newGateName}.");
                            }
                            else
                            {
                                Console.WriteLine($"Gate {newGateName} is already assigned to another flight.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Gate Name. No changes made.");
                        }
                    }
                }
                else if (modifyOrDeleteOption == "2") // delete flight
                {
                    Console.WriteLine($"Are you sure you want to delete Flight {selectedFlight.FlightNumber}? (Y/N): ");
                    string confirmation = Console.ReadLine().ToUpper();

                    if (confirmation == "Y")
                    {
                        selectedAirline.Flights.Remove(selectedFlight.FlightNumber); // removal of flight from flight dict

                        Console.WriteLine($"Flight {selectedFlight.FlightNumber} has been successfully deleted.");
                    }
                    else if (confirmation == "N")
                    {
                        Console.WriteLine("Flight deletion canceled.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Deletion canceled.");
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine();
                }
            }
        }
        else if (option == "7")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Airlines for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            

        }

        else if (option == "0")
        {
            Console.WriteLine("Goodbye!");
            break;
        }

    }
}