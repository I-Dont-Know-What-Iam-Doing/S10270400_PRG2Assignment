//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace PRG2_Project
{
    abstract class Flight
    {
        private string flightNumber;
        public string FlightNumber { get; set; }

        private string origin;
        public string Origin { get; set; }

        private string destination;
        public string Destination { get; set; }

        private DateTime expectedTime;
        public DateTime ExpectedTime { get; set; }

        private string status;
        public string Status { get; set; }

        public Flight()
        {

        }

        public Flight(string fn, string or, string des, DateTime et, string stat)
        {
            FlightNumber = fn;
            Origin = or;
            Destination = des;
            ExpectedTime = et;
            Status = stat;
        }

        public abstract double CalculateFees();

        public override string ToString()
        {
            return $"{Origin} {Destination} {ExpectedTime} {Status}";
        }
    }
}