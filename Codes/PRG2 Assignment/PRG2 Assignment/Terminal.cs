//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

using System.Xml.Linq;

namespace S10270400_PRG2Assignment
{
    public class Terminal
    {
        // Private fields
        private string terminalName;
        private Dictionary<string, Airline> airlines;
        private Dictionary<string, Flight> flights;
        private Dictionary<string, BoardingGate> gates;
        private Dictionary<string, double> gateFees;

        // Properties
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, BoardingGate> Gates { get; set; }
        public Dictionary<string, double> GateFees { get; set; }

        // Constructor 
        public Terminal(string terminalName)
        {
            if (string.IsNullOrEmpty(terminalName))
            {
                throw new ArgumentException("Terminal name cannot be null or empty.", nameof(terminalName));
            }

            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            Flights = new Dictionary<string, Flight>();
            Gates = new Dictionary<string, BoardingGate>();
            GateFees = new Dictionary<string, double>();
        }

        // Methods
        public bool AddAirlines(Airline airline)
        {
            if (airline == null)
            {
                Console.WriteLine("Airline cannot be null.");
                return false;
            }

            if (Airlines.ContainsKey(airline.Code))
            {
                Console.WriteLine($"Airline with code {airline.Code} already exists.");
                return false;
            }

            Airlines[airline.Code] = airline;
            return true;

        }

        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            if (boardingGate == null)
            {
                Console.WriteLine("Boarding gate cannot be null.");
                return false;
            }

            if (Gates.ContainsKey(boardingGate.GateName))
            {
                Console.WriteLine($"Boarding gate {boardingGate.GateName} already exists.");
                return false;
            }

            Gates[boardingGate.GateName] = boardingGate;
            return true;
        }

        public Airline GetAirlineFromFlight(Flight flight)
        {
            if (flight == null)
            {
                return null;
            }

            string airlineCode = flight.FlightNumber.Substring(0, 2); // Extract airline code
            if (airlines.TryGetValue(airlineCode, out var airline))
            {
                return airline;
            }

            return null;
        }
        public void PrintAirlineFees()
        {
            Console.WriteLine("Airline Fees:");
            foreach (var airline in airlines.Values)
            {
                double totalFees = 0;

                foreach (var flight in airline.Flights.Values)
                {
                    // Calculate fees based on origin
                    if (flight.Origin == "Singapore (SIN)")
                    {
                        totalFees += 800; // for flights that depart from singapore
                    }
                    else
                    {
                        totalFees += 500; // for flights from other origins
                    }

                    // Add gate fee for flights assigned to a gate
                    foreach (var gate in gates.Values)
                    {
                        if (gate.AssignedFlight?.FlightNumber == flight.FlightNumber)
                        {
                            totalFees += 300; 
                        }
                    }

                gateFees[airline.Code] = totalFees;
                Console.WriteLine($"Airline {airline.Name} (Code: {airline.Code}) - Total Fees: ${totalFees}");
            }
        }
     }

        public override string ToString()
        {
            return $"Terminal Name: {terminalName}, Total Airlines: {airlines.Count}, Total Flights: {flights.Count}, Total Boarding Gates: {gates.Count}";
        }
    }
}
















