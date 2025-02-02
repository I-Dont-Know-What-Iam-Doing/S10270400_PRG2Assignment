//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================


using S10270400_PRG2Assignment;

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

// + Flight schedule dictionary
Dictionary<string, string> flightSchedule = new Dictionary<string, string>();
// - Flight schedule dictionary


// + Loading
Console.WriteLine("Loading Airlines...");
Console.WriteLine($"{airlinesDetails.Count} Airlines Loaded!");
Console.WriteLine("Loading Boarding Gates...");
Console.WriteLine($"{boardingGatesDetails.Count} Boarding Gates Loaded!");
Console.WriteLine("Loading Flights...");
Console.WriteLine($"{FlightDetails.Count} Flights Loaded!");
Console.WriteLine("\n\n\n\n");
// - Loading
 

// + Menu
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
    Console.WriteLine("8. Display Tota Airline and Flight Fees");
    Console.WriteLine("9. Bulk Assign Unassigned Flights to Boarding Gates"); 
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
        // ==============================================================================================================================================================================
        // + Option 1 (Morgen & Yao Xiang) [Completed]
        if (option == "1")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("List of Flights for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-17}{1,-25}{2,-25}{3,-25}{4,-20}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time");

            foreach (KeyValuePair<string, Flight> kvp in FlightDetails)
            {
                Flight flight = kvp.Value;
                string airlineName = "Unknown"; // Default if no airline matches

                string airlineCode = flight.FlightNumber.Substring(0, 2); // Extract airline code from flight number

                if (airlinesDetails.ContainsKey(airlineCode))
                {
                    airlineName = airlinesDetails[airlineCode].Name; // Get airline name directly
                }

                Console.WriteLine("{0,-17}{1,-25}{2,-25}{3,-25}{4,-20}", flight.FlightNumber, airlineName, flight.Origin, flight.Destination, flight.ExpectedTime);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }

        // - Option 1 (Completed)
        // ==============================================================================================================================================================================


        // ==============================================================================================================================================================================
        // + Option 2 (Morgen) [Completed]
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
        // - Option 2 (Completed)
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 3 (Yao Xiang) [Completed]
        else if (option == "3")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Assign a Boarding Gate to a Flight");
            Console.WriteLine("=============================================");

            // + Flight number prompt
            string flnum;
            while (true)
            {
                Console.WriteLine("Enter Flight Number: ");
                flnum = Console.ReadLine().ToUpper();


                // + Check if flight exist
                if (FlightDetails.ContainsKey(flnum))
                {
                    break;
                }
                // - Check if flight exist


                // + Check if flight has gate already
                string assgGate = null;
                foreach (var entry in boardingGatesDetails)
                {
                    if (entry.Value.Flight != null)
                    {
                        if (entry.Value.Flight.FlightNumber == flnum)
                        {
                            assgGate = entry.Key;
                            break;
                        }
                    }
                }

                if (assgGate != null)
                {
                    Console.WriteLine($"Flight {flnum} is already assigned to Boarding Gate {assgGate}");
                    Console.WriteLine($"Enter another Flight");
                }
                // - Check if flight has gate already


                // + Input Validation
                else
                {
                    Console.WriteLine("Invalid Flight Number.");
                }
                // - Input Validation


            }
            // - Flight number prompt


            // + Boarding gate prompt
            string gname;
            while (true)
            {
                Console.WriteLine("Enter Boarding Gate Name: ");
                gname = Console.ReadLine().ToUpper();


                // + Check if boarding gate exist
                if (boardingGatesDetails.ContainsKey(gname))
                {
                    break;
                }
                // - Check if boarding gate exist

                if (!boardingGatesDetails.ContainsKey(gname))
                {
                    Console.WriteLine("Invalid Boarding Gate");
                    continue;
                }

                // + Boarding Gate Validation
                if (boardingGatesDetails[gname].Flight != null)
                {
                    Console.WriteLine($"{gname} is already occupied by Flight {boardingGatesDetails[gname].Flight.FlightNumber}");
                    continue;
                }
                // - Boarding Gate Validation


            }
            // - Boarding gate prompt


            BoardingGate selectedGate = boardingGatesDetails[gname];

            // + Display flight details
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
            }
            // - Display flight details


            // + Display gate details
            foreach (KeyValuePair<string, BoardingGate> kvp in boardingGatesDetails)
            {
                if (gname == kvp.Key)
                {
                    BoardingGate bg = kvp.Value;
                    Console.WriteLine($"Boarding Gate Name: {bg.GateName}");
                    Console.WriteLine($"Supports DDJB: {bg.SupportsDDJB}");
                    Console.WriteLine($"Supports CFFT: {bg.SupportsCFFT}");
                    Console.WriteLine($"Supports LWTT: {bg.SupportsLWTT}");
                }
            }
            // - Display gate details


            // + Status update
            string flightStatus = "On Time";
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
                        flightStatus = "Delayed";
                    }

                    else if (new_stat == "2")
                    {
                        flightStatus = "Boarding";
                    }

                    else if (new_stat == "3")
                    {
                        flightStatus = "On Time";
                    }
                    else
                    {
                        Console.WriteLine($"Invalid Option. Flight status remains {flightStatus}");
                        Console.WriteLine("To modify, select option 6.");
                    }

                }
            }
            else if (upd_stat == "N")
            {
                Console.WriteLine("Flight status not updated.");
                Console.WriteLine("If you would like to modify status, select option 6.");
            }

            else
            {
                Console.WriteLine("Invalid Option.");
            }
            // - Status update

            boardingGatesDetails[gname].Flight = FlightDetails[flnum];

            // + Append Schedule
            flightSchedule[flnum] = flightStatus;
            // - Append Schedule

            Console.WriteLine($"Flight {flnum} has been assigned to Boarding Gate {gname}!");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 3 (Completed)
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 4 (Yao Xiang) [Completed]
        else if (option == "4")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Creation for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            while (true)
            {
                // + Flight Num Prompt
                string flnum;
                while (true)
                {
                    Console.WriteLine("Enter Flight Number: ");
                    flnum = Console.ReadLine().ToUpper();

                    // + Num validation
                    if (flnum.Length < 2)
                    {
                        Console.WriteLine("Invalid Flight Number.");
                        continue;
                    }
                    // - Num validation

                    // + Code Validation
                    if (!airlinesDetails.ContainsKey(flnum.Substring(0, 2)))
                    {
                        Console.WriteLine($"Airline Code {flnum.Substring(0, 2)} doesn't exist.");
                        Console.WriteLine($"Enter a valid Airline Code.\n");
                        continue;
                    }
                    // - Code validation

                    // + Flnum existence validation
                    if (FlightDetails.ContainsKey(flnum))
                    {
                        Console.WriteLine($"Flight {flnum} already exist.");
                        Console.WriteLine($"Enter another Flight Number.\n");
                        continue;
                    }
                    // - Flnum existence validation

                    break;
                }
                // - Flight Num prompt


                // + Origin and Destination prompt
                string org, des;
                while (true)
                {
                    Console.WriteLine("Enter Flight Origin: ");
                    org = Console.ReadLine();
                    Console.WriteLine("Enter Flight Destination: ");
                    des = Console.ReadLine();

                    string orgLower = org.ToLower();
                    string desLower = des.ToLower();


                    // + Validation
                    if (!orgLower.Contains("singapore (sin)"))
                    {
                        if (!desLower.Contains("singapore (sin)"))
                        {
                            Console.WriteLine("Either Origin or Destination has to include 'Singapore (SIN)'.");
                            continue;
                        }
                    }
                    // - Validation


                    // + Similar Org and Des validation
                    if (orgLower == desLower)
                    {
                        Console.WriteLine("Origin and Destination cannot be the same.");
                        continue;
                    }
                    // - Similar Org and Des validation

                    break;
                }
                // - Origin and Destination Prompt


                // + ETA prompt
                DateTime expTime;
                while (true)
                {
                    Console.WriteLine("Enter Expected Departure/Arrival Time (dd/mm/yyyy hh:mm): ");
                    string eta = Console.ReadLine();

                    if (DateTime.TryParseExact(eta, "dd/MM/yyyy HH:mm", null, 0, out expTime))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid format / input.");
                    }

                }
                // - ETA prompt

                // + Code Prompt
                Console.WriteLine("Enter Special Request Code (CFFT/DDJB/LWTT/None): ");
                string code = Console.ReadLine();

                Flight newFlight = null;

                if (code == "CFFT")
                {
                    newFlight = new CFFTFlight(flnum, org, des, expTime, code, 0);

                }

                else if (code == "DDJB")
                {
                    newFlight = new DDJBFlight(flnum, org, des, expTime, code, 0);

                }

                else if (code == "LWTT")
                {
                    newFlight = new LWTTFlight(flnum, org, des, expTime, code, 0);

                }

                else if (code.ToUpper() == "NONE")
                {
                    code = "";
                    newFlight = new NORMFlight(flnum, org, des, expTime, code);

                }

                else
                {
                    Console.WriteLine($"Invalid Special Request Code. Setting as 'None'");
                    Console.WriteLine("If you would like to modify the code, select option 6.\n");
                }
                // - Code Prompt
                FlightDetails[flnum] = newFlight;


                try
                {
                    string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "flights.csv");

                    using (StreamWriter sw = new StreamWriter(filePath, true))
                    {
                        sw.WriteLine($"{flnum},{org},{des},{expTime:hh:mm tt},{code}");
                        Console.WriteLine($"Flight {flnum} has been added!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error writing to flights.csv: {ex.Message}");
                }

                Console.WriteLine("Would you like to add another flight? (Y/N): ");
                string addMore = Console.ReadLine().ToUpper();

                if (addMore != "Y")
                {
                    break;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 4 (Completed)
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 5 (Morgen) [Completed]
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
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 5 (Completed)
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 6 (Morgen) [Completed]
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

            Console.WriteLine("Enter Airline Code: "); // prompt user to key 2 letter airline code
            string selectedCode = Console.ReadLine().ToUpper();

            // Validate the airline code
            if (!airlinesDetails.ContainsKey(selectedCode))
            {
                Console.WriteLine("Invalid Airline Code.");
                return;
            }

            Airline selectedAirline = airlinesDetails[selectedCode];

            Console.WriteLine("=============================================");
            Console.WriteLine($"List of Flights for {selectedAirline.Name}");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected \nDeparture/Arrival Time");

            foreach (var flight in selectedAirline.Flights.Values)
            {
                Console.WriteLine("{0,-16}{1,-23}{2,-24}{3,-23}{4,-25}", flight.FlightNumber, selectedAirline.Name, flight.Origin, flight.Destination, flight.ExpectedTime);
            }

            Console.WriteLine("Choose an existing Flight to modify or delete: ");
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

                if (modifyOption == "1") // Modify Basic Information
                {
                    string newOrigin, newDestination;

                    while (true)
                    {
                        Console.Write("Enter new Origin: ");
                        newOrigin = Console.ReadLine().Trim();
                        Console.Write("Enter new Destination: ");
                        newDestination = Console.ReadLine().Trim();

                        // Convert to lowercase for case-insensitive comparison
                        string originLower = newOrigin.ToLower();
                        string destinationLower = newDestination.ToLower();

                        // Validation: Either origin or destination must be Singapore (SIN)
                        if (!(originLower.Contains("singapore (sin)") || destinationLower.Contains("singapore (sin)")))
                        {
                            Console.WriteLine("Either Origin or Destination must be 'Singapore (SIN)'. Please re-enter.");
                            continue;
                        }

                        // Validation: Origin and Destination cannot be the same
                        if (originLower == destinationLower)
                        {
                            Console.WriteLine("Origin and Destination cannot be the same. Please re-enter.");
                            continue;
                        }

                        break; // Exit loop if input is valid
                    }

                    DateTime newExpectedTime;
                    while (true)
                    {
                        Console.Write("Enter new Expected Departure/Arrival Time (dd/MM/yyyy HH:mm): ");
                        string inputTime = Console.ReadLine();

                        if (DateTime.TryParseExact(inputTime, "dd/MM/yyyy HH:mm", null, System.Globalization.DateTimeStyles.None, out newExpectedTime))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid date/time format. Please enter again (dd/MM/yyyy HH:mm).");
                        }
                    }

                    // Update flight details
                    selectedFlight.Origin = newOrigin;
                    selectedFlight.Destination = newDestination;
                    selectedFlight.ExpectedTime = newExpectedTime;

                    Console.WriteLine("Flight updated!");
                    Console.WriteLine($"\nFlight Number: {selectedFlight.FlightNumber}");
                    Console.WriteLine($"Airline Name: {selectedAirline.Name}");
                    Console.WriteLine($"Origin: {selectedFlight.Origin}");
                    Console.WriteLine($"Destination: {selectedFlight.Destination}");
                    Console.WriteLine($"Expected Departure/Arrival Time: {selectedFlight.ExpectedTime}");

                    string flightStatus = selectedFlight.Status;
                    if (string.IsNullOrEmpty(flightStatus))
                    {
                        flightStatus = "Unscheduled";
                    }
                    else 
                    {
                        flightStatus = "Scheduled";
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
                    Console.Write("Enter your option (1/2/3): ");
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

                    flightSchedule[selectedFlight.FlightNumber] = selectedFlight.Status;

                    Console.WriteLine($"Flight status updated to: {selectedFlight.Status}!");
                    UpdateFlightsCSV(FlightDetails);
                }
                else if (modifyOption == "3") // modify special req code
                {
                    Console.Write("Enter new Special Request Code (CFFT/DDJB/LWTT): ");
                    string newRequestCode = Console.ReadLine().ToUpper();

                    if (newRequestCode == "DDJB" || newRequestCode == "CFFT" || newRequestCode == "LWTT")
                    {
                        selectedFlight.Status = newRequestCode;
                        Console.WriteLine($"Special Request Code updated to: {newRequestCode}!");
                        UpdateFlightsCSV(FlightDetails);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Special Request Code. No changes made.");
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
                            UpdateFlightsCSV(FlightDetails);
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
            else if (modifyOrDeleteOption == "2") // Delete Flight
            {
                Console.Write($"\nAre you sure you want to delete Flight {flightOption}? (Y/N): ");
                string confirmation = Console.ReadLine().ToUpper();

                if (confirmation == "Y")
                {
                    selectedAirline.Flights.Remove(flightOption); // Remove from dictionary
                    FlightDetails.Remove(flightOption);
                    Console.WriteLine($"Flight {flightOption} has been deleted.");
                }
                else
                {
                    Console.WriteLine("Flight deletion cancelled.");
                }
            }
        }
        // - Option 6 (Complete)
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 7 (Yao Xiang)
        else if (option == "7")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Flight Schedule for Changi Airport Terminal 5");
            Console.WriteLine("=============================================");
            Console.WriteLine("{0,-15}{1,-22}{2,-20}{3,-20}{4,-35}{5,-12}{6,-15}", "Flight Number", "Airline Name", "Origin", "Destination", "Expected Departure/Arrival Time", "Status", "Boarding Gate");

            List<Flight> sortedFlights = FlightDetails.Values.ToList();
            sortedFlights.Sort();

            foreach (Flight flight in sortedFlights)
            {
                string airlineCode = flight.FlightNumber.Substring(0, 2);

                string airlineName = airlinesDetails[airlineCode].Name;

                string status;
                if (flightSchedule.ContainsKey(flight.FlightNumber))
                {
                    status = flightSchedule[flight.FlightNumber];
                }
                else
                {
                    status = "Scheduled";
                }

                string boardingGate = "Unassigned";
                foreach (var gate in boardingGatesDetails.Values)
                {
                    if (gate.Flight != null && gate.Flight.FlightNumber == flight.FlightNumber)
                    {
                        boardingGate = gate.GateName;
                        break;
                    }
                }

                string formattedTime = flight.ExpectedTime.ToString("dd/MM/yyyy h:mm:ss tt");

                Console.WriteLine($"{flight.FlightNumber,-14} {airlineName,-21} {flight.Origin,-19} {flight.Destination,-19} {formattedTime,-34} {status,-11} {boardingGate,-15}");
            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 7
        // ==============================================================================================================================================================================


        // ==============================================================================================================================================================================
        // + Option 8 (Yao Xiang)
        else if (option == "8")
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Display Fee of Airline including relateed Flights");
            Console.WriteLine("=============================================\n");


            Terminal terminal = new Terminal();

            terminal.Airlines = airlinesDetails;
            terminal.BoardingGates = boardingGatesDetails;
            terminal.PrintAirlineFees();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 8
        // ==============================================================================================================================================================================


        // ==============================================================================================================================================================================
        // + Option 9 (Morgen)
        else if (option == "9")
        {
            Queue<Flight> unassignedFlights = new Queue<Flight>(); // queue for flights without a gate

            // find all unassigned flights
            foreach (var flight in FlightDetails.Values)
            {
                bool isAssigned = false;

                // check if the flight already has a boarding gate assigned
                foreach (var boardingGate in boardingGatesDetails.Values)
                {
                    if (boardingGate.Flight != null && boardingGate.Flight.FlightNumber == flight.FlightNumber)
                    {
                        isAssigned = true;
                        break;
                    }
                }

                if (!isAssigned)
                {
                    unassignedFlights.Enqueue(flight);
                }
            }

            int totalUnassignedFlights = unassignedFlights.Count;
            int totalUnassignedGates = 0;

            // count unassigned boarding gates
            foreach (var boardingGate in boardingGatesDetails.Values)
            {
                if (boardingGate.Flight == null)
                {
                    totalUnassignedGates++;
                }
            }

            Console.WriteLine($"\nTotal Unassigned Flights: {totalUnassignedFlights}");
            Console.WriteLine($"Total Unassigned Boarding Gates: {totalUnassignedGates}\n");

            int successfullyAssigned = 0;

            // assign flights from the queue
            while (unassignedFlights.Count > 0)
            {
                Flight currentFlight = unassignedFlights.Dequeue();
                BoardingGate assignedGate = null;

                // check if the flight has a special request
                if (!string.IsNullOrEmpty(currentFlight.Status)) // if special request exists
                {
                    foreach (var boardingGate in boardingGatesDetails.Values)
                    {
                        if (boardingGate.Flight == null) // Gate must be empty
                        {
                            if ((currentFlight.Status == "CFFT" && boardingGate.SupportsCFFT) ||
                                (currentFlight.Status == "DDJB" && boardingGate.SupportsDDJB) ||
                                (currentFlight.Status == "LWTT" && boardingGate.SupportsLWTT))
                            {
                                assignedGate = boardingGate;
                                break;
                            }
                        }
                    }
                }

                // find any available gate, since no special req
                if (assignedGate == null)
                {
                    foreach (var boardingGate in boardingGatesDetails.Values)
                    {
                        if (boardingGate.Flight == null) // gate must be empty
                        {
                            assignedGate = boardingGate;
                            break;
                        }
                    }
                }

                // assign the flight to the found gate
                if (assignedGate != null)
                {
                    assignedGate.Flight = currentFlight;
                    Console.WriteLine($"Flight {currentFlight.FlightNumber} assigned to Gate {assignedGate.GateName}.");
                    successfullyAssigned++;
                }
                else
                {
                    Console.WriteLine($"No available gate for Flight {currentFlight.FlightNumber}.");
                }
            }

            // calculate assignment percentage
            double successRate;
            if (totalUnassignedFlights > 0)
            {
                successRate = ((double)successfullyAssigned / totalUnassignedFlights) * 100;
            }
            else
            {
                successRate = 0; // avoid dividing by zero
            }

            // display the stats
            Console.WriteLine("\n=============================================");
            Console.WriteLine("Bulk Gate Assignment Summary");
            Console.WriteLine("=============================================");
            Console.WriteLine($"Total Flights Processed: {totalUnassignedFlights}");
            Console.WriteLine($"Total Boarding Gates Processed: {totalUnassignedGates}");
            Console.WriteLine($"Successful Assignments: {successfullyAssigned}");
            Console.WriteLine($"Automatic Assignment Rate: {successRate:F2}%");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
            }
        }
        // - Option 9
        // ==============================================================================================================================================================================

        // ==============================================================================================================================================================================
        // + Option 0
        else if (option == "0")
        {
            Console.WriteLine("Goodbye!");
            break;
        }
        // - Option 0
        // ==============================================================================================================================================================================
    }
}
void UpdateFlightsCSV(Dictionary<string, Flight> flights)
{
    string filePath = "Flights.csv"; // Ensure correct file name

    try
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine("FlightNumber,Origin,Destination,ExpectedTime,SpecialRequest");

            foreach (var flight in flights.Values)
            {
                sw.WriteLine($"{flight.FlightNumber},{flight.Origin},{flight.Destination},{flight.ExpectedTime:dd/MM/yyyy HH:mm},{flight.Status}");
            }
        }
        Console.WriteLine("Flights.csv has been updated successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating Flights.csv: {ex.Message}");
    }
}