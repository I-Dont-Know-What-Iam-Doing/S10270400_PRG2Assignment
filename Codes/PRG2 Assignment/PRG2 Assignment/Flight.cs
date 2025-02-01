//==========================================================
// Student Number : S10270400G
// Student Name : Teo Yao Xiang
// Partner Name : Morgen Yap
//==========================================================

namespace S10270400_PRG2Assignment
{
    public abstract class Flight : IComparable<Flight>
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
        

        public Flight(string fn, string or, string des, DateTime et, string stat)
        {
            FlightNumber = fn;
            Origin = or;
            Destination = des;
            ExpectedTime = et;
            Status = stat;
        }

        public virtual double CalculateFees()
        {
            double fee = 0;

           
            if (Origin.ToLower() == "singapore (sin)")
                fee += 800; 
            if (Destination.ToLower() == "singapore (sin)")
                fee += 500; 

            return fee;
        }
    
        public override string ToString()
        {
            return $"{Origin} {Destination} {ExpectedTime} {Status}";
        }

        public int CompareTo(Flight other)
        {
            return ExpectedTime.CompareTo(other.ExpectedTime);
        }
    }
}