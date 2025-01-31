//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace S10270400_PRG2Assignment
{
    public class Terminal
    {
        // Private fields
        private string terminalName;
        private Dictionary<string, Airline> airlines;
        private Dictionary<string, Flight> flights;
        private Dictionary<string, BoardingGate> boardinggates;
        private Dictionary<string, double> gateFees;

        // Properties
        public string TerminalName { get; set; }
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, double> GateFees { get; set; }

        public Terminal()
        {

        }
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
            BoardingGates = new Dictionary<string, BoardingGate>();
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

            else if (Airlines.ContainsKey(airline.Code))
            {
                Console.WriteLine($"Airline with code {airline.Code} already exists.");
                return false;
            }

            else
            {

                Airlines[airline.Code] = airline;
                return true;
            }

        }

        public bool AddBoardingGate(BoardingGate boardingGate)
        {
            if (boardingGate == null)
            {
                Console.WriteLine("Boarding gate cannot be null.");
                return false;
            }

            if (BoardingGates.ContainsKey(boardingGate.GateName))
            {
                Console.WriteLine($"Boarding gate {boardingGate.GateName} already exists.");
                return false;
            }

            BoardingGates[boardingGate.GateName] = boardingGate;
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

            foreach (var flight in Airlines.Values.SelectMany(a => a.Flights.Values))
            {
                if (!BoardingGates.Values.Any(g => g.Flight?.FlightNumber == flight.FlightNumber))
                {
                    Console.WriteLine("Assign Boarding Gates to all Flights before continuing.\n");
                    return;
                }
            }


            double overallSubtotal = 0;
            double overallDiscounts = 0;

            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine($"{airline.Name}:");

                double airlineSubtotal = 0;
                double airlineDiscounts = 0;

                foreach (var flight in airline.Flights.Values)
                {
                    double flightFee = flight.CalculateFees();
                    double gateFee = BoardingGates.Values.Any(g => g.Flight?.FlightNumber == flight.FlightNumber) ? 300 : 0;

                    double flightDiscount = 0;
                    if (flight.ExpectedTime.Hour < 11 || flight.ExpectedTime.Hour >= 21)
                        flightDiscount += 110;

                    if (flight.Origin.Contains("Dubai (DXB)") || flight.Origin.Contains("Bangkok (BKK)") || flight.Origin.Contains("Tokyo (NRT)"))
                        flightDiscount += 25;

                    if (string.IsNullOrEmpty(flight.Status))
                        flightDiscount += 50;

                    double finalFlightFee = flightFee + gateFee - flightDiscount;
                    airlineSubtotal += flightFee + gateFee;
                    airlineDiscounts += flightDiscount;

                    Console.WriteLine($"Flight {flight.FlightNumber}: Base Fee: ${flightFee}, Discount: ${flightDiscount}, Final Fee: ${finalFlightFee}");
                }

                if (airline.Flights.Count > 5)
                {
                    airlineDiscounts += airlineSubtotal * 0.03;
                }

                double airlineFinalTotal = airlineSubtotal - airlineDiscounts;

                Console.WriteLine($"Subtotal: ${airlineSubtotal}, Total Discounts: ${airlineDiscounts}, Final Total: ${airlineFinalTotal}");
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public override string ToString()
        {
            return $"Terminal Name: {terminalName}, Total Airlines: {airlines.Count}, Total Flights: {flights.Count}, Total Boarding Gates: {BoardingGates.Count}";
        }
    }
}
















