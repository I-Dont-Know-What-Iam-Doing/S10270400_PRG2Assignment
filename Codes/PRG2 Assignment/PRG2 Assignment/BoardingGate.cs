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
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; } // Assigned flight

        // Constructor
        public BoardingGate(string gateName, bool supportsDDJB, bool supportsCFFT, bool supportsLWTT)
        {
            GateName = gateName;
            SupportsDDJB = supportsDDJB;
            SupportsCFFT = supportsCFFT;
            SupportsLWTT = supportsLWTT;
            Flight = null; // initially, there is no flight assigned 
        }

        public double CalculateFees()
        {
            if (Flight != null)
            {
                return Flight.CalculateFees() + 300;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Gate: {GateName}, Supports DDJB: {SupportsDDJB}, Supports CFFT: {SupportsCFFT}, Supports LWTT: {SupportsLWTT}";
        }
    }
}