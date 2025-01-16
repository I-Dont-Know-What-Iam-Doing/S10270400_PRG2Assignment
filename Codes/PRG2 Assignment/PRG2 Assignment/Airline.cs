//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace PRG2_Project
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
        public Dictionary<string, Flight> Flights { get; private set; }

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
            if (flight != null && !Flights.ContainsKey(flight.FlightNumber))
            {
                Flights.Add(flight.FlightNumber, flight);
                return true; // Added
            }
            return false; // Flight is null or already exists
        }
        public bool RemoveFlight(string flightNumber)
        {
            return Flights.Remove(flightNumber); // Remove the flight if it exists
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
        public override string ToString()
        {
            return $"Airline Code: {Code}, Name: {Name}, Total Flights: {Flights.Count}";
        }
    }
}