//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace S10270400_PRG2Assignment
{
    public class BoardingGate
    {
        // Private fields
        private string gateName;
        private bool supportsCFFT;
        private bool supportsDDJB;
        private bool supportsLWTT;
        private Flight flight;

        // Properties
        public string GateName { get; private set; }
        public bool SupportsCFFT { get; private set; }
        public bool SupportsDDJB { get; private set; }
        public bool SupportsLWTT { get; private set; }
        public Flight AssignedFlight { get; private set; } // Assigned flight

        // Constructor
        public BoardingGate(string gateName, bool supportsCFFT, bool supportsDDJB, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            AssignedFlight = null; // initially, there is no flight assigned 
        }

        public double CalculateFees()
        {
            if (AssignedFlight == null)
            {
                return 0.00; // no fees to be paid
            }

            return AssignedFlight.CalculateFees();  // fee will be calculated using flight class
        }

        public override string ToString()
        {
            return $"Gate: {GateName}, Supports DDJB: {SupportsDDJB}, Supports CFFT: {SupportsCFFT}, Supports LWTT: {SupportsLWTT}";
        }
    }
}