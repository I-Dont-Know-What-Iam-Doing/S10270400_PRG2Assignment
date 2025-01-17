//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace S10270400_PRG2Assignment
{
    public class Airline
    {
        // Private fields
        private string name;
        private string code;
        private Dictionary<string, Flight> flights;

        // Properties 
        public string Name { get; set; }
        public string Code { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }

        // Constructor 
        public Airline(string name, string code)
        {
            Name = name;
            Code = code;
            Flights = new Dictionary<string, Flight>();
        }

        // Methods
        public bool AddFlight(Flight flight)
        {
            if (flight == null)
            {
                Console.WriteLine("You cannot add a null flight.");
                return false;
            }

            if (flights.ContainsKey(flight.FlightNumber))
            {
                Console.WriteLine($"Flight with number {flight.FlightNumber} already exists.");
                Console.WriteLine("Please do not key in duplicate flight numbers.");
                return false;
            }

            flights.Add(flight.FlightNumber, flight);
            return true;
        }

        public double CalculateFees()
        {
            double totalFees = 0.0;

            foreach (var flight in Flights.Values)
            {
                totalFees += flight.CalculateFees(); // CalculateFees from flight class
            }
            return totalFees;
        }

        public bool RemoveFlight(string flightNumber)
        {
            if (string.IsNullOrEmpty(flightNumber))
            {
                Console.WriteLine("Flight number cannot be null or empty.");
                return false;
            }

            if (flights.ContainsKey(flightNumber))
            {
                flights.Remove(flightNumber);
                return true;
            }

            Console.WriteLine($"Flight with number {flightNumber} not found.");
            return false;
        }

        public override string ToString()
        {
            return $"Airline Code: {Code}, Name: {Name}, Total Flights: {Flights.Count}";
        }
    }
}